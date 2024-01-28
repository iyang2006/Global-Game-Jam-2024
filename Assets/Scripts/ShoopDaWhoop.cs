using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoopDaWhoop : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float aimTime;
    [SerializeField] float laserTime;
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject laserPrefab;

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
            // Find player location
            Vector3 playerVector = player.transform.position - transform.position;

            // Play sound queue and fire laser
            if (Physics.Raycast(transform.position, playerVector, out RaycastHit hit, 128, layerMask))
            {
                // play sound queue

                yield return new WaitForSeconds(aimTime);

                playerVector = player.transform.position - transform.position;
                Vector3 laserVector = hit.transform.position - transform.position;

                yield return new WaitForSeconds(0.4f);

                // Deploy laser
                GameObject laser = Instantiate(laserPrefab, laserVector / 2 + transform.position, 
                            Quaternion.LookRotation(laserVector, Vector3.up));
                laser.transform.Rotate(Vector3.right, 90, Space.Self);
                laser.transform.localScale = new Vector3(1, laserVector.magnitude / 2, 1);

                yield return new WaitForSeconds(laserTime);

                Destroy(laser);
            }
        }
    }
}
