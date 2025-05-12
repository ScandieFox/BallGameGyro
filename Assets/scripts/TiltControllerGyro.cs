using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltControllerGyro : MonoBehaviour
{
    public Vector3 TargetRot;
    public int speed = 10;
    public bool useGyro = true;   // Toggle to enable/disable gyro controls

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        TargetRot = Vector3.zero;

        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
        else
        {
            Debug.LogWarning("Gyroscope not supported on this device");
            useGyro = false;
        }
    }

    void FixedUpdate()
    {
        if (useGyro && Input.gyro.enabled)
        {
            // Get gravity vector from the phone (relative to Earth's gravity)
            Vector3 gravity = Input.gyro.gravity;

            // Map phone tilt to board tilt
            // gravity.x → tilt left/right (maps to Z axis rotation)
            // gravity.y → tilt forward/back (maps to X axis rotation)

            // Flip signs or swap axes as needed based on testing
            TargetRot.x = Mathf.Clamp(gravity.y * -90f, -25f, 25f);  // Forward/Backward tilt
            TargetRot.z = Mathf.Clamp(gravity.x * 90f, -25f, 25f);   // Left/Right tilt
        }
        else
        {
            // Fallback to keyboard input if gyro is off
            TargetRot.x += Input.GetAxis("Vertical") * Time.deltaTime * speed;
            TargetRot.z += Input.GetAxis("Horizontal") * Time.deltaTime * speed;

            // Clamp
            TargetRot.x = Mathf.Clamp(TargetRot.x, -25f, 25f);
            TargetRot.z = Mathf.Clamp(TargetRot.z, -25f, 25f);
        }

        transform.rotation = Quaternion.Euler(TargetRot);
    }
}
