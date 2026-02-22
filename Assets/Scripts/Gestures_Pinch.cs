using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using touch = UnityEngine.InputSystem.EnhancedTouch.Touch;



public class Gestures_Pinch : MonoBehaviour
{

    [SerializeField] GameObject playerSquare;
    [SerializeField] float pinchSpeed = 0.005f;

    float previousDistance;
    bool isPinching;

    void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    void Update()
    {
        if (touch.activeTouches.Count < 2)
        {
            isPinching = false;
            return;
        }

        touch touch1 = touch.activeTouches[0];
        touch touch2 = touch.activeTouches[1];

        float currentDistance =
            Vector2.Distance(touch1.screenPosition, touch2.screenPosition);

        if (!isPinching)
        {
            previousDistance = currentDistance;
            isPinching = true;
            return;
        }

        float delta = currentDistance - previousDistance;

        ScaleObject(delta);

        previousDistance = currentDistance;
    }

    void ScaleObject(float delta)
    {
        float scaleAmount = delta * pinchSpeed;

        playerSquare.transform.localScale +=
            new Vector3(scaleAmount, scaleAmount, 0);

        // Optional clamp (recommended for students)
        float clamped = Mathf.Clamp(playerSquare.transform.localScale.x, 0.5f, 3f);
        playerSquare.transform.localScale =
            new Vector3(clamped, clamped, 1f);
    }
}
