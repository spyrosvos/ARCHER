using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class ARSceneManager : MonoBehaviour {

    public static ARSceneManager instance;

    public void Start() {
        LoadSavedSceneElements();
        instance = this;
    }

    private void LoadSavedSceneElements() {
        string file = Application.persistentDataPath + @"/sceneFile.txt";
        string content;
        try {
            if (File.Exists(file)) {
                //Opening a text file and reading the whole content
                using (TextReader tr = File.OpenText(file)) {
                    content = tr.ReadToEnd();
                    string[] lines = content.Split("\n");
                    foreach (string line in lines)
                        readSceneUpdate(line);
                }
            }
        } catch(Exception e) {
            GameManager.instance.DebugText(e.Message);
        }
    }

    public void SaveScene() {
        TextWriter tw = new StreamWriter(Application.persistentDataPath + @"/sceneFile.txt");
        for (int i = 0; i < transform.childCount; i++) {
            Transform t = transform.GetChild(i);
            saveSceneElement(tw, t);
        }
        saveSceneElement(tw, transform);
        tw.Close();
    }

    private void saveSceneElement(TextWriter tw, Transform t) {
        string name = t.gameObject.name;
        if (t == transform) name = "this";
        Vector3 v = t.localPosition;
        Vector3 r = t.localEulerAngles;
        tw.WriteLine(name + " " +
            v.x.ToString(CultureInfo.InvariantCulture) + " " + v.y.ToString(CultureInfo.InvariantCulture)
            + " " + v.z.ToString(CultureInfo.InvariantCulture) + " " +
            r.x.ToString(CultureInfo.InvariantCulture) + " " + r.y.ToString(CultureInfo.InvariantCulture) + " " + r.z.ToString(CultureInfo.InvariantCulture));
    }

    private void readSceneUpdate(string line) {
        string[] args = line.Split(" ");
        if (args.Length < 7) return;
        Transform element;
        if (args[0] == "this")
            element = transform;
        else
            element = transform.Find(args[0]);
        if (element == null) return;
        float x = float.Parse(args[1], CultureInfo.InvariantCulture);
        float y = float.Parse(args[2], CultureInfo.InvariantCulture);
        float z = float.Parse(args[3], CultureInfo.InvariantCulture);
        float rx = float.Parse(args[4], CultureInfo.InvariantCulture);
        float ry = float.Parse(args[5], CultureInfo.InvariantCulture);
        float rz = float.Parse(args[6], CultureInfo.InvariantCulture);

        element.localPosition = new Vector3(x, y, z);
        element.localEulerAngles = new Vector3(rx, ry, rz);
    }
    public void ShowChild(string name, bool show) {
        Transform child = transform.Find(name);
        if (child != null)
            child.gameObject.SetActive(show);
    }

    public GameObject GetChild(string name) {
        Transform child = transform.Find(name);
        if (child != null)
            return child.gameObject;
        return null;
    }

    public void Exec(string cmd) {
        string[] args = cmd.Split(' ');
        if (args[0] == "") return;
        Debug.Log("args0 '" + args[0] + "'");
        Debug.Log("args1 '" + args[1] + "'");
        switch (args[0].Trim()) {
            case "show":
                ShowChild(args[1].Trim(), true);
                break;
            case "hide":
                ShowChild(args[1].Trim(), false);
                break;
            case "pos":
                Transform t = transform.Find(args[1]);
                float x = float.Parse(args[2], CultureInfo.InvariantCulture);
                float y = float.Parse(args[3], CultureInfo.InvariantCulture);
                float z = float.Parse(args[4], CultureInfo.InvariantCulture);
                t.localPosition = new Vector3(x, y, z);
                break;
        }
    }
}
