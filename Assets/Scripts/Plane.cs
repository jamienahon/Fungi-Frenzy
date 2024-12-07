using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float moveSpeed;
    public GameObject planePrefab;
    public Spawner spawner;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(-transform.forward * moveSpeed * Time.deltaTime);
        if (transform.position.z <= -35)
        {
            GameObject plane = Instantiate(planePrefab);
            moveSpeed = spawner.speed;
        }
    }
}
