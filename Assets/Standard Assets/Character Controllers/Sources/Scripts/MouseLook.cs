using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour 
{

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float mouseSensitivityX = 15F;
	public float mouseSensitivityY = 15F;

    public float joySensitivityX = 3F;
    public float joySensitivityY = 3F;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	float rotationY = 0F;

	void Update ()
	{
        float Xon = Mathf.Abs(Input.GetAxis("Joystick X"));
        float Yon = Mathf.Abs(Input.GetAxis("Joystick Y"));

		if (axes == RotationAxes.MouseXAndY)
		{
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivityX;
			
			rotationY += Input.GetAxis("Mouse Y") * mouseSensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.MouseX)
		{
            if (Xon > .05)
            {
                transform.Rotate(0, Input.GetAxis("Joystick X") * joySensitivityX, 0);
            }
			transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSensitivityX, 0);
		}
		else
		{
            if (Yon > .05)
            {
                rotationY -= Input.GetAxis("Joystick Y") * joySensitivityY;
            }
			rotationY += Input.GetAxis("Mouse Y") * mouseSensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}
	}
	
	void Start ()
	{
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
	}
}