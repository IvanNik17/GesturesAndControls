using UnityEngine;
using UnityEngine.InputSystem;

public class Sensors_Accelerometer : MonoBehaviour
{
    void Update()
    {
        if (Accelerometer.current != null)
        {
            Vector3 acceleration = Accelerometer.current.acceleration.ReadValue();

            Debug.Log("Acceleration: " + acceleration);
        }
    }
}
