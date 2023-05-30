using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Google.XR.ARCoreExtensions.Samples.PersistentCloudAnchors;
using UnityEngine.XR.ARFoundation;
using BrainCheck;
using System.IO;
using System;

public class GameManager : MonoBehaviour {

    //outside a05 ua-a26ce7488f8920b29c09d821c5a4f612
    //inside a05 ua-856f33d9bc54bdd8d28f36f03ace3c07
    //outside a05 -365 (I hope) ua-f67be25dc80a605e02e04c6153435b03
    private string id = "ua-f67be25dc80a605e02e04c6153435b03";
    public PersistentCloudAnchorsController pcc;
    public static GameManager instance;
    public Text userMsg;
    private Console console;
    private Transform cloudAnchor;
    public GameObject scene;
    public GameObject talkButton;
    private ARAgent agent;
    private string userMessage="";
    private ARSceneManager sceneManager;
    
    public enum AppMode { play, edit, host };
    public AppMode appMode = AppMode.play;

    // Start is called before the first frame update
    void Start()
    {
        console = GetComponent<Console>();
        instance = this;
        talkButton.SetActive(false);
        userMsg.transform.parent.gameObject.SetActive(false);
        ReadAnchor();


        //SpeechRecognitionBridge.requestMicPermission();
    }

    public void SetAgent(ARAgent agent) {
        this.agent = agent;
        console.AddText("have agent!");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void TalkToMe() {
        SpeechRecognitionBridge.setUnityGameObjectNameAndMethodName("Game", "CallbackMethod");
        SpeechRecognitionBridge.speechToTextInHidenModeWithBeepSound();
        userMsg.transform.parent.gameObject.SetActive(true);
        userMsg.text = "";
        talkButton.SetActive(false);
    }

    private void reply(string userTxt) {
        string[] answers = agent.Chat(userTxt);
        SpeechRecognitionBridge.textToSpeech(answers[0], 0);
        console.AddText("reply: " + answers[0]);
        if (answers.Length > 0) {
            for (int i = 1; i < (answers.Length-1); i++) {
                sceneManager.Exec(answers[i]);
            }
        }
    }
    public void CallbackMethod(string messages) {
        if (messages.Equals("SpeechRecognitionFinished")) {
            console.AddText("**" + messages);
            console.AddText("you said: " + userMessage);
            reply(userMessage);
        }
        else if(messages.Equals("SpeechToTextCompleted")) {
            console.AddText("**" + messages);
        }
        else if (messages.Equals("TextToSpeechConversionStarted")) {
            console.AddText("**" + messages);
            agent.TriggerAnim("startTalking");
        }
        else if (messages.Equals("TextToSpeechConversionCompleted")) {
            console.AddText("**" + messages);
            agent.TriggerAnim("stopTalking");
            userMsg.transform.parent.gameObject.SetActive(false);
            talkButton.SetActive(true);
        }
        else {
            userMessage = messages;
            userMsg.text = userMessage;
        }
    }

    public void SetCloudAnchor(Transform anchor) {
        cloudAnchor = anchor;
    }
    public void SetMode(string mode) {
        switch(mode) {
            case "resolve":
                pcc.StartARResolving(id);
                break;
            case "start":
                console.AddText("starting!");
                if(cloudAnchor!=null) {
                    console.AddText("adding agent!");
                    GameObject sceneObj = Instantiate(scene, cloudAnchor);
                    sceneManager = sceneObj.GetComponent<ARSceneManager>();
                    if (appMode == AppMode.play) {
                        GameObject agentGo = sceneManager.GetChild("aggy");
                        if (agentGo != null) SetAgent(agentGo.GetComponent<ARAgent>());
                        talkButton.SetActive(true);
                    }
                }
                break;
        }
    }

    public void DebugText(string txt) {
        console.AddText("DEBUG: " + txt);
    }

    private void ReadAnchor() {
        string file = Application.persistentDataPath + @"/currentAnchor.txt";
        try {
            if (File.Exists(file)) {
                using (TextReader tr = File.OpenText(file)) {
                    id = tr.ReadToEnd();
                }
            }
        }
        catch (Exception e) {
            DebugText(e.Message);
        }
    }
    public void SaveAnchor(string anchorID) {
        TextWriter tw = new StreamWriter(Application.persistentDataPath + @"/currentAnchor.txt");
        tw.Write(anchorID);
        tw.Close();
        console.AddText("added anchor " + anchorID);
    }
}
