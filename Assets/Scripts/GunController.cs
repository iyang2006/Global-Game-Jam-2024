using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{


    [SerializeField] private Light muzzleLeft;
    [SerializeField] private Light muzzleRight;
    [SerializeField] private float flashDuration;

    public void ShootLeft() {
        StartCoroutine(FlashLeft());
    }

    public void ShootRight() {
       StartCoroutine(FlashRight());
    }

    public void Reload() {

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
