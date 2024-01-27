using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Transform playerPos;
    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform camTransform;
    [SerializeField] private float speed;
    [SerializeField] private float jumpStrength;
    [SerializeField] private float dashStrength;
    [SerializeField] private float dashLength;
    [SerializeField] private float dashCoolDown;
    [SerializeField] private float dashZoom;
    [SerializeField] private float xSensitivity;
    [SerializeField] private float ySensitivity;
    [SerializeField] private float accel;
    [SerializeField] private SphereCollider footCollider;
    

    private bool grounded;
    private bool doubleJump;
    private bool dash;
    private float prevDash;
    private bool inDash;
    private float maxZoom;
    private Vector2 turning;
    private Vector3 move_offset;

    public void SetGround(bool val) {
        grounded = val;
        if (val == true) {
            doubleJump = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        grounded = true;
        doubleJump = true;
        dash = true;
        inDash = false;
        prevDash = Time.time;
        Cursor.lockState = CursorLockMode.Locked;
        maxZoom = 60 + dashZoom;
    }

    private void DashFunc() {
        Debug.Log("dash!");
        dash = false;
        prevDash = Time.time;
        inDash = true;
        playerBody.useGravity = false;
        Vector3 dashDir = camTransform.forward;
        playerBody.AddForce(dashDir * 100 * dashStrength);
    }

    // Update is called once per frame
    void Update()
    {
        if (inDash == false) {
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


            //jumping
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (grounded) {
                    playerBody.velocity = new Vector3(playerBody.velocity.x, 0, playerBody.velocity.z);
                    playerBody.AddForce(playerPos.up * 50 * jumpStrength);
                    grounded = false;
                }
                else if (doubleJump) {
                    playerBody.velocity = new Vector3(playerBody.velocity.x, 0, playerBody.velocity.z);
                    playerBody.AddForce(playerPos.up * 50 * jumpStrength);
                    grounded = false;
                    doubleJump = false;
                    dash = true;
                }
            }

            //dashing
            if ((dash == false) && grounded && (Time.time - prevDash > dashCoolDown)) {
                dash = true;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift) && dash) {
                DashFunc();
            }
        }
        else {
            if (Time.time - prevDash < 0.1f * dashLength) {
                cam.fieldOfView = Mathf.Lerp(60, maxZoom, (Time.time - prevDash) / (0.1f * dashLength));
            }
            else {
                cam.fieldOfView = Mathf.Lerp(maxZoom, 60, (Time.time - prevDash + (0.1f * dashLength)) / (0.9f * dashLength));
            }
            playerBody.velocity = playerBody.velocity * 0.98f;
            if (Time.time - prevDash > dashLength) {
                inDash = false;
                playerBody.useGravity = true;
                Debug.Log(cam.fieldOfView);
                cam.fieldOfView = 60;
            }
        }
    }

    void FixedUpdate() {

        if (inDash == false) {
            //moving
            playerBody.velocity = new Vector3(playerBody.velocity.x * accel, playerBody.velocity.y, playerBody.velocity.z * accel);

            move_offset = Vector3.zero;
            
            move_offset += Input.GetAxisRaw("Horizontal") * playerPos.right;
            move_offset += Input.GetAxisRaw("Vertical") * playerPos.forward;

            //playerBody.MovePosition(playerBody.position + (move_offset.normalized * speed * Time.fixedDeltaTime));

            playerBody.AddForce(move_offset.normalized * speed * Time.fixedDeltaTime * 1000);
        }
    }
}
