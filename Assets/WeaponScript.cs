using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float damage;
    [SerializeField] private float spinTimeLimit;
    [SerializeField] private float spinMult;
    [SerializeField] private int maxAmmo;
    [SerializeField] private float maxRange;
    [SerializeField] private float coolDown;
    [SerializeField] private float reloadLength;
    
    private int ammoL;
    private int ammoR;
    private bool hasSpun;
    private int playerMask;
    private float lastLeft;
    private float lastRight;
    private bool reloading;
    private float lastReload;

    private void FireLeft() {
        if (ammoL <= 0) {
            PlayNoAmmo();
        }
        else if ((Time.time - lastLeft > coolDown) && (reloading == false)) {
            ammoL -= 1;
            lastLeft = Time.time;
            Fire();
        }
    }

    private void FireRight() {
        if (ammoR <= 0) {
            PlayNoAmmo();
        }
        else if ((Time.time - lastRight > coolDown) && (reloading == false)) {
            ammoR -= 1;
            lastRight = Time.time;
            Fire();
        }
    }

    private void PlayNoAmmo() {
        Debug.Log("no ammo");
    }

    private void Fire() {
        Debug.Log("fire gun");
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, maxRange, playerMask)) {
            Debug.Log(hit.collider.gameObject.tag);
            if (hit.collider.gameObject.tag == "enemy") {
                Debug.Log("hit pepe");
                Health healthScript = hit.collider.gameObject.GetComponentInParent<Health>();
                healthScript.damageEntity(damage);
            }
        }
    }

    private void Reload() {
        if ((Time.time - lastRight > coolDown) && (Time.time - lastLeft > coolDown) && (reloading == false)) {
            reloading = true;
            lastReload = Time.time;
        }
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
        playerMask = LayerMask.NameToLayer("player");
        playerMask = playerMask | LayerMask.NameToLayer("Ignore Raycast");
        playerMask = ~playerMask;
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
