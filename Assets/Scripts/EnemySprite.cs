using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprite : MonoBehaviour
{

    private Transform dummyPlayer;
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite[] sprites;
    [SerializeField] public float spriteLoopTime;
    [SerializeField] public Sprite[] chargingSprites;
    [SerializeField] public float chargingSpriteLoopTime;
    public float currentTime;
    public float currentChargingTime;
    public int spriteIndex;
    public int chargingSpriteIndex;
    public bool isCharging;

    // Start is called before the first frame update
    void Start()
    {
        dummyPlayer = GameObject.FindWithTag("dummyPlayer").GetComponent<Transform>();
        spriteRenderer.sprite = sprites[0];
        spriteIndex = 0;
        chargingSpriteIndex = 0;
        currentTime = spriteLoopTime;
        currentChargingTime = chargingSpriteLoopTime;
        isCharging = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentChargingTime <= 0 && isCharging)
        {
            currentChargingTime = chargingSpriteLoopTime;
            currentTime = 0;
            spriteIndex = 0;
            selectChargingSprite();
        }

        if (isCharging)
        {
            currentChargingTime -= Time.deltaTime;
        }



        if (dummyPlayer != null && !isCharging)
        {
            transform.LookAt(dummyPlayer.position);
        }

        if (currentTime <= 0 && !isCharging)
        {
            currentChargingTime = 0;
            chargingSpriteIndex = 0;
            currentTime = spriteLoopTime;
            selectSprite();
        }

        if (!isCharging)
        {
            currentTime -= Time.deltaTime;
        }
    }

    void selectSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }
    
    void selectChargingSprite()
    {
        if (chargingSpriteIndex < chargingSprites.Length - 1)
        {
            chargingSpriteIndex++;
        }
        spriteRenderer.sprite = chargingSprites[chargingSpriteIndex];
    }
}
