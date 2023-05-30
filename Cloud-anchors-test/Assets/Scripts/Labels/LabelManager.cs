using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas canvas;
    public Camera cam;
    public static LabelManager instance;
    public GameObject FloatingLabelObj;

    private Dictionary<string, FloatingLabel> allLabels;
    void Start() {
        allLabels = new Dictionary<string, FloatingLabel>();
        instance = this;
    }

    // Update is called once per frame
    void Update() {   
        if(Input.GetKeyDown(KeyCode.L)) {
            GameObject flObj = GameObject.Find("FloatingLabel");
            if (flObj != null) Debug.Log("have label");
            GameObject cbObj = GameObject.Find("Cube");
            if (cbObj != null) Debug.Log("have cube");
            FloatingLabel fl = flObj.GetComponent<FloatingLabel>();
            CreateLabel(fl, cbObj, "Hello World!");
        }
    }

    public void CreateLabel(FloatingLabel fl, GameObject anchor, string labelContent) {
        fl.SetupLabel(canvas, cam, anchor.transform, labelContent);
        allLabels.Add(anchor.name, fl);
    }

    public void CreateAnchor(LabelAnchor anchor) {
        GameObject flObj = Instantiate(FloatingLabelObj, canvas.transform);
        FloatingLabel fl = flObj.GetComponent<FloatingLabel>();
        CreateLabel(fl, anchor.gameObject, anchor.text);
    }

    public void DestroyAnchor(LabelAnchor anchor) {
        GameObject anchorObj = allLabels[anchor.name].gameObject;
        allLabels.Remove(anchor.name);
        Destroy(anchorObj);
    }
}
