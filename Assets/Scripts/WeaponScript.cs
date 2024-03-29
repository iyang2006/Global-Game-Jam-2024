using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private PlayerAudio audioControl;
    [SerializeField] private SniperAudio leftSniperAudio;
    [SerializeField] private SniperAudio rightSniperAudio;
    [SerializeField] private GameObject smokePrefab;

    [SerializeField] private GameObject leftAmmoHUD;
    [SerializeField] private Sprite[] hudL;
    private Image leftAmmoImage;

    [SerializeField] private GameObject rightAmmoHUD;
    [SerializeField] private Sprite[] hudR;
    private Image rightAmmoImage;

    [SerializeField] private GameObject marker;
    [SerializeField] private Sprite hitSprite;
    [SerializeField] private Sprite bigHitSprite;
    private Image hitSpriteImage;
    private float hitMarkerDuration;
    private float currentHitMarkerTime;


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

    [SerializeField] private Transform leftSmokeStart;
    [SerializeField] private Transform rightSmokeStart;

    public void SetTurningLeft(bool val) {
        turningLeft = val;
    }

    private void FireLeft() {
        Debug.Log("firing left");
        if (ammoL <= 0) {
            leftSniperAudio.PlayEmpty();
        }
        else if ((Time.time - lastLeft > coolDown) && (reloading == false)) {
            ammoL -= 1;
            lastLeft = Time.time;
            if (hasSpun) {
                leftSniperAudio.PlayPowershot();
            }
            else {
                leftSniperAudio.PlayShot();
            }
            controller.ShootLeft();
            Fire(true);
        }
        controller.SetDull();
        hasSpun = false;

        leftAmmoImage.sprite = hudL[ammoL];
    }

    private void FireRight() {
        Debug.Log("firing right");
        if (ammoR <= 0) {
            rightSniperAudio.PlayEmpty();
        }
        else if ((Time.time - lastRight > coolDown) && (reloading == false)) {
            ammoR -= 1;
            lastRight = Time.time;
            if (hasSpun) {
                rightSniperAudio.PlayPowershot();
                startHitMarker(true);
            }
            else {
                rightSniperAudio.PlayShot();
            }
            controller.ShootRight();
            Fire(false);
        }
        controller.SetDull();
        hasSpun = false;

        rightAmmoImage.sprite = hudR[ammoR];
    }

    private void Fire(bool isLeft) {
        RaycastHit hit;
        Vector3 startPos;
        if (isLeft) {
            startPos = leftSmokeStart.position;
        }
        else {
            startPos = rightSmokeStart.position;
        }
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, maxRange, playerMask)) {
            StartCoroutine(SpawnSmoke(startPos, hit.point));
            if (hit.collider.gameObject.tag == "enemy") {
                float tempDmg = damage;
                if (hasSpun) {
                    tempDmg *= spinMult;
                    audioControl.PlayPowerHit();
                    startHitMarker(true);
                }
                else {
                    audioControl.PlayHit();
                    startHitMarker(false);
                }
                Health healthScript = hit.collider.gameObject.GetComponentInParent<Health>();
                healthScript.damageEntity(tempDmg);
            }
        }
        else {
            StartCoroutine(SpawnSmoke(startPos, startPos + (cameraTransform.forward.normalized * maxRange)));
        }
    }

    private void Reload() {
        if ((Time.time - lastRight > coolDown) && (Time.time - lastLeft > coolDown) && (reloading == false)) {
            audioControl.PlayReload();
            controller.Reload();
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
        controller.SetGlow();
        if (hasSpun == false) {
            audioControl.PlayPowerup();
        }
        hasSpun = true;
        lastSpinTrue = Time.time;
    }

    private void UpdateSpin() {
        if (hasSpun && (Time.time - lastSpinTrue > spinShootTimeLimit)) {
            audioControl.PlayPowerDown();
            controller.SetDull();
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
        controller.SetDull();
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

        leftAmmoImage = leftAmmoHUD.GetComponent<Image>();
        rightAmmoImage = rightAmmoHUD.GetComponent<Image>();
        hitSpriteImage = marker.GetComponent<Image>();
        hitMarkerDuration = 0.2f;
        currentHitMarkerTime = -1f;
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
                leftAmmoImage.sprite = hudL[ammoL];
                rightAmmoImage.sprite = hudR[ammoR];
            }
        }

        if (currentHitMarkerTime > 0f)
        {
            currentHitMarkerTime -= Time.deltaTime;
        }

        if (currentHitMarkerTime <= 0f && currentHitMarkerTime > -1f)
        {
            currentHitMarkerTime = -1f;
            marker.SetActive(false);
        }

    }

    IEnumerator SpawnSmoke(Vector3 startPos, Vector3 endPos) {
        //Debug.Log("spawnSmoke");
        
        Vector3 smokeVector = endPos - startPos;

        GameObject smokeObj = Instantiate(smokePrefab, smokeVector / 2 + startPos, Quaternion.LookRotation(smokeVector, Vector3.up));
        smokeObj.transform.Rotate(Vector3.right, 90, Space.Self);
        smokeObj.transform.localScale = new Vector3(smokeObj.transform.localScale.x, smokeVector.magnitude / 2, smokeObj.transform.localScale.z);

        yield break;
    }

    void startHitMarker(bool big)
    {
        marker.SetActive(true);
        if (big)
        {
            hitSpriteImage.sprite = bigHitSprite;
        } else
        {
            hitSpriteImage.sprite = hitSprite;
        }
        currentHitMarkerTime = hitMarkerDuration;
    }

}
