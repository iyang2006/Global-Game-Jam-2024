using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprite : MonoBehaviour
{

    private Transform dummyPlayer;
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite[] sprites;
    [SerializeField] public float spriteLoopTime;
    public float currentTime;
    public int spriteIndex;
    public bool isCharging;

    // Start is called before the first frame update
    void Start()
    {
        dummyPlayer = GameObject.FindWithTag("dummyPlayer").GetComponent<Transform>();
        spriteRenderer.sprite = sprites[0];
        spriteIndex = 0;
        currentTime = spriteLoopTime;
        isCharging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dummyPlayer != null && !isCharging)
        {
            //transform.LookAt(mainCam.transform.position);
            transform.LookAt(dummyPlayer.position);
        }

        if (currentTime <= 0)
        {
            currentTime = spriteLoopTime;
            selectSprite();
        }

        currentTime -= Time.deltaTime;
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
}
