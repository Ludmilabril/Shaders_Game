using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform personaje; 
    public Vector3 offset; 

    void Update()
    {
        if (personaje != null)
        {
            Vector3 newPosition = personaje.position + offset;
            newPosition.z = transform.position.z;
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 5f);
        }
    }
}
