using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour
{
    [SerializeField] private Text myScore;
    
    void Start() {
        int val = 0;
        for(int i = 0; i < ItemCollector.Scores.Length; i++) {
            val += ItemCollector.Scores[i];
        }
        myScore.text = "You Score : " + val;
    }
    
}