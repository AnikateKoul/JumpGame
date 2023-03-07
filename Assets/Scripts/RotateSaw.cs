using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSaw : MonoBehaviour
{
    [SerializeField] float speedRotate = 2;
    void Update()
    {
        transform.Rotate(0, 0, 360*speedRotate*Time.deltaTime);
    }

}
