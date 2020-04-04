using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    float xMinimum;
    float xMaximum;

    float yMinimum;
    float yMaximum;

    // Start is called before the first frame update
    void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        var newXPosition = transform.position.x + deltaX;
        var newYPosition = transform.position.y + deltaY;

        transform.position = new Vector2(newXPosition, newYPosition);
    }
}
