using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{       
    public float speed;

    void Update() {
        transform.position -= new Vector3(0, 0, speed);
    }
}
