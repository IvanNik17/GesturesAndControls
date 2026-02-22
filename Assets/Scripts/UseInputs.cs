using UnityEngine;
using UnityEngine.InputSystem;

public class UseInputs : MonoBehaviour
{

    [SerializeField] GameObject squarePlayer;
    [SerializeField] InputActionAsset inputActions;

    [SerializeField] float speedMove;
    [SerializeField] float speedLook;

    InputActionMap playerMap;



    Vector2 moveAmt;
    Vector2 lookAmt;

    private void Awake()
    {
        playerMap = inputActions.FindActionMap("Player");

    }

    private void OnEnable()
    {
        playerMap.Enable();
    }

    private void OnDisable()
    {
        playerMap.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveAmt = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookAmt = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        
        if (context.performed)
        {
            ChangeColor();
        }
    }

    void Update()
    {
        Move();
        Look();
    }



    void Move()
    {
        squarePlayer.transform.position +=
            squarePlayer.transform.up * moveAmt.y * speedMove * Time.deltaTime +
            squarePlayer.transform.right * moveAmt.x * speedMove * Time.deltaTime;
    }

    void Look()
    {
        float rotationCurr = -lookAmt.x * speedLook * Time.deltaTime;
        squarePlayer.transform.Rotate(0f, 0f, rotationCurr);
    }


    void ChangeColor()
    {
        squarePlayer.GetComponent<SpriteRenderer>().color =
            Random.ColorHSV();
    }


}
