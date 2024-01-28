using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollFace : MonoBehaviour
{
    public AudioSource audioSourceAttack;

    [SerializeField] EnemySprite enemySprite;
    [SerializeField] EnemyMovement enemyMovement;
    [SerializeField] EnemyAttack enemyAttack;

    [SerializeField] float chargeWindUp;
    [SerializeField] float chargeDuration;
    [SerializeField] float chargeSpeed;
    [SerializeField] float maxChargeCooldown;
    [SerializeField] float minChargeCooldown;
    public float chargeCooldown;
    public float currentWindup;
    public float currentDuration;
    public float currentCooldown;

    [SerializeField] Sprite[] windupSprites;
    [SerializeField] Sprite chargeSprite;

    public float normalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        chargeCooldown = Random.Range(minChargeCooldown, maxChargeCooldown);
        currentWindup = -1;
        currentDuration = -1;
        currentCooldown = chargeCooldown;
        normalSpeed = enemyMovement.speed;
    }

    // Update is called once per frame
    void Update()
    {

        //Cooldown
        if (currentCooldown <= 0 && currentCooldown > -1)
        {
            enemySprite.isCharging = true;
            enemyMovement.isCharging = true;
            chargeCooldown = Random.Range(minChargeCooldown, maxChargeCooldown);
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
            audioSourceAttack.Play();

            currentWindup = -1;
            currentDuration = chargeDuration;

            enemySprite.isCharging = true;
            enemyMovement.isCharging = true;
            enemyMovement.speed = chargeSpeed;
            enemyAttack.currentCooldown = 0;
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

            enemySprite.isCharging = false;
            enemyMovement.isCharging = false;
            enemyMovement.speed = normalSpeed;
        }

        if (currentDuration > 0)
        {
            currentDuration -= Time.deltaTime;
        }

    }
}
