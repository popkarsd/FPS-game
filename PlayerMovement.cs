using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
	// References
	public Rigidbody rb;
	public Transform tf_camera;

	// Variables
	double pi = Math.PI;
	public float forwardForce = 100f;
	public float sensitivity = 20f;

	void Start()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

	}

    // Update is called once per frame
    void FixedUpdate()
    {
    	

    	// Time
    	float time = Time.deltaTime;

    	// Calculation of force vector
    	float rotation_y = (float)tf_camera.eulerAngles.y;
    	float fz = (float)(forwardForce/Math.Sqrt(1+Math.Pow(Math.Tan(rotation_y * pi / 180),2)));
    	float fx = (float)(forwardForce/Math.Sqrt(1/Math.Pow(Math.Tan(rotation_y * pi / 180),2)+1));
   		
    	// Movement
        if ( Input.GetKey("w") )
        {
        	rb.AddForce(fx * time,0,fz * time);
        }
        if (Input.GetKey("s"))
        {
        	rb.AddForce(-fx * time,0,-fz * time);
        }
        if (Input.GetKey("d"))
        {
        	rb.AddForce(fz * time,0,-fx * time);
        }
        if (Input.GetKey("a"))
        {
        	rb.AddForce(-fz * time,0,fx * time);
        }
    }
}
