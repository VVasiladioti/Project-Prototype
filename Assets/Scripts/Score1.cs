﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score1 : MonoBehaviour {
     
    public static int scoreValue = 0; 
    Text score1;
    // Start is called before the first frame update
    void Start() {
        score1 = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update() {
        score1.text = "Score: " + scoreValue;
        if (scoreValue == 10) {
            GameManager.instance.player1win = true;
            GameManager.instance.Win();
        }
    }

}
