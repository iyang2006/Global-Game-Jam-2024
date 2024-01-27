using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprite : MonoBehaviour
{

    //[SerializeField] Sprite enemySprite;
    Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCam != null)
        {
            transform.LookAt(mainCam.transform.position);
        }
    }
}
