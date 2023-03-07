using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour
{
    public static int totalLives = 5;
    [SerializeField] private AudioSource LifeAudio;
    [SerializeField] private Text LivesText;
    public string orangeName;

    void Start() {
        LivesText.text = "Lives Left : " + totalLives;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Orange")) {
            orangeName = collision.gameObject.name;
            // collision.gameObject.transform.position = new Vector2(0, 200);
            // collision.gameObject.SetActive(false);
            PlayerPrefs.SetInt(orangeName, 1);
            Debug.Log(PlayerPrefs.GetInt(orangeName) + " has been saved");
            Destroy(collision.gameObject);
            totalLives++;
            LifeAudio.Play();
            LivesText.text = "Lives Left : " + totalLives;
        }
    }
    
}