using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePrefs : MonoBehaviour
{
    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All the data has been deleted");
    }

}
