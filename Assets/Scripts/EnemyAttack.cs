using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] float attackDamage;
    [SerializeField] float attackCooldown;
    float currentCooldown;

    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
        if (currentCooldown < 0)
        {
            currentCooldown = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "player") {
            return;
        }

        if (currentCooldown <= 0)
        {
            Health playerHealth = other.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.damageEntity(attackDamage);
                currentCooldown = attackCooldown;
                Debug.Log("Damaged Player");
            }
        }
    }
}
