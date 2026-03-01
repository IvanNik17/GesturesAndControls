using UnityEngine;
using UnityEngine.InputSystem;
using gyro = UnityEngine.InputSystem.Gyroscope;

public class Sensors_Gyroscope : MonoBehaviour
{

    public float rotationSpeed = 50f;
    public GameObject player;
    

    void Awake()
    {
        if (gyro.current != null)
            InputSystem.EnableDevice(gyro.current);
            

    }



    void Update()
    {
        if (gyro.current != null)
        {
            Vector3 rotationRate = gyro.current.angularVelocity.ReadValue();

            Debug.Log("Rotation Rate: " + rotationRate);


            


            Vector3 rotationDegrees = rotationRate * Mathf.Rad2Deg;


            player.transform.Rotate(0f, 0f, -rotationDegrees.z * rotationSpeed * Time.deltaTime);


            player.transform.Translate(rotationDegrees.x, rotationDegrees.y, 0f * Time.deltaTime);


        }
    }
}
