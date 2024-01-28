using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float damage;
    public Vector3 bulletVector;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bulletVector * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "world")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "player")
        {
            other.gameObject.GetComponent<Health>().damageEntity(damage);
            Destroy(gameObject);
        }
    }
}
