using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public Camera playerCamera;

    private float xRotation = 0f;
    
    [SerializeField] private float xSensitivity = 30f;
    [SerializeField] private float ySensitivity = 30f;
    [SerializeField] private float clampAngle = 60f;

    public void ProcessCameraMovement(Vector2 input)
    {
        // Calculate camera rotation for looking up & down.
        xRotation -= (input.y * Time.deltaTime) * ySensitivity;
        // Clamp rotation to stop rotating it endlessly
        xRotation = Mathf.Clamp(xRotation, -clampAngle, clampAngle);
        
        // Apply this rotation to Camera.
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate Player to look left & right.
        transform.Rotate(Vector3.up * input.x * Time.deltaTime * xSensitivity);
    }
}
