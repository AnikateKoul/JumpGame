using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrangeCollector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public string[] orangeNames;

    void Start()
    {
        for (int i = 0; i < orangeNames.Length; i++)
        {
            int x = 0;
            if(PlayerPrefs.HasKey(orangeNames[i])) x = PlayerPrefs.GetInt(orangeNames[i]);
            if(x == 0) continue;
            GameObject go = GameObject.Find(orangeNames[i]);
            if (go)
            {
                Destroy(go.gameObject);
                Debug.Log(name + "has been destroyed.");
            }
        }
    }
}

