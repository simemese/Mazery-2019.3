using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;

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

        transform.position = new Vector3(newXPosition, newYPosition,0);
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
