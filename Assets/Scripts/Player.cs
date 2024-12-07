using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float gravity;
    public float jumpHeight;
    Vector3 moveDirection;

    public bool canJump;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y < 0.75f)
        {
            transform.position = new Vector3(transform.position.x, 0.75f, transform.position.z);
            canJump = true;
        }

        if(canJump)
        {
             if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpHeight;
                canJump = false;
            }
            else
                moveDirection.y = 0;
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        transform.Translate(moveDirection);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("aaa");
    }

}
