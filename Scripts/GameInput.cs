using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler<OnClickArgs> OnClick;
    public class OnClickArgs : EventArgs
    {
        public Vector3 mousePos;
    }
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

    private void PlayerInput_Click(InputAction.CallbackContext context)
    {
        Vector3 pos = mouse.position.ReadValue();
        OnClick?.Invoke(this, new OnClickArgs
        {
            mousePos = pos
        });
    }

    public Vector3 GetMousePosition()
    {
        return mouse.position.ReadValue();
    }
}
