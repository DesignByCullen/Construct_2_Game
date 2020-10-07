using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechRecognitionEngine_Grammar : MonoBehaviour
{
    public string[] keywords = {"play", "controls", "quit", "back" };
    public ConfidenceLevel confidence = ConfidenceLevel.Low;
    public float speed = 1;

    public Text results;
    public GameObject cube;
    private Material cubeMaterial;

    //protected GrammarRecognizer grammarRecognizer;
    protected PhraseRecognizer keywordRecognizer;
    protected string word = "";

    private void Start()
    {
        cubeMaterial = cube.GetComponent<Renderer>().material;

        //*********************************************
        if (keywordRecognizer != null && keywordRecognizer.IsRunning)
        {
            Debug.Log("keywordRecognizer already exists");
            keywordRecognizer.OnPhraseRecognized -= KeywordRecognizer_OnPhraseRecognized;
            keywordRecognizer.Stop();
            keywordRecognizer.Dispose();
        }
        if (keywords != null)
        {
            keywordRecognizer = new KeywordRecognizer(keywords, confidence);
            keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
            keywordRecognizer.Start();
        }
        //*********************************************

        //PhraseRecognitionSystem.OnError += PhraseRecognitionSystem_OnError;

        //if (grammarRecognizer != null && grammarRecognizer.IsRunning)
        //{
        //    Debug.Log("grammarRecognizer already exists");
        //    grammarRecognizer.OnPhraseRecognized -= GrammarRecognizer_OnPhraseRecognized;
        //    grammarRecognizer.Stop();
        //    grammarRecognizer.Dispose();
        //}

        //grammarRecognizer = new GrammarRecognizer(Application.streamingAssetsPath + "/SRGS/GrammarBasic.xml", confidence);
        //grammarRecognizer.OnPhraseRecognized += GrammarRecognizer_OnPhraseRecognized;
        //grammarRecognizer.Start();

        //if (grammarRecognizer.IsRunning)
        //    Debug.Log("Start - grammarRecognizer is running from file: " + grammarRecognizer.GrammarFilePath);
    }

    //private void PhraseRecognitionSystem_OnError(SpeechError errorCode)
    //{
    //    Debug.Log("errorCode =" + errorCode.ToString());
    //}

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        results.text = "You said: <b>" + word + "</b>";
    }

    //private void GrammarRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    //{
    //    word = args.text;
    //    SemanticMeaning[] meanings = args.semanticMeanings;

    //    Debug.Log("GrammarRecognizer_OnPhraseRecognized: " + word);
    //    Debug.Log("GrammarRecognizer_OnPhraseRecognized - meanings: " + meanings.Length);

    //    results.text = "You said: <b>" + word + "</b>";
    //}

    private void Update()
    {
        switch (word)
        {
            case "left":
                //cube.transform.
            case "up":
                cubeMaterial.color = Color.blue;
                break;
            case "red":
                cubeMaterial.color = Color.red;
                break;
            case "green":
                cubeMaterial.color = Color.green;
                break;
            case "yellow":
                cubeMaterial.color = Color.yellow;
                break;
            default:
                break;
        }
    }

    private void OnApplicationQuit()
    {
        //*********************************************
        if (keywordRecognizer != null && keywordRecognizer.IsRunning)
        {
            keywordRecognizer.OnPhraseRecognized -= KeywordRecognizer_OnPhraseRecognized;
            keywordRecognizer.Stop();
        }
        //*********************************************

        //if (grammarRecognizer != null && grammarRecognizer.IsRunning)
        //{
        //    grammarRecognizer.OnPhraseRecognized -= GrammarRecognizer_OnPhraseRecognized;
        //    grammarRecognizer.Stop();
        //}
    }
}
