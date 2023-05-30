using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Console : MonoBehaviour {
    private string header = "--- Debug Console ---\n[F1] to show / hide, new messages come first\n+\n";
    private string text="";

    public int TopX=25, TopY=25, Width=400, Height=250;
    public Color color = Color.green;
    private bool showing = true;

    public void Start() {
    }
    private void OnGUI() {
        if (showing) {
            //GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
            //myButtonStyle.fontSize = 30;
            GUI.color = color;
            GUI.TextArea(new Rect(TopX, TopY, Width, Height), header+text/*, myButtonStyle*/);
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.F1)) showing = !showing;
    }
    public void AddText(string newText) {
        text= "[" + Time.time.ToString("0000.0",CultureInfo.InvariantCulture) + "]: "+newText+"\n"+text;
    }
}
