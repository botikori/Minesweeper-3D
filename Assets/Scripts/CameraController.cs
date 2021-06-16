using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 10.0f;
    [SerializeField] private float moveSpeed = 8.0f;
    [SerializeField] private float verticalSpeed = 5.0f;
    [SerializeField] private float maxTurnAngle = 90.0f;
    
    private float _rotX;

    private void Update()
    {
        MouseAiming();
        KeyboardMovement();
    }

    private void MouseAiming()
    {
        // get the mouse inputs
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        _rotX += Input.GetAxis("Mouse Y") * turnSpeed;
        
        // clamp the vertical rotation
        _rotX = Mathf.Clamp(_rotX, -maxTurnAngle, maxTurnAngle);
        
        // rotate the camera
        transform.eulerAngles = new Vector3(-_rotX, transform.eulerAngles.y + y, 0);
    }
    
    private void KeyboardMovement()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 hMove = hAxis * transform.right;
        Vector3 vMove = vAxis * transform.forward;
        transform.position += (hMove + vMove).normalized * moveSpeed * Time.deltaTime;
        
        // up and down movement
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += new Vector3(0, verticalSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            transform.position += new Vector3(0, -verticalSpeed * Time.deltaTime, 0);
        }
    }
}