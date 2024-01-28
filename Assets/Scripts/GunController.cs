using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GunController : MonoBehaviour
{

    [SerializeField] private Transform sniperLeftTrans;
    [SerializeField] private Transform sniperRightTrans;
    [SerializeField] private Light muzzleLeft;
    [SerializeField] private Light muzzleRight;
    [SerializeField] private float flashDuration;
    [SerializeField] private float reloadAnimDuration;
    [SerializeField] private float maxReloadDip;
    [SerializeField] private float maxReloadTilt;
    [SerializeField] private float recoilDuration;
    [SerializeField] private float recoveryDuration;
    [SerializeField] private float maxRecoilBack;
    [SerializeField] private float maxRecoilTilt;
    [SerializeField] private Material dull;
    [SerializeField] private Material glowing;
    [SerializeField] private MeshRenderer leftMesh;
    [SerializeField] private MeshRenderer rightMesh;
    private float initRecoilDur;


    private Quaternion maxTiltQuat;

    private float initReloadDip;
    private Quaternion initReloadTilt;
    private Vector3 initLeft;
    private Vector3 initRight;
    private float reloadStart;
    private float halfReload;


    public void SetDull() {
        leftMesh.material = dull;
        rightMesh.material = dull;
    }

    public void SetGlow() {
        leftMesh.material = glowing;
        rightMesh.material = glowing;
    }
    public void ShootLeft() {
        StartCoroutine(FlashLeft());
        StartCoroutine(LeftAnim());
    }

    public void ShootRight() {
       StartCoroutine(FlashRight());
    }

    IEnumerator LeftAnim() {
        while (Time.time - reloadStart < halfReload) {
            float y = Mathf.Lerp(0, maxReloadDip, (Time.time - reloadStart)/halfReload);
            sniperLeftTrans.localPosition = new Vector3(sniperLeftTrans.localPosition.x, initLeft.y - y, sniperLeftTrans.localPosition.z);
            sniperRightTrans.localPosition = new Vector3(sniperRightTrans.localPosition.x, initRight.y - y, sniperRightTrans.localPosition.z);

            Quaternion tempRot = Quaternion.Slerp(initReloadTilt, maxTiltQuat, (Time.time - reloadStart)/halfReload);
            sniperLeftTrans.localRotation = tempRot;
            sniperRightTrans.localRotation = tempRot;

            yield return new WaitForEndOfFrame();
        }
        while (Time.time - reloadStart < reloadAnimDuration) {
            float y = Mathf.Lerp(maxReloadDip, 0, (Time.time - reloadStart - halfReload)/halfReload);
            sniperLeftTrans.localPosition = new Vector3(sniperLeftTrans.localPosition.x, initLeft.y - y, sniperLeftTrans.localPosition.z);
            sniperRightTrans.localPosition = new Vector3(sniperRightTrans.localPosition.x, initRight.y - y, sniperRightTrans.localPosition.z);

            Quaternion tempRot = Quaternion.Slerp(maxTiltQuat, initReloadTilt, (Time.time - reloadStart - halfReload)/halfReload);
            sniperLeftTrans.localRotation = tempRot;
            sniperRightTrans.localRotation = tempRot;

            yield return new WaitForEndOfFrame();
        }

        sniperLeftTrans.localPosition = initLeft;
        sniperLeftTrans.localRotation = initReloadTilt;
        yield return null;
    }

    public void Reload() {
        reloadStart = Time.time;
        StartCoroutine(ReloadAnim());
    }

    IEnumerator ReloadAnim() {
        while (Time.time - reloadStart < halfReload) {
            float y = Mathf.Lerp(0, maxReloadDip, (Time.time - reloadStart)/halfReload);
            sniperLeftTrans.localPosition = new Vector3(sniperLeftTrans.localPosition.x, initLeft.y - y, sniperLeftTrans.localPosition.z);
            sniperRightTrans.localPosition = new Vector3(sniperRightTrans.localPosition.x, initRight.y - y, sniperRightTrans.localPosition.z);

            Quaternion tempRot = Quaternion.Slerp(initReloadTilt, maxTiltQuat, (Time.time - reloadStart)/halfReload);
            sniperLeftTrans.localRotation = tempRot;
            sniperRightTrans.localRotation = tempRot;

            yield return new WaitForEndOfFrame();
        }
        while (Time.time - reloadStart < reloadAnimDuration) {
            float y = Mathf.Lerp(maxReloadDip, 0, (Time.time - reloadStart - halfReload)/halfReload);
            sniperLeftTrans.localPosition = new Vector3(sniperLeftTrans.localPosition.x, initLeft.y - y, sniperLeftTrans.localPosition.z);
            sniperRightTrans.localPosition = new Vector3(sniperRightTrans.localPosition.x, initRight.y - y, sniperRightTrans.localPosition.z);

            Quaternion tempRot = Quaternion.Slerp(maxTiltQuat, initReloadTilt, (Time.time - reloadStart - halfReload)/halfReload);
            sniperLeftTrans.localRotation = tempRot;
            sniperRightTrans.localRotation = tempRot;

            yield return new WaitForEndOfFrame();
        }
        sniperRightTrans.localPosition = initRight;
        sniperLeftTrans.localPosition = initLeft;
        sniperRightTrans.localRotation = initReloadTilt;
        sniperLeftTrans.localRotation = initReloadTilt;
        yield return null;
    }

    IEnumerator FlashLeft() {
        muzzleLeft.enabled = true;
        yield return new WaitForSeconds(flashDuration);
        muzzleLeft.enabled = false;
        yield return null;
    }

    IEnumerator FlashRight() {
        muzzleRight.enabled = true;
        yield return new WaitForSeconds(flashDuration);
        muzzleRight.enabled = false;
        yield return null;
    }


    // Start is called before the first frame update
    void Start()
    {
        muzzleLeft.enabled = false;
        muzzleRight.enabled = false;
        initReloadDip = sniperLeftTrans.position.y;
        initReloadTilt = sniperLeftTrans.localRotation;
        initLeft = sniperLeftTrans.localPosition;
        initRight = sniperRightTrans.localPosition;
        halfReload = 0.5f * reloadAnimDuration;
        initRecoilDur = recoilDuration - recoveryDuration;
        maxTiltQuat = Quaternion.Euler(initReloadTilt.eulerAngles.x, initReloadTilt.eulerAngles.y, initReloadTilt.eulerAngles.z - maxReloadTilt);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
