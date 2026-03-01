using UnityEngine;
using UnityEngine.InputSystem;

public class Actuators_Vibrate : MonoBehaviour
{
    void Update()
    {
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
            Debug.Log("Vibrate");
            VibratePhone();
    }

    public void VibratePhone()
    {
        Handheld.Vibrate();
    }
}
