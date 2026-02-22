using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class Gestures_Swipe : MonoBehaviour
{
    [SerializeField] GameObject playerSquare;
    [SerializeField] float swipeSpeed = 0.01f;

    Vector2 lastPosition;
    bool isSwiping = false;

    void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    void Update()
    {
        if (touch.activeTouches.Count < 1)
        {
            isSwiping = false;
            return;
        }

        var touch1 = touch.activeTouches[0];

        if (!isSwiping)
        {
            lastPosition = touch1.screenPosition;
            isSwiping = true;
            return;
        }

        Vector2 delta = touch1.screenPosition - lastPosition;

        
        playerSquare.transform.position += new Vector3(delta.x, delta.y, 0) * swipeSpeed;

        lastPosition = touch1.screenPosition;
    }
}
