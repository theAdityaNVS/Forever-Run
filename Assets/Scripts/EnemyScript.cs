﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    void Update()
    {
        transform.Translate(0, 0, -15f * Time.deltaTime);
        if(transform.localPosition.z <= -50f)
        {
            Destroy(this.gameObject);
        }
    }
}
