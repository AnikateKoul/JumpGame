using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource finishSoundEffect;
    private bool levelCompleted = false;
    private void OnTriggerEnter2D(Collider2D collision) {
        if((collision.gameObject.name == "Player") && (!levelCompleted)) {
            finishSoundEffect.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
