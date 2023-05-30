using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAREditor : MonoBehaviour
{
    public ARAgent agent;
    public ARSceneManager sceneManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)) {
            string[] answers = agent.Chat(stringToEdit);
            Debug.Log(answers[0]);
            if (answers.Length > 0) {
                for (int i = 1; i < (answers.Length - 1); i++) {
                    sceneManager.Exec(answers[i]);
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.P)) {
            ARSceneManager sm = GameObject.Find("ARScene").GetComponent<ARSceneManager>();
            sm.ShowChild("sign1", true);
            sm.ShowChild("aggy", false);
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            ARSceneManager sm = GameObject.Find("ARScene").GetComponent<ARSceneManager>();
            sm.ShowChild("sign1", false);
            sm.ShowChild("aggy", true);
        }
        if(Input.GetKeyDown(KeyCode.O)) {
            string result = OmekaManager.instance.GetDescription("lead");
            Debug.Log("result :'" + result + "'");
        }
    }

    public string stringToEdit = "Hello World";

    void OnGUI() {
        // Make a text field that modifies stringToEdit.
        stringToEdit = GUI.TextField(new Rect(10, 10, 200, 20), stringToEdit, 25);
    }
}
