using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectCherrySoundEffect;
    public static int[] Scores = new int[5]; 
    private int cherries = 0;
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Cherry")) {
            collectCherrySoundEffect.Play();
            Destroy(collision.gameObject);
            Scores[SceneManager.GetActiveScene().buildIndex - 1]++;
            cherries++;
            // Debug.Log("Cherries : " + cherries);
            cherriesText.text = "Cherries : " + cherries;
        }
    }
}
