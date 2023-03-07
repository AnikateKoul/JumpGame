using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private Text LivesText;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Trap")) {
            Die();
        }
    }

    private void Die() {
        deathSoundEffect.Play();
        ItemCollector.Scores[SceneManager.GetActiveScene().buildIndex - 1] = 0;
        LivesCounter.totalLives--;
        if(LivesCounter.totalLives < 0) {
            SceneManager.LoadScene(3);
        }
        LivesText.text = "Lives left : " + LivesCounter.totalLives;
        anim.SetTrigger("Death");
        rb.bodyType = RigidbodyType2D.Static;

    }

    private void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
