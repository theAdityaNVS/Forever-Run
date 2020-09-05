using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform playerTransform;
    Vector3 distance;


    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        distance = this.transform.position - playerTransform.position;
    }


    void Update()
    {
        if (playerTransform != null)
        {
            //this.transform.position = playerTransform.position + distance;
            this.transform.position = Vector3.Lerp(this.transform.position, playerTransform.position + distance, 0.2f);
        }
    }
}
