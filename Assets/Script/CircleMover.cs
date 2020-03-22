using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMover : MonoBehaviour
{
    public float speed = 15;

    int degree;
    
    //float x, y, z;

    void Start()
    {
        degree = Random.Range(0, 180);
        // degree = Random.Range(0, 180);
        transform.Rotate(0, 0, degree);

    }

    void Update()

    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6, 6), Mathf.Clamp(transform.position.y, -4, 4), 0);
       
        transform.Translate(speed * Time.deltaTime, 0, 0);
        degree = Random.Range(0, 180);


        if (transform.localPosition.x <= -6)
        {
            transform.Rotate(0, 0, degree);
        }

        if (6 <= transform.localPosition.x)
        {
            transform.Rotate(0, 0, degree);
        }

        if (transform.localPosition.y <= -4)
        {
            // Debug.Log("I am below the camera's view.");

            transform.Rotate(0, 0, degree);


        }

        if (4 <= transform.localPosition.y)
        {
            // Debug.Log("I am above the camera's view.");

            transform.Rotate(0, 0, degree);


        }

    }

}