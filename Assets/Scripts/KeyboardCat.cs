using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class KeyboardCat : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float waitTime;
    [SerializeField] float bulletSpeed;
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Find player
        player = GameObject.FindGameObjectWithTag("player");
        
        // Start shooting if it sees player
        StartCoroutine(waiting());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Shoots player
    void Shoot(Vector3 bulletVector, RaycastHit hit)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(hit.normal, Vector3.forward));
        bullet.GetComponent<Bullet>().GetBulletVector(bulletVector);
    }

    IEnumerator waiting()
    {
        while (true)
        {
            // Get bullet speed
            Vector3 bulletVector = player.transform.position - transform.position;
            bulletVector.Normalize();
            bulletVector *= bulletSpeed;

            // Shoot player if cat sees player
            if (Physics.Raycast(transform.position, bulletVector, out RaycastHit hit, 128, layerMask))
            {
                if (hit.transform.gameObject.tag == "player")
                {
                    Shoot(bulletVector, hit);
                }
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
}
