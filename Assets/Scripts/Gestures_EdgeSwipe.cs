using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class Gestures_EdgeSwipe : MonoBehaviour
{
    [SerializeField] GameObject square;
    [SerializeField] float edgeWidth = 50f; // pixels from edge
    [SerializeField] float minSwipeDistance = 100f; // minimum swipe

    Vector2 startPos;
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

        if (touch1.phase == UnityEngine.InputSystem.TouchPhase.Began)
        {
            startPos = touch1.screenPosition;



            // Only start swipe if finger starts near left edge/ for right you can do Screen.width
            if (startPos.x <= edgeWidth)
            {
                isSwiping = true;
            }
        }

        if (isSwiping && touch1.phase == UnityEngine.InputSystem.TouchPhase.Ended)
        {
            Vector2 delta = touch1.screenPosition - startPos;
            if (delta.magnitude >= minSwipeDistance)
            {
                // Edge swipe detected
                square.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
            }

            isSwiping = false;
        }
    }
}
