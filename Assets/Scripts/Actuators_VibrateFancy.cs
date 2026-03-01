using UnityEngine;
using UnityEngine.InputSystem;

public class Actuators_VibrateFancy : MonoBehaviour
{
    bool hasVibrated = false;
    void Update()
    {



        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            if (!hasVibrated)
            {
                // Example: simple 0.5s vibration
                //Vibrate(500);

                // Example: custom vibration pattern
                long[] pattern = { 100, 300, 100, 500 }; // wait 0.1s, vibrate 0.3s, wait 0.1s, vibrate 0.5s
                VibrationHelper.VibratePattern(pattern, -1);

                hasVibrated = true;
            }
        }
        else
        {
            hasVibrated = false; // reset when touch ends
        }
    }
}
