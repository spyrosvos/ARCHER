using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Globalization;

public class EditManager : MonoBehaviour {
    private Vector3 initialPos;
    private Vector3 initialAngles;
    private Transform selectedTransform;
    public Camera ARCamera;

    public enum ControlValue { X, Y, Z, RX, RY, RZ };
    public enum ControlPrecision { M, DM, CM };

    public Slider slider;
    public TextMeshProUGUI selectedInfo;

    private ControlValue controlValue;
    private ControlPrecision controlPrecision;

    // Start is called before the first frame update
    void Start() {
        //selectedTransform = GameObject.Find("cb").transform;
        SetSelectedObject(null);
    }

    // Update is called once per frame
    void Update() {
        /*if(Input.GetKeyDown(KeyCode.Z)) {
            SetSelectedObject(GameObject.Find("cb").transform, ControlValue.X, ControlPrecision.M);
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            SetSelectedObject(GameObject.Find("cb").transform, ControlValue.Y, ControlPrecision.M);
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            SetSelectedObject(GameObject.Find("cb").transform, ControlValue.RY, ControlPrecision.M);
        }
        if (Input.GetKeyDown(KeyCode.V)) {
            SetSelectedObject(GameObject.Find("cb").transform, ControlValue.RZ, ControlPrecision.M);
        }*/
        if (Input.GetMouseButtonDown(0)) {
            GameManager.instance.DebugText("clicked!");
            GameManager.instance.DebugText("camera: "+ARCamera.name);
            GameManager.instance.DebugText("pos: " + Input.mousePosition);
            RaycastHit hit;
            Ray ray = ARCamera.ScreenPointToRay(Input.mousePosition);
            GameManager.instance.DebugText("have ray");
            if (Physics.Raycast(ray, out hit)) {
                GameManager.instance.DebugText("have hit");
                SetSelectedObject(hit.transform);
            }
        }
    }


    public void SliderChanged() {
        updateValues(slider.value);
    }

    private void updateValues(float value) {
        if (selectedTransform == null) return;
        float addValue = value;
        if (controlPrecision == ControlPrecision.DM) addValue /= 10;
        else if(controlPrecision == ControlPrecision.CM) addValue /= 100;

        switch(controlValue) {
            case ControlValue.X:
                selectedTransform.localPosition = new Vector3(initialPos.x + addValue, initialPos.y, initialPos.z);
                break;
            case ControlValue.Y:
                selectedTransform.localPosition = new Vector3(initialPos.x , initialPos.y + addValue, initialPos.z);
                break;
            case ControlValue.Z:
                selectedTransform.localPosition = new Vector3(initialPos.x, initialPos.y, initialPos.z + addValue);
                break;
            case ControlValue.RX:
                selectedTransform.localEulerAngles = new Vector3(initialAngles.x - addValue*10, initialAngles.y, initialAngles.z);
                break;
            case ControlValue.RY:
                selectedTransform.localEulerAngles = new Vector3(initialAngles.x, initialAngles.y - addValue*10, initialAngles.z);
                break;
            case ControlValue.RZ:
                selectedTransform.localEulerAngles = new Vector3(initialAngles.x, initialAngles.y, initialAngles.z - addValue*10);
                break;
        }
    }

    public void SetSelectedObject(Transform t, ControlValue cv, ControlPrecision cp) {
        selectedTransform = t;
        controlValue = cv;
        controlPrecision = cp;
        string goName = "<none>";
        if (t != null) {
            initialPos = t.localPosition;
            initialAngles = t.localEulerAngles;
            goName = t.gameObject.name;
        }
        slider.SetValueWithoutNotify(0);
        selectedInfo.text = goName + ", " + cv + ", " + cp;
    }

    public void SetControlValue(string v) {

        SetSelectedObject(selectedTransform, (ControlValue) Enum.Parse(typeof(ControlValue), v), controlPrecision);

    }

    public void SetControlPrecision(string p) {
        SetSelectedObject(selectedTransform, controlValue, (ControlPrecision) Enum.Parse(typeof(ControlPrecision), p));
    }

    public void SetSelectedObject(Transform t) {
        SetSelectedObject(t, controlValue, controlPrecision);
    }

    public void ResetSelectedObj() {
        selectedTransform.localPosition = initialPos;
        selectedTransform.localEulerAngles = initialAngles;
        slider.SetValueWithoutNotify(0);
    }

    public void Save() {
        ARSceneManager.instance.SaveScene();
        selectedInfo.text = "saved!";
    }
}
