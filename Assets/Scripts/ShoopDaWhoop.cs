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
            
            // play sound queue

            yield return new WaitForSeconds(aimTime);

            // Find player location
            Vector3 playerVector = player.transform.position - transform.position;

            yield return new WaitForSeconds(0.4f);

            // Deploy laser
            if (Physics.Raycast(transform.position, playerVector, out RaycastHit hit, 256, layerMask))
            {
                Vector3 laserVector = hit.point - transform.position;
                Debug.DrawRay(transform.position, laserVector, Color.red);

                GameObject laser = Instantiate(laserPrefab, laserVector / 2 + transform.position,
                            Quaternion.LookRotation(laserVector, Vector3.up));
                laser.transform.Rotate(Vector3.right, 90, Space.Self);
                laser.transform.localScale = new Vector3(2, laserVector.magnitude / 2, 2);

                yield return new WaitForSeconds(laserTime);

                Destroy(laser);
            }
        }
    }
}
