using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCenter : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 50);
    }
}
