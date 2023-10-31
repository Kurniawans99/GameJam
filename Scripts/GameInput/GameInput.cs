using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnClick;

    private PlayerInput playerInput;
    private Mouse mouse;

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();
        mouse = Mouse.current;
    }

    private void Start()
    {
        playerInput.Player.Click.performed += PlayerInput_Click;
    }

    private void OnDestroy()
    {
        playerInput.Player.Click.performed -= PlayerInput_Click;

        playerInput.Dispose();

    }

    private void PlayerInput_Click(InputAction.CallbackContext context)
    {
        OnClick?.Invoke(this, EventArgs.Empty);
    }

    public Vector3 GetMousePosition()
    {
        return mouse.position.ReadValue();
    }
}
