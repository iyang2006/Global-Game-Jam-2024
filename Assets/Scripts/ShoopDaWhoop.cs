using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoopDaWhoop : MonoBehaviour
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
            Vector3 bulletVector = player.transform.position - transform.position;
            bulletVector.Normalize();
            bulletVector *= bulletSpeed;

            yield return null;
        }
    }
}
