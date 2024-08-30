using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager
{
    private InputControls inputControls;

    public Vector2 Movement => inputControls.Player.Movement.ReadValue<Vector2>();

    public InputManager()
    {
        inputControls = new InputControls();
        inputControls.Enable();
        DisableInteraction();

        inputControls.Player.Interact.performed += OnInteractPerformed;
        inputControls.Player.Inventory.performed += OnInventoryPerformed;
    }


    void OnInteractPerformed(InputAction.CallbackContext context)
    {
        GameManager.Instance.OpenCloseShopUI();
    }
    private void OnInventoryPerformed(InputAction.CallbackContext context)
    {
        GameManager.Instance.OpenCloseInventory();
    }

    public void EnableMovement() => inputControls.Player.Movement.Enable();
    public void DisableMovement() => inputControls.Player.Movement.Disable();

    public void EnableInteraction() => inputControls.Player.Interact.Enable();
    public void DisableInteraction() => inputControls.Player.Interact.Disable();
}
