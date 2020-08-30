using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
  
    public float X_Pole;     //equall to Y-axis rotation in main camera
    
    public float  Y_Pole;    // //equall to X-axis rotation in main camera
    public float Camera_dist = 2f;
    
    public Vector2 Orbit_Sensitive = new Vector2(4f, -4f);

    public Transform targetbody;
    public Vector3 target_offset_Look = new Vector3(0, 0.85f, 0);

    Vector3 _cam_Position;
   

    private void Awake()
    {
        targetbody = GameObject.FindGameObjectWithTag("Player").transform;
        _cam_Position = Camera.main.transform.localPosition;
        
    }
    void Update()
    {
        X_Pole += Input.GetAxis("Mouse Y") * Orbit_Sensitive.y;
        Y_Pole += Input.GetAxis("Mouse X") * Orbit_Sensitive.x;

        Vector3 camRotate = new Vector3(X_Pole, Y_Pole);
        transform.eulerAngles = camRotate;


        transform.position = targetbody.position - transform.forward * Camera_dist;
      

        transform.LookAt(targetbody.position + target_offset_Look);
    }
}//class
