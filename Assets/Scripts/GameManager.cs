using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public GameObject P1WinText;
    public GameObject P2WinText;
    public Text restartText;
    public Text gameOverText;
    bool gameOver;
    bool restart;

    public bool player1win = false; 
    // Start is called before the first frame update
    void Awake() {
        if (instance == null) 
            instance = this;
        else if (instance != null)
            Destroy (gameObject);

    }

    void Start() {
        gameOver = false;
        restart = false;
    }

    public void Win() {
        if( player1win) {
            P1WinText.SetActive(true);
        }
        else {
            P2WinText.SetActive(true);
        }
        
    }

    
}
