using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.UI;

public class OmekaManager : MonoBehaviour
{
    public string collectionName = "Anairousis Scenario";
    public string urlAPI = "isd-omekas.syros.aegean.gr";
    public string keyIdentity = "b80ShRFWsUlhNZdjX9vWx7rYakFimkGK";
    public string keyCredential = "Vh89o5ocakigYwGdNuwyKKWCXKebUJee";

    private long? itemSetID;

    public Dictionary<string, OmekaS.OmekaObject> omekaObjects;
    public static OmekaManager instance;

    public void Start() {
        instance = this;
        omekaObjects = new Dictionary<string, OmekaS.OmekaObject>();
        StartCoroutine(FindItemSetID(collectionName));
    }

    public void Update() {

    }


    /*private IEnumerator FindImageURL(int mediaID) {
        string url = "http://" + urlAPI + "/api/media/" + "?id=" + mediaID + "&key_identity=" + keyIdentity + "&key_credential=" + keyCredential;
        using (UnityWebRequest www = UnityWebRequest.Get(url)) {
            www.SetRequestHeader("Content-type", "application/json");
            yield
            return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError) {
                Debug.Log(www.error);
            }
            else {
                string jsonContent = www.downloadHandler.text;
                List<OmekaS.OmekaObject> medias = Newtonsoft.Json.JsonConvert.DeserializeObject<List<OmekaS.OmekaObject>>(jsonContent);
                Debug.Log("MEDIA : " + medias.Count);
                foreach (OmekaS.OmekaObject media in medias) {
                    Debug.Log("   ----> " + media.oid + " : " + media.otitle + " URL : " + media.ooriginal_url);
                    imageUrl = media.ooriginal_url;
                    Debug.Log("URL: " + imageUrl);
                }
                needTexture = true;
            }
        }
    }*/

    private IEnumerator SetImageAsTexture(System.Uri url, GameObject go) { // Texture mapped to 3D plane
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url)) {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError) {
                Debug.Log(www.error + ": " + url);
            }
            else {
                Texture2D texture = DownloadHandlerTexture.GetContent(www);
                go.GetComponent<Renderer>().material.SetTexture("_MainTex", texture);
            }
        }
    }

    private IEnumerator SetGUIImage(System.Uri url, GameObject image) {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url)) {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError) {
                Debug.Log(www.error + ": " + url);
            }
            else {
                Texture2D tex = DownloadHandlerTexture.GetContent(www);
                image.GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            }
        }
    }

    private IEnumerator FindItemSetID(string collectionName) {
        string url = "http://" + urlAPI + "/api/item_sets" + "?key_identity=" + keyIdentity + "&key_credential=" + keyCredential;


        using (UnityWebRequest www = UnityWebRequest.Get(url)) {
            www.SetRequestHeader("Content-type", "application/json");
            yield
            return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError) {
                Debug.Log(www.error);
            }
            else {
                string jsonContent = www.downloadHandler.text;

                Debug.Log(www.downloadHandler.text);

                List<OmekaS.OmekaObject> itemsets = JsonConvert.DeserializeObject<List<OmekaS.OmekaObject>>(jsonContent);
                Debug.Log(" ITEM SETS : " + itemsets.Count);
                foreach (OmekaS.OmekaObject itemset in itemsets) {
                    Debug.Log("   ----> " + itemset.oid + " : " + itemset.otitle + " / " + itemset.dctermstitle[0].value + " == " + collectionName + "?");
                    if (itemset.otitle.Contains(collectionName)) {
                        Debug.Log("item set found");
                        itemSetID = itemset.oid;
                        StartCoroutine(ListItems(itemSetID));
                    }
                }
            }
        }
    }

    private IEnumerator ListItems(long? itemSetID) {
        Debug.Log("Listing items in item set " + itemSetID);
        string url = "http://" + urlAPI + "/api/items" + "?item_set_id=" + itemSetID + "&key_identity=" + keyIdentity + "&key_credential=" + keyCredential;

        using (UnityWebRequest www = UnityWebRequest.Get(url)) {
            www.SetRequestHeader("Content-type", "application/json");
            yield
            return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError) {
                Debug.Log(www.error);
            }
            else {
                string jsonContent = www.downloadHandler.text;

                List<OmekaS.OmekaObject> items = JsonConvert.DeserializeObject<List<OmekaS.OmekaObject>>(jsonContent);
                foreach (OmekaS.OmekaObject item in items) {
                    Debug.Log("Found item: \"" + item.dctermstitle[0].value + "\" with class \"" + item.type[1] + "\"");
                    if (item.dctermsdescription != null) {
                        //Debug.Log("Description: \"" + item.dctermsdescription[0].value + "\"");
                        omekaObjects.Add(item.dctermstitle[0].value, item);
                        //Debug.Log("added" + item.dctermstitle[0].value);
                    }
                }
            }
        }
    }

    private void ListProperties(OmekaS.OmekaObject item, string vocabularyPrefix) {
        foreach (var p in item.GetType().GetProperties()) {
            if (p.Name.StartsWith(vocabularyPrefix) && p.GetValue(item) != null) {
                Debug.Log(p.Name + ": " + p.GetValue(item));
            }
        }
    }

    private object GetProperty(string itemName, string propertyName) {
        OmekaS.OmekaObject item = omekaObjects[itemName];
        foreach (var p in item.GetType().GetProperties()) {
            Debug.Log("property: "+p.Name);
            if (p.Name.StartsWith(propertyName) && p.GetValue(item) != null) {
                return p.GetValue(item);
            }
        }
        return "";
    }
    public string GetDescription(string itemName) {
        object o = GetProperty(itemName, "dctermsdescription");
        List<OmekaS.DctermsDescription> descriptions = o as List<OmekaS.DctermsDescription>;
        return descriptions[0].value;
    }
    /*
      private IEnumerator listCIDOCProperties(int itemID) {
        string url = "http://" + urlAPI + "/api/items" + "?id=" + itemID + "&key_identity=" + keyIdentity + "&key_credential=" + keyCredential;

        Debug.Log(url);
        using(UnityWebRequest www = UnityWebRequest.Get(url)) {
          www.SetRequestHeader("Content-type", "application/json");
          yield
          return www.SendWebRequest();

          if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError) {
            Debug.Log(www.error);
          } else {
            string jsonContent = www.downloadHandler.text;

            Debug.Log(jsonContent);
            OmekaS.OmekaObject item = JsonConvert.DeserializeObject<OmekaS.OmekaObject>(jsonContent);
            foreach (var p in item.GetType().GetProperties()) {
              Debug.Log(p.Name + ": " + p.Getvalue(item, null));
            }

            listed = true;
            listing = false;
          }
        }
      }
      */
}
