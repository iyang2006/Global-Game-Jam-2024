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
                    // play sound queue

                    // Shoot player
                    GameObject bullet = Instantiate(bulletPrefab, transform.position,
                                Quaternion.LookRotation(hit.normal, Vector3.up));
                    bullet.GetComponent<Bullet>().bulletVector = bulletVector;
                }
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
}
