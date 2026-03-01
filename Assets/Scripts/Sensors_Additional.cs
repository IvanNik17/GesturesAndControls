using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Sensors_Additional : MonoBehaviour
{
    public TextMeshProUGUI sensorText;

    void OnEnable()
    {
        EnableSensor(ProximitySensor.current);
        EnableSensor(LightSensor.current);
        EnableSensor(MagneticFieldSensor.current);
        EnableSensor(PressureSensor.current);
        EnableSensor(HumiditySensor.current);
        EnableSensor(AmbientTemperatureSensor.current);
        EnableSensor(StepCounter.current);
    }

    void OnDisable()
    {
        DisableSensor(ProximitySensor.current);
        DisableSensor(LightSensor.current);
        DisableSensor(MagneticFieldSensor.current);
        DisableSensor(PressureSensor.current);
        DisableSensor(HumiditySensor.current);
        DisableSensor(AmbientTemperatureSensor.current);
        DisableSensor(StepCounter.current);
    }

    void EnableSensor(InputDevice device)
    {
        if (device != null)
            InputSystem.EnableDevice(device);
    }

    void DisableSensor(InputDevice device)
    {
        if (device != null)
            InputSystem.DisableDevice(device);
    }

    void Start()
    {
        Debug.Log("=== InputSystem Devices ===");
        foreach (var device in InputSystem.devices)
        {
            Debug.Log($"Device: {device.displayName} | Type: {device.GetType()} | Enabled: {device.enabled}");
        }
    }

    void Update()
    {
        if (sensorText == null) return;

        string info = "";

        // Gyroscope
        if (UnityEngine.InputSystem.Gyroscope.current != null)
        {
            var gyro = UnityEngine.InputSystem.Gyroscope.current.angularVelocity.ReadValue();
            info += $"Gyro (angularVelocity): {gyro}\n";
        }

        // Accelerometer
        if (UnityEngine.InputSystem.Accelerometer.current != null)
        {
            var accel = UnityEngine.InputSystem.Accelerometer.current.acceleration.ReadValue();
            info += $"Accelerometer: {accel}\n";
        }

        // Proximity
        if (UnityEngine.InputSystem.ProximitySensor.current != null)
        {
            var prox = UnityEngine.InputSystem.ProximitySensor.current.distance.ReadValue();
            info += $"Proximity: {prox}\n";
        }

        // Light
        if (UnityEngine.InputSystem.LightSensor.current != null)
        {
            var light = UnityEngine.InputSystem.LightSensor.current.lightLevel.ReadValue();
            info += $"Light: {light}\n";
        }

        // Pressure
        if (UnityEngine.InputSystem.PressureSensor.current != null)
        {
            var pres = UnityEngine.InputSystem.PressureSensor.current.atmosphericPressure.ReadValue();
            info += $"Pressure: {pres}\n";
        }

        // Magnetic Field
        if (UnityEngine.InputSystem.MagneticFieldSensor.current != null)
        {
            var mag = UnityEngine.InputSystem.MagneticFieldSensor.current.magneticField.ReadValue();
            info += $"MagneticField: {mag}\n";
        }

        // Step Counter
        if (UnityEngine.InputSystem.StepCounter.current != null)
        {
            var steps = UnityEngine.InputSystem.StepCounter.current.stepCounter.ReadValue();
            info += $"Steps: {steps}\n";
        }

        // Write to TMP
        sensorText.text = info;
    }

}
