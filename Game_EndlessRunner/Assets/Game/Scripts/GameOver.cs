using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("1:" + " " + other.name);
      //  if (other.name == "Wheel5")
        {
            Debug.Log("2");
            SceneManager.LoadScene(0);
        }
    }
    
    void Update()
    {
        
    }
}
