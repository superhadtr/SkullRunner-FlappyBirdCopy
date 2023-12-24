using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesMovement : MonoBehaviour
{

    public static float speed;

    void Start()
    {
        speed = 1.5f;
    }


    void Update()
    {

        transform.position += Vector3.left * speed * Time.deltaTime;

    }
}
