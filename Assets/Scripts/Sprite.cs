using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite : MonoBehaviour
{
    public float speed;

    public GameObject lookAtTarget;

    void Update()
    {
        transform.Translate(-transform.forward * speed * Time.deltaTime);

        if (transform.position.z <= -10)
            Destroy(gameObject);
    }
}
