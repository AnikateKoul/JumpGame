using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name == "Player") {
            collision.gameObject.transform.SetParent(transform);
        }
        Debug.Log("Trigger Enter");
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.name == "Player") {
            collision.gameObject.transform.SetParent(null);
        }
        Debug.Log("Trigger Exit");
    }
}
