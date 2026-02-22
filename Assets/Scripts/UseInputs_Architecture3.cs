using UnityEngine;
using UnityEngine.InputSystem;
public class UseInputs_Architecture3 : MonoBehaviour
{
    [SerializeField] GameObject squarePlayer;
    [SerializeField] float moveSpeed;
    [SerializeField] float lookSpeed;

    InputSystem_Actions controls;

    Vector2 moveInput;
    Vector2 lookInput;

    void Awake()
    {
        controls = new InputSystem_Actions();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        controls.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        controls.Player.Look.canceled += ctx => lookInput = Vector2.zero;

        controls.Player.Attack.performed += ctx => ChangeColor();
    }

    void OnEnable() => controls.Enable();
    void OnDisable() => controls.Disable();

    void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        squarePlayer.transform.position +=
            squarePlayer.transform.up * moveInput.y * moveSpeed * Time.deltaTime +
            squarePlayer.transform.right * moveInput.x * moveSpeed * Time.deltaTime;
    }

    void Rotate()
    {
        float rot = -lookInput.x * lookSpeed * Time.deltaTime;
        squarePlayer.transform.Rotate(0, 0, rot);
    }

    void ChangeColor()
    {
        squarePlayer.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
    }
}
