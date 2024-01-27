using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 1;
    Vector3 bulletVector;

    // Start is called before the first frame update
    void Start()
    {
        // Get bullet vector
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;
        float playerZ = player.transform.position.z;
        float bulletX = transform.position.x;
        float bulletY = transform.position.y;
        float bulletZ = transform.position.z;
        Vector3 bulletVector = new Vector3(bulletX - playerX, bulletY - playerY, bulletZ - playerZ);
        bulletVector.Normalize();
        bulletVector *= bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bulletVector;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
