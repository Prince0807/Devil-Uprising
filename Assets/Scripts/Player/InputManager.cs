using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerInput playerInput;
    PlayerInput.OnFootActions onFoot;

    // References
    private PlayerMovementController playerMovementController;
    private PlayerCameraController playerCameraController;
    private WeaponsManager weaponsManager;

    private void Awake()
    {
        // Initialize components
        playerMovementController = GetComponent<PlayerMovementController>();
        playerCameraController = GetComponent<PlayerCameraController>();
        weaponsManager = GetComponentInChildren<WeaponsManager>();

        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        // Link input events to methods in other classes
        onFoot.Jump.performed += ctx => playerMovementController.Jump();
        onFoot.Crouch.performed += ctx => playerMovementController.Crouch();
        onFoot.Sprint.performed += ctx => playerMovementController.Sprint();
        onFoot.Fire.performed += ctx => weaponsManager.Attack();
        onFoot.Fire.canceled += ctx => weaponsManager.StopAttack();
        onFoot.Reload.performed += ctx => weaponsManager.Reload();
        onFoot.SelectWeapon1.performed += ctx => weaponsManager.SwitchWeapon(0);
        onFoot.SelectWeapon2.performed += ctx => weaponsManager.SwitchWeapon(1);
    }

    private void FixedUpdate()
    {
        playerMovementController.ProcessMovement(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        playerCameraController.ProcessCameraMovement(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
