using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprite : MonoBehaviour
{

    private Transform dummyPlayer;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sprites;
    [SerializeField] float spriteLoopTime;
    float currentTime;
    int spriteIndex;

    // Start is called before the first frame update
    void Start()
    {
        dummyPlayer = GameObject.FindWithTag("dummyPlayer").GetComponent<Transform>();
        spriteRenderer.sprite = sprites[0];
        spriteIndex = 0;
        currentTime = spriteLoopTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (dummyPlayer != null)
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
