using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public static int level = 1;

    [SerializeField] float levelSize = 100;
    [SerializeField] GameObject Pepe;
    [SerializeField] GameObject KeyboardCat;
    [SerializeField] GameObject Troll;
    [SerializeField] GameObject ShoopDaWhoop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPepe()
    {
        //Instantiate(Pepe, new Vector3(1, 1, 1), Quaternion.identity);
    }

    void SpawnKeyboardCat()
    {

    }

    void SpawnTroll()
    {

    }

    void SpawnShoopDaWhoop()
    {

    }
}
