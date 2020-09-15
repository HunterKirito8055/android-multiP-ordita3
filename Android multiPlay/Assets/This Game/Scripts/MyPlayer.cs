using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    public float MoveSpeed = 3f;
    public float smoothRotationTime = 5f;
    public float SmoothSpeedMove = 5f;

   // public Transform cameraTrans;

    float rotateVelocity;

    float currentSpeed;
    float speedVelocity;
    public bool MobileInputs = false;

    FixedJoystick joystick;

    private void Start()
    {
     
    }
    void Update()
    {
        Vector3 input = Vector3.zero;
        if (MobileInputs)
        {
             input = new Vector3(Input.GetAxis("Joystick X"), Input.GetAxis("Joystick Y"));
        }
        else
        {
            input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        Vector3 inputDir = input.normalized;

        if (inputDir != Vector3.zero)
        {
            /*  this bellow mathf.atan2 gives radians only*/
            float angle = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

            // vector3 UP becos we want to rotate on Y-Axix
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref rotateVelocity, smoothRotationTime * Time.smoothDeltaTime);
        }

        float target = MoveSpeed * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, target, ref speedVelocity, SmoothSpeedMove * Time.smoothDeltaTime);

        transform.Translate(transform.forward * currentSpeed * Time.smoothDeltaTime, Space.World);

        // print(transform.forward);
        // print(currentSpeed);
    }
}

