using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    [SerializeField] private Transform playerPos;
    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform camTransform;
    [SerializeField] private float speed;
    [SerializeField] private float jumpStrength;
    [SerializeField] private float dashLength;
    [SerializeField] private float xSensitivity;
    [SerializeField] private float ySensitivity;
    

    private bool grounded;
    private Vector2 turning;
    private Vector3 move_offset;

    // Start is called before the first frame update
    void Start()
    {
        grounded = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //looking
        turning.x += Input.GetAxisRaw("Mouse X") * xSensitivity;
        turning.y += Input.GetAxisRaw("Mouse Y") * ySensitivity;
        if (turning.y < -90) {
            turning.y = -90;
        }
        if (turning.y > 90) {
            turning.y = 90;
        }
        camTransform.localRotation = Quaternion.Euler(-turning.y, 0, 0);
        playerPos.rotation = Quaternion.Euler(0, turning.x,0);


        //moving
        move_offset = Vector3.zero;
        
        move_offset += Input.GetAxisRaw("Horizontal") * playerPos.right;
        move_offset += Input.GetAxisRaw("Vertical") * playerPos.forward;

        playerBody.MovePosition(playerBody.position + (move_offset.normalized * speed * Time.deltaTime));
    }
}
