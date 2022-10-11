using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement: MonoBehaviour
{
    public float Speed = 2f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.forward);

        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.back);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }

        void Move(Vector3 Dir)
        {
            transform.Translate(Dir * Speed * Time.deltaTime);
        }
    }
}

