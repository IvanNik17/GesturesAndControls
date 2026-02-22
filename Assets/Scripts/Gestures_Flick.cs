using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class Gestures_Flick : MonoBehaviour
{
    [SerializeField] GameObject square;
    [SerializeField] float flickThreshold = 3000f; // pixels per second

    Vector2 previousPosition;
    float previousTime;
    bool startedTracking = false;

    void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    void Update()
    {
        if (touch.activeTouches.Count < 1)
        {
            startedTracking = false;
            return;
        }

        var touch1 = touch.activeTouches[0];

        // Only track during moving phase
        if (touch1.phase == UnityEngine.InputSystem.TouchPhase.Began)
        {
            previousPosition = touch1.screenPosition;
            previousTime = Time.time;
            startedTracking = true;
        }

        if (touch1.phase == UnityEngine.InputSystem.TouchPhase.Moved && startedTracking)
        {
            float deltaTime = Time.time - previousTime;
            Vector2 deltaPos = touch1.screenPosition - previousPosition;
            Vector2 velocity = deltaPos / deltaTime; // pixels per second

            if (velocity.magnitude > flickThreshold)
            {
                // Flick detected!
                Debug.Log(velocity.magnitude);
                square.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
            }

            previousPosition = touch1.screenPosition;
            previousTime = Time.time;
        }

        if (touch1.phase == UnityEngine.InputSystem.TouchPhase.Ended || touch1.phase == UnityEngine.InputSystem.TouchPhase.Canceled)
        {
            startedTracking = false;
        }
    }
}
