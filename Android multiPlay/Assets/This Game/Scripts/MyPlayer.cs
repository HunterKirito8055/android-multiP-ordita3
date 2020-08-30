using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    public float MoveSpeed = 3f;
    public float smoothRotationTime = 5f;
    public float SmoothSpeedMove = 1f;
    
    float rotateVelocity;

    float currentSpeed;
    float speedVelocity;

   

    private void Start()
    {

    }
    void Update()
    {
        //Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //Vector2 inputDir = input.normalized;

        //if (inputDir != Vector2.zero)
        //{ 
        //    float rotation =  Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
        //    transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref currentVeclocity, smoothRotationTime);
        //}
        //float tragetSpeed = MoveSpeed * inputDir.magnitude;
        //currentSpeed = Mathf.SmoothDamp(currentSpeed, tragetSpeed, ref speedVelocity, 0.1f);

        //transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            float angle = Mathf.Atan2(inputDir.x, inputDir.y) /*  <<== gives radians only*/  * Mathf.Rad2Deg;

            // vector3 UP becos we want to rotate on Y-Axix
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref rotateVelocity, smoothRotationTime * Time.smoothDeltaTime);
        }

        float target = MoveSpeed * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, target, ref speedVelocity,SmoothSpeedMove*Time.smoothDeltaTime );

        transform.Translate(transform.forward * currentSpeed  * Time.smoothDeltaTime, Space.World);

       // print(transform.forward);
       // print(currentSpeed);
    } 
}

