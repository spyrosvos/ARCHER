using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class ARAgent : MonoBehaviour {
    private Animator animator;

    ChatbotMobileWeb bot;
    private TextAsset[] aimlFiles;
    private List<string> aimlXmlDocumentListFileName = new List<string>();
    private List<XmlDocument> aimlXmlDocumentList = new List<XmlDocument>();
    private TextAsset GlobalSettings, GenderSubstitutions, Person2Substitutions, PersonSubstitutions, Substitutions, DefaultPredicates, Splitters;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        //GameManager.instance.SetAgent(this);

        //init AIML capabilities
        bot = new ChatbotMobileWeb();
        LoadFilesFromConfigFolder();
        bot.LoadSettings(GlobalSettings.text, GenderSubstitutions.text, Person2Substitutions.text, PersonSubstitutions.text, Substitutions.text, DefaultPredicates.text, Splitters.text);
        TextAssetToXmlDocumentAIMLFiles();
        bot.loadAIMLFromXML(aimlXmlDocumentList.ToArray(), aimlXmlDocumentListFileName.ToArray());
        bot.LoadBrain();
    }
    void LoadFilesFromConfigFolder() {
        GlobalSettings = Resources.Load<TextAsset>("config/Settings");
        GenderSubstitutions = Resources.Load<TextAsset>("config/GenderSubstitutions");
        Person2Substitutions = Resources.Load<TextAsset>("config/Person2Substitutions");
        PersonSubstitutions = Resources.Load<TextAsset>("config/PersonSubstitutions");
        Substitutions = Resources.Load<TextAsset>("config/Substitutions");
        DefaultPredicates = Resources.Load<TextAsset>("config/DefaultPredicates");
        Splitters = Resources.Load<TextAsset>("config/Splitters");
    }

    void TextAssetToXmlDocumentAIMLFiles() {
        aimlFiles = Resources.LoadAll<TextAsset>("aiml");
        foreach (TextAsset aimlFile in aimlFiles) {
            try {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(aimlFile.text);
                aimlXmlDocumentListFileName.Add(aimlFile.name);
                aimlXmlDocumentList.Add(xmlDoc);
            }
            catch (System.Exception e) {
                Debug.LogWarning(e.ToString());
            }
        }
    }

    public void TriggerAnim(string trigger) {
        animator.SetTrigger(trigger);
    }

    public string[] Chat(string userMessage) {
        var answer = bot.getOutput(userMessage);
        string[] args = answer.Split("$");
        return args;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
