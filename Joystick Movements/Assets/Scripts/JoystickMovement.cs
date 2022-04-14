using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    public DynamicJoystick dynamicJoystick;
    public float speed = 0.0f;
    public float speedAc;
    public float speedDeAc;
    public float turnSpeed;
    public Animator animator;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (speed < 1.0f)
            {
                speed += speedAc * Time.deltaTime;
            }

            JoystickMove();
        }
        // if we decrease with deAccelaration
        if (!Input.GetMouseButton(0))
        {
            if (speed > 0.0f)
            {
                speed -= speedDeAc * Time.deltaTime;
            }
        }
        animator.SetFloat("Blend", speed);
    }


    public void JoystickMove()
    {
        float horizontalInput = dynamicJoystick.Horizontal;
        float verticalInput = dynamicJoystick.Vertical;


        
        Vector3 transformPosition = new Vector3(horizontalInput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime);
        transform.position += transformPosition;

        

        Vector3 direction = Vector3.forward * verticalInput + Vector3.right * horizontalInput;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
    }

}
