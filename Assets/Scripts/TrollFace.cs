using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollFace : MonoBehaviour
{

    [SerializeField] EnemySprite enemySprite;
    [SerializeField] EnemyMovement enemyMovement;

    [SerializeField] float chargeWindUp;
    [SerializeField] float chargeDuration;
    [SerializeField] float chargeCooldown;
    float currentWindup;
    float currentDuration;
    float currentCooldown;

    // Start is called before the first frame update
    void Start()
    {
        currentWindup = -1;
        currentDuration = -1;
        currentCooldown = chargeCooldown;
    }

    // Update is called once per frame
    void Update()
    {

        //Cooldown
        if (currentCooldown <= 0 && currentCooldown > -1)
        {
            currentCooldown = -1;
            currentWindup = chargeWindUp;
        }

        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }

        //Windup
        if (currentWindup <= 0 && currentWindup > -1)
        {
            currentWindup = -1;
            currentDuration = chargeDuration;
        }

        if (currentWindup > 0)
        {
            currentWindup -= Time.deltaTime;
        }

        //Duration
        if (currentDuration <= 0 && currentDuration > -1)
        {
            currentDuration = -1;
            currentCooldown = chargeCooldown;
        }

        if (currentDuration > 0)
        {
            currentDuration -= Time.deltaTime;
        }
    }
}
