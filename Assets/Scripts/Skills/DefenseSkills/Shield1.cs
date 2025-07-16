using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShield : MonoBehaviour
{
    public float duration = 3f;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
        Debug.Log("Shield activated!");
    }

    void Update()
    {
        if (Time.time - startTime >= duration)
        {
            Debug.Log("Shield deactivated!");
            Destroy(this);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Debug.Log("Shield blocked enemy bullet!");
            Destroy(other.gameObject);
        }
    }
}