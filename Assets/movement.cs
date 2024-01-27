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
        turning.x += Input.GetAxis("Mouse X") * xSensitivity;
        turning.y += Input.GetAxis("Mouse Y") * ySensitivity;
        camTransform.rotation = Quaternion.Euler(-turning.y, turning.x, 0);
        playerPos.rotation = Quaternion.Euler(0, camTransform.eulerAngles.y, 0);


        //moving
        Vector3 move_offset = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W)) {
            move_offset += playerPos.forward;
        }
        if (Input.GetKey(KeyCode.S)) {
            move_offset += playerPos.forward * -1;
        }
        if (Input.GetKey(KeyCode.A)) {
            move_offset += playerPos.right * -1;
        }
        if (Input.GetKey(KeyCode.D)) {
            move_offset += playerPos.right;
        }

        playerBody.MovePosition(playerPos.position + (move_offset.normalized * speed * 0.05f));
    }
}
