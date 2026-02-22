using UnityEngine;
using UnityEngine.InputSystem;

public class UserInputs_Architecture2 : MonoBehaviour
{
    [SerializeField] GameObject squarePlayer;
    [SerializeField] InputActionAsset inputActions;
    [SerializeField] float moveSpeed;
    [SerializeField] float lookSpeed;

    InputAction move;
    InputAction look;
    InputAction attack;

    void Awake()
    {
        InputActionMap map = inputActions.FindActionMap("Player");
        move = map.FindAction("Move");
        look = map.FindAction("Look");
        attack = map.FindAction("Attack");
    }

    void OnEnable()
    {
        move.Enable();
        look.Enable();
        attack.Enable();
    }

    void OnDisable()
    {
        move.Disable();
        look.Disable();
        attack.Disable();
    }

    void Update()
    {
        Vector2 moveInput = move.ReadValue<Vector2>();
        Vector2 lookInput = look.ReadValue<Vector2>();

        Move(moveInput);
        Rotate(lookInput);

        if (attack.triggered)
            ChangeColor();
    }

    void Move(Vector2 input)
    {
        squarePlayer.transform.position +=
            squarePlayer.transform.up * input.y * moveSpeed * Time.deltaTime +
            squarePlayer.transform.right * input.x * moveSpeed * Time.deltaTime;
    }

    void Rotate(Vector2 input)
    {
        float rot = -input.x * lookSpeed * Time.deltaTime;
        squarePlayer.transform.Rotate(0, 0, rot);
    }

    void ChangeColor()
    {
        squarePlayer.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
    }
}
