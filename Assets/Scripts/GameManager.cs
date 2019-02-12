using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public GameObject P1WinText;
    public GameObject P2WinText;
    
    public float resetDelay;

    public bool player1win = false; 
    // Start is called before the first frame update
    void Awake() {
        if (instance == null) 
            instance = this;
        else if (instance != null)
            Destroy (gameObject);
    }

    public void Win() {
        if( player1win) {
            P1WinText.SetActive(true);
        }
        else {
            P2WinText.SetActive(true);
        }
        Time.timeScale = 0.5f;
        Invoke ("Reset", resetDelay);
        
    }

    void Reset() {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SampleScene");
        Score1.scoreValue = 0;
        Score2.scoreValue = 0;
    }

    
}
