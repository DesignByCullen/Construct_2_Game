using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class SpeechRecognitionEngine : MonoBehaviour
{
    public string[] keywords = { };
    public ConfidenceLevel confidence = ConfidenceLevel.Low;

    public GameObject _mainMenu;
    public GameObject _controlMenu;
    public GameObject _game;

    protected PhraseRecognizer keywordRecognizer;
    protected string word = "";

    private void Start()
    {
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
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        Debug.Log("text recognised = " + word);
    }

    private void Update()
    {
        switch (word)
        {
            case "play":
            case "start":
            case "play game":
            case "start game":
            case "go":
                _mainMenu.GetComponent<MainMenu>().PlayGame();
                break;
            case "close":
            case "quit":
            case "exit":
                _mainMenu.GetComponent<MainMenu>().QuitGame();
                break;
            case "controls":
                _controlMenu.SetActive(true);
                _mainMenu.SetActive(false);
                break;
            case "main menu":
            case "back":
                _controlMenu.SetActive(false);
                _mainMenu.SetActive(true);
                break;
                break;
            case "go to main menu":
            case "exit game":
                _game.GetComponent<MainMenu>().BackGame();
                break;


            default:
                break;

        }
        word = "";
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
    }
}
