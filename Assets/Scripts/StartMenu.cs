using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public void StartGame() {
        PlayerPrefs.DeleteAll();
        Debug.Log("All the data has been deleted");
        for(int i = 0; i < ItemCollector.Scores.Length; i++) ItemCollector.Scores[i] = 0;
        LivesCounter.totalLives = 5;
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % 4);
    }
    
}
