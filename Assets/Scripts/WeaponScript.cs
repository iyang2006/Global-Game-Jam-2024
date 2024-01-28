using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    //[SerializeField] private Rigidbody playerBody;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float damage;
    [SerializeField] private float spinTimeLimit;
    [SerializeField] private float spinResolution;
    [SerializeField] private float spinShootTimeLimit;
    [SerializeField] private float spinMult;
    [SerializeField] private int maxAmmo;
    [SerializeField] private float maxRange;
    [SerializeField] private float coolDown;
    [SerializeField] private float reloadLength;
    [SerializeField] private GunController controller;
    
    private int ammoL;
    private int ammoR;
    private bool hasSpun;
    private int playerMask;
    private float lastLeft;
    private float lastRight;
    private bool reloading;
    private float lastReload;
    private bool turningLeft;

    private Queue<float> angles;
    private float angleSum;
    private Quaternion prevQuat;
    private float lastSpinTrue;

    public void SetTurningLeft(bool val) {
        turningLeft = val;
    }

    private void FireLeft() {
        if (ammoL <= 0) {
            PlayNoAmmo();
        }
        else if ((Time.time - lastLeft > coolDown) && (reloading == false)) {
            ammoL -= 1;
            lastLeft = Time.time;
            controller.ShootLeft();
            Fire();
        }
        hasSpun = false;
    }

    private void FireRight() {
        if (ammoR <= 0) {
            PlayNoAmmo();
        }
        else if ((Time.time - lastRight > coolDown) && (reloading == false)) {
            ammoR -= 1;
            lastRight = Time.time;
            controller.ShootRight();
            Fire();
        }
        hasSpun = false;
    }

    private void PlayNoAmmo() {
        Debug.Log("no ammo");
    }

    private void Fire() {
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, maxRange, playerMask)) {
            float tempDmg = damage;
            if (hasSpun) {
                tempDmg *= spinMult;
            }
            if (hit.collider.gameObject.tag == "enemy") {
                Health healthScript = hit.collider.gameObject.GetComponentInParent<Health>();
                healthScript.damageEntity(tempDmg);
            }
        }
    }

    private void Reload() {
        if ((Time.time - lastRight > coolDown) && (Time.time - lastLeft > coolDown) && (reloading == false)) {
            reloading = true;
            lastReload = Time.time;
        }
    }

    private void SetSpinTrue() {
        angleSum = 0;
        angles.Clear();
        for (int i = 0; i < spinResolution; i++) {
            angles.Enqueue(0f);
        }
        hasSpun = true;
        lastSpinTrue = Time.time;
        Debug.Log("has spun");
    }

    private void UpdateSpin() {
        if (hasSpun && (Time.time - lastSpinTrue > spinShootTimeLimit)) {
            Debug.Log("spin time out");
            hasSpun = false;
        }
        Quaternion currQuat = Quaternion.Euler(0, cameraTransform.rotation.eulerAngles.y, 0);
        float ang = Quaternion.Angle(currQuat, prevQuat);
        if (turningLeft) {
            ang = ang * -1;
        }
        angleSum += ang;
        angleSum -= angles.Dequeue();
        angles.Enqueue(ang);
        if (angleSum > 360 || angleSum < -360) {
            SetSpinTrue();
        }
        prevQuat = currQuat;
    }

    // Start is called before the first frame update
    void Start()
    {
        ammoL = maxAmmo;
        ammoR = maxAmmo;
        lastLeft = 0f;
        lastRight = 0f;
        lastReload = 0f;
        reloading = false;
        hasSpun = false;
        playerMask = LayerMask.NameToLayer("player");
        playerMask = playerMask | LayerMask.NameToLayer("Ignore Raycast");
        playerMask = ~playerMask;
        angles = new Queue<float>();
        prevQuat = Quaternion.Euler(0, cameraTransform.rotation.eulerAngles.y, 0);
        turningLeft = true;

        angleSum = 0f;
        for (int i = 0; i < spinResolution; i++) {
            angles.Enqueue(0f);
        }

        InvokeRepeating("UpdateSpin", 0.1f, (spinTimeLimit / spinResolution));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            FireLeft();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            FireRight();
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            Reload();
        }

        if (reloading) {
            if (Time.time - lastReload > reloadLength) {
                ammoL = maxAmmo;
                ammoR = maxAmmo;
                reloading = false;
            }
        }

    }

}
