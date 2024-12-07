using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunk : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Quad");
    }

    void Update()
    {
        if (transform.position.x == 0)
        {
            if (transform.position.z <= -2)
            {
                Material material = GetComponent<Renderer>().material;
                material.color = new Color(material.color.r, material.color.b, material.color.g, 0.5f);
            }
        }
    }
}
