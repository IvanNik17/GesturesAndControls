using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class Gestures_LongPress : MonoBehaviour
{
    [SerializeField] GameObject square;
    [SerializeField] float holdTime = 0.5f; // seconds to trigger

    float pressStartTime;
    bool isPressing = false;
    bool longPressTriggered = false;

    void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    void Update()
    {
        if (touch.activeTouches.Count < 1)
        {
            isPressing = false;
            longPressTriggered = false;
            return;
        }

        var touch1 = touch.activeTouches[0];

        if (touch1.phase == UnityEngine.InputSystem.TouchPhase.Began)
        {
            pressStartTime = Time.time;
            isPressing = true;
            longPressTriggered = false;
        }

        if (isPressing && touch1.phase == UnityEngine.InputSystem.TouchPhase.Stationary)
        {
            if (!longPressTriggered && (Time.time - pressStartTime >= holdTime))
            {
                // Long press detected
                square.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
                longPressTriggered = true;
            }
        }

        if (touch1.phase == UnityEngine.InputSystem.TouchPhase.Ended || touch1.phase == UnityEngine.InputSystem.TouchPhase.Canceled)
        {
            isPressing = false;
            longPressTriggered = false;
        }
    }
}
