using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class Gestures_MultiToch : MonoBehaviour
{
    [SerializeField] GameObject square;

    // Prevents repeated triggering while fingers are held down
    bool fourFingerActive = false;

    void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    void Update()
    {
        // Count active touches
        if (touch.activeTouches.Count == 4)
        {
            if (!fourFingerActive)
            {
                ChangeColor();
                fourFingerActive = true;
            }
        }
        else
        {
            // Reset flag when less than 4 fingers
            fourFingerActive = false;
        }
    }

    void ChangeColor()
    {
        square.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
    }
}
