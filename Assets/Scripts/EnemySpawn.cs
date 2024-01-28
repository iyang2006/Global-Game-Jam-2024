using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public static int level = 1;
    public static int wave = 1;
    private bool inWait = false;
    private float waitTime = 0;

    [SerializeField] float afterWave1WaitTime;
    [SerializeField] float afterLevel1WaitTime;

    // The array shows how much of Pepe, Keyboard Cat, Troll, and Shoop Da Whoop
    // at index 0, 1, 2, 3, repectively, to spawn for that level and wave
    [SerializeField] int[] level1Wave1Spawns = new int[4];
    [SerializeField] int[] level1Wave2Spawns = new int[4];
    [SerializeField] int[] level1Wave3Spawns = new int[4];
    [SerializeField] int[] level1Wave4Spawns = new int[4];

    [SerializeField] int[] level2Wave1Spawns = new int[4];
    [SerializeField] int[] level2Wave2Spawns = new int[4];
    [SerializeField] int[] level2Wave3Spawns = new int[4];
    [SerializeField] int[] level2Wave4Spawns = new int[4];

    [SerializeField] int[] level3Wave1Spawns = new int[4];
    [SerializeField] int[] level3Wave2Spawns = new int[4];
    [SerializeField] int[] level3Wave3Spawns = new int[4];
    [SerializeField] int[] level3Wave4Spawns = new int[4];

    [SerializeField] int[] level4Wave1Spawns = new int[4];
    [SerializeField] int[] level4Wave2Spawns = new int[4];
    [SerializeField] int[] level4Wave3Spawns = new int[4];
    [SerializeField] int[] level4Wave4Spawns = new int[4];

    // The arry shows how much of Pepe, Keyboard Cat, Troll, and Shoop Da Whoop to increment from
    // level 4 by at index 0, 1, 2, 3, respectively, to spawn for that modular level and wave
    [SerializeField] int[] levelMod1Wave1Spawns = new int[8];
    [SerializeField] int[] levelMod1Wave2Spawns = new int[8];
    [SerializeField] int[] levelMod1Wave3Spawns = new int[8];
    [SerializeField] int[] levelMod1Wave4Spawns = new int[8];

    // The array shows how much of Pepe, Keyboard Cat, Troll, and Shoop Da Whoop
    // at index 0, 1, 2, 3, repectively, to spawn for that level and wave and
    // how much of Pepe, Keyboard Cat, Troll, and Shoop Da Whoop to increment by
    // at index 4, 5, 6, 7, respectively, to spawn for that modular level and wave
    [SerializeField] int[] levelMod5Wave1Spawns = new int[8];
    [SerializeField] int[] levelMod5Wave2Spawns = new int[8];
    [SerializeField] int[] levelMod5Wave3Spawns = new int[8];
    [SerializeField] int[] levelMod5Wave4Spawns = new int[8];

    [SerializeField] int[] levelMod10Wave1Spawns = new int[8];
    [SerializeField] int[] levelMod10Wave2Spawns = new int[8];
    [SerializeField] int[] levelMod10Wave3Spawns = new int[8];
    [SerializeField] int[] levelMod10Wave4Spawns = new int[8];

    [SerializeField] int[] levelMod15Wave1Spawns = new int[8];
    [SerializeField] int[] levelMod15Wave2Spawns = new int[8];
    [SerializeField] int[] levelMod15Wave3Spawns = new int[8];
    [SerializeField] int[] levelMod15Wave4Spawns = new int[8];

    [SerializeField] Vector3[] pepeSpawns;
    [SerializeField] Vector3[] keyboardCatSpawns;
    [SerializeField] Vector3[] trollSpawns;
    [SerializeField] Vector3[] shoopDaWhoopSpawns;
    [SerializeField] GameObject Pepe;
    [SerializeField] GameObject KeyboardCat;
    [SerializeField] GameObject Troll;
    [SerializeField] GameObject ShoopDaWhoop;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Level1());
    }

    // Update is called once per frame
    void Update()
    {
        // Updates wait times inbetween waves
        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
        
        // Sets wait times inbetween waves based on which wave the player is on
        else if (waitTime <= 0 && !inWait)
        {
            if (wave % 4 == 0)
            {
                waitTime = AfterLevelWaitTime();
            }

            else
            {
                waitTime = AfterWaveWaitTime();
            }

            inWait = true;
        }

        // Spawns enemies
        else if (waitTime <= 0 && inWait)
        {
            // If the current level is a multiple of 15
            if (level % 15 == 0)
            {
                int increment = level / 15 - 1;
                if (wave % 4 == 1)
                {
                    for (int i = 0; i < levelMod15Wave1Spawns[0] + increment * levelMod15Wave1Spawns[4]; i++) SpawnPepe();
                    for (int i = 0; i < levelMod15Wave1Spawns[1] + increment * levelMod15Wave1Spawns[5]; i++) SpawnKeyboardCat();
                    for (int i = 0; i < levelMod15Wave1Spawns[2] + increment * levelMod15Wave1Spawns[6]; i++) SpawnTroll();
                    for (int i = 0; i < levelMod15Wave1Spawns[3] + increment * levelMod15Wave1Spawns[7]; i++) SpawnShoopDaWhoop();
                }
                if (wave % 4 == 2)
                {
                    for (int i = 0; i < levelMod15Wave2Spawns[0] + increment * levelMod15Wave2Spawns[4]; i++) SpawnPepe();
                    for (int i = 0; i < levelMod15Wave2Spawns[1] + increment * levelMod15Wave2Spawns[5]; i++) SpawnKeyboardCat();
                    for (int i = 0; i < levelMod15Wave2Spawns[2] + increment * levelMod15Wave2Spawns[6]; i++) SpawnTroll();
                    for (int i = 0; i < levelMod15Wave2Spawns[3] + increment * levelMod15Wave2Spawns[7]; i++) SpawnShoopDaWhoop();
                }
                if (wave % 4 == 3)
                {
                    for (int i = 0; i < levelMod15Wave3Spawns[0] + increment * levelMod15Wave3Spawns[4]; i++) SpawnPepe();
                    for (int i = 0; i < levelMod15Wave3Spawns[1] + increment * levelMod15Wave3Spawns[5]; i++) SpawnKeyboardCat();
                    for (int i = 0; i < levelMod15Wave3Spawns[2] + increment * levelMod15Wave3Spawns[6]; i++) SpawnTroll();
                    for (int i = 0; i < levelMod15Wave3Spawns[3] + increment * levelMod15Wave3Spawns[7]; i++) SpawnShoopDaWhoop();
                }
                if (wave % 4 == 0)
                {
                    for (int i = 0; i < levelMod15Wave4Spawns[0] + increment * levelMod15Wave4Spawns[4]; i++) SpawnPepe();
                    for (int i = 0; i < levelMod15Wave4Spawns[1] + increment * levelMod15Wave4Spawns[5]; i++) SpawnKeyboardCat();
                    for (int i = 0; i < levelMod15Wave4Spawns[2] + increment * levelMod15Wave4Spawns[6]; i++) SpawnTroll();
                    for (int i = 0; i < levelMod15Wave4Spawns[3] + increment * levelMod15Wave4Spawns[7]; i++) SpawnShoopDaWhoop();
                }
            }

            // If the current level is a multiple of 10
            else if (level % 10 == 0)
            {
                int increment = level / 10 - 1;
                if (wave % 4 == 1)
                {
                    for (int i = 0; i < levelMod10Wave1Spawns[0] + increment * levelMod10Wave1Spawns[4]; i++) SpawnPepe();
                    for (int i = 0; i < levelMod10Wave1Spawns[1] + increment * levelMod10Wave1Spawns[5]; i++) SpawnKeyboardCat();
                    for (int i = 0; i < levelMod10Wave1Spawns[2] + increment * levelMod10Wave1Spawns[6]; i++) SpawnTroll();
                    for (int i = 0; i < levelMod10Wave1Spawns[3] + increment * levelMod10Wave1Spawns[7]; i++) SpawnShoopDaWhoop();
                }
                if (wave % 4 == 2)
                {
                    for (int i = 0; i < levelMod10Wave2Spawns[0] + increment * levelMod10Wave2Spawns[4]; i++) SpawnPepe();
                    for (int i = 0; i < levelMod10Wave2Spawns[1] + increment * levelMod10Wave2Spawns[5]; i++) SpawnKeyboardCat();
                    for (int i = 0; i < levelMod10Wave2Spawns[2] + increment * levelMod10Wave2Spawns[6]; i++) SpawnTroll();
                    for (int i = 0; i < levelMod10Wave2Spawns[3] + increment * levelMod10Wave2Spawns[7]; i++) SpawnShoopDaWhoop();
                }
                if (wave % 4 == 3)
                {
                    for (int i = 0; i < levelMod10Wave3Spawns[0] + increment * levelMod10Wave3Spawns[4]; i++) SpawnPepe();
                    for (int i = 0; i < levelMod10Wave3Spawns[1] + increment * levelMod10Wave3Spawns[5]; i++) SpawnKeyboardCat();
                    for (int i = 0; i < levelMod10Wave3Spawns[2] + increment * levelMod10Wave3Spawns[6]; i++) SpawnTroll();
                    for (int i = 0; i < levelMod10Wave3Spawns[3] + increment * levelMod10Wave3Spawns[7]; i++) SpawnShoopDaWhoop();
                }
                if (wave % 4 == 0)
                {
                    for (int i = 0; i < levelMod10Wave4Spawns[0] + increment * levelMod10Wave4Spawns[4]; i++) SpawnPepe();
                    for (int i = 0; i < levelMod10Wave4Spawns[1] + increment * levelMod10Wave4Spawns[5]; i++) SpawnKeyboardCat();
                    for (int i = 0; i < levelMod10Wave4Spawns[2] + increment * levelMod10Wave4Spawns[6]; i++) SpawnTroll();
                    for (int i = 0; i < levelMod10Wave4Spawns[3] + increment * levelMod10Wave4Spawns[7]; i++) SpawnShoopDaWhoop();
                }
            }

            // If the current level is a multiple of 5
            else if (level % 5 == 0)
            {
                int increment = level / 5 - 1;
                if (wave % 4 == 1)
                {
                    for (int i = 0; i < levelMod5Wave1Spawns[0] + increment * levelMod5Wave1Spawns[4]; i++) SpawnPepe();
                    for (int i = 0; i < levelMod5Wave1Spawns[1] + increment * levelMod5Wave1Spawns[5]; i++) SpawnKeyboardCat();
                    for (int i = 0; i < levelMod5Wave1Spawns[2] + increment * levelMod5Wave1Spawns[6]; i++) SpawnTroll();
                    for (int i = 0; i < levelMod5Wave1Spawns[3] + increment * levelMod5Wave1Spawns[7]; i++) SpawnShoopDaWhoop();
                }
                if (wave % 4 == 2)
                {
                    for (int i = 0; i < levelMod5Wave2Spawns[0] + increment * levelMod5Wave2Spawns[4]; i++) SpawnPepe();
                    for (int i = 0; i < levelMod5Wave2Spawns[1] + increment * levelMod5Wave2Spawns[5]; i++) SpawnKeyboardCat();
                    for (int i = 0; i < levelMod5Wave2Spawns[2] + increment * levelMod5Wave2Spawns[6]; i++) SpawnTroll();
                    for (int i = 0; i < levelMod5Wave2Spawns[3] + increment * levelMod5Wave2Spawns[7]; i++) SpawnShoopDaWhoop();
                }
                if (wave % 4 == 3)
                {
                    for (int i = 0; i < levelMod5Wave3Spawns[0] + increment * levelMod5Wave3Spawns[4]; i++) SpawnPepe();
                    for (int i = 0; i < levelMod5Wave3Spawns[1] + increment * levelMod5Wave3Spawns[5]; i++) SpawnKeyboardCat();
                    for (int i = 0; i < levelMod5Wave3Spawns[2] + increment * levelMod5Wave3Spawns[6]; i++) SpawnTroll();
                    for (int i = 0; i < levelMod5Wave3Spawns[3] + increment * levelMod5Wave3Spawns[7]; i++) SpawnShoopDaWhoop();
                }
                if (wave % 4 == 0)
                {
                    for (int i = 0; i < levelMod5Wave4Spawns[0] + increment * levelMod5Wave4Spawns[4]; i++) SpawnPepe();
                    for (int i = 0; i < levelMod5Wave4Spawns[1] + increment * levelMod5Wave4Spawns[5]; i++) SpawnKeyboardCat();
                    for (int i = 0; i < levelMod5Wave4Spawns[2] + increment * levelMod5Wave4Spawns[6]; i++) SpawnTroll();
                    for (int i = 0; i < levelMod5Wave4Spawns[3] + increment * levelMod5Wave4Spawns[7]; i++) SpawnShoopDaWhoop();
                }
            }

            // If the level is not a multiple of 15, 10, nor 5
            else
            {
                if (wave % 4 == 1)
                {
                    for (int i = 0; i < level4Wave1Spawns[0] + level * levelMod1Wave1Spawns[4]; i++) SpawnPepe();
                    for (int i = 0; i < level4Wave1Spawns[1] + level * levelMod1Wave1Spawns[5]; i++) SpawnKeyboardCat();
                    for (int i = 0; i < level4Wave1Spawns[2] + level * levelMod1Wave1Spawns[6]; i++) SpawnTroll();
                    for (int i = 0; i < level4Wave1Spawns[3] + level * levelMod1Wave1Spawns[7]; i++) SpawnShoopDaWhoop();
                }
                if (wave % 4 == 2)
                {
                    for (int i = 0; i < level4Wave2Spawns[0] + level * levelMod1Wave2Spawns[4]; i++) SpawnPepe();
                    for (int i = 0; i < level4Wave2Spawns[1] + level * levelMod1Wave2Spawns[5]; i++) SpawnKeyboardCat();
                    for (int i = 0; i < level4Wave2Spawns[2] + level * levelMod1Wave2Spawns[6]; i++) SpawnTroll();
                    for (int i = 0; i < level4Wave2Spawns[3] + level * levelMod1Wave2Spawns[7]; i++) SpawnShoopDaWhoop();
                }
                if (wave % 4 == 3)
                {
                    for (int i = 0; i < level4Wave3Spawns[0] + level * levelMod1Wave3Spawns[4]; i++) SpawnPepe();
                    for (int i = 0; i < level4Wave3Spawns[1] + level * levelMod1Wave3Spawns[5]; i++) SpawnKeyboardCat();
                    for (int i = 0; i < level4Wave3Spawns[2] + level * levelMod1Wave3Spawns[6]; i++) SpawnTroll();
                    for (int i = 0; i < level4Wave3Spawns[3] + level * levelMod1Wave3Spawns[7]; i++) SpawnShoopDaWhoop();
                }
                if (wave % 4 == 0)
                {
                    for (int i = 0; i < level4Wave4Spawns[0] + level * levelMod1Wave4Spawns[4]; i++) SpawnPepe();
                    for (int i = 0; i < level4Wave4Spawns[1] + level * levelMod1Wave4Spawns[5]; i++) SpawnKeyboardCat();
                    for (int i = 0; i < level4Wave4Spawns[2] + level * levelMod1Wave4Spawns[6]; i++) SpawnTroll();
                    for (int i = 0; i < level4Wave4Spawns[3] + level * levelMod1Wave4Spawns[7]; i++) SpawnShoopDaWhoop();
                }
            }

            inWait = false;
        }

        else
        {
            Debug.LogError("Level is not waiting inbetween waves nor spawning enemies", gameObject);
        }


        for (int i = 0; i < level1Wave1Spawns[0]; i++) SpawnPepe();
        for (int i = 0; i < level1Wave1Spawns[1]; i++) SpawnKeyboardCat();
        for (int i = 0; i < level1Wave1Spawns[2]; i++) SpawnTroll();
        for (int i = 0; i < level1Wave1Spawns[3]; i++) SpawnShoopDaWhoop();

        while (GameObject.FindGameObjectsWithTag("enemy").Length != 0) ;
        //yield return new WaitForSeconds(AfterWaveWaitTime());

        for (int i = 0; i < level1Wave2Spawns[0]; i++) SpawnPepe();
        for (int i = 0; i < level1Wave2Spawns[1]; i++) SpawnKeyboardCat();
        for (int i = 0; i < level1Wave2Spawns[2]; i++) SpawnTroll();
        for (int i = 0; i < level1Wave2Spawns[3]; i++) SpawnShoopDaWhoop();

        while (GameObject.FindGameObjectsWithTag("enemy").Length != 0) ;
        //yield return new WaitForSeconds(AfterWaveWaitTime());

        for (int i = 0; i < level1Wave3Spawns[0]; i++) SpawnPepe();
        for (int i = 0; i < level1Wave3Spawns[1]; i++) SpawnKeyboardCat();
        for (int i = 0; i < level1Wave3Spawns[2]; i++) SpawnTroll();
        for (int i = 0; i < level1Wave3Spawns[3]; i++) SpawnShoopDaWhoop();

        while (GameObject.FindGameObjectsWithTag("enemy").Length != 0) ;
        //yield return new WaitForSeconds(AfterWaveWaitTime());

        for (int i = 0; i < level1Wave4Spawns[0]; i++) SpawnPepe();
        for (int i = 0; i < level1Wave4Spawns[1]; i++) SpawnKeyboardCat();
        for (int i = 0; i < level1Wave4Spawns[2]; i++) SpawnTroll();
        for (int i = 0; i < level1Wave4Spawns[3]; i++) SpawnShoopDaWhoop();

        while (GameObject.FindGameObjectsWithTag("enemy").Length != 0) ;
        //yield return new WaitForSeconds(AfterLevelWaitTime());
    }

    // if we want to manually involve spawn locations, change method to have parameters of vectors, and
    // assert the location vector(s) of where we want the enemies to spawn
    void SpawnPepe()
    {
        Instantiate(Pepe, pepeSpawns[Random.Range(0, pepeSpawns.Length - 1)], Quaternion.identity);
    }

    void SpawnKeyboardCat()
    {
        Instantiate(KeyboardCat, keyboardCatSpawns[Random.Range(0, keyboardCatSpawns.Length - 1)], Quaternion.identity);
    }

    void SpawnTroll()
    {
        Instantiate(Troll, trollSpawns[Random.Range(0, trollSpawns.Length - 1)], Quaternion.identity);
    }

    void SpawnShoopDaWhoop()
    {
        Instantiate(ShoopDaWhoop, shoopDaWhoopSpawns[Random.Range(0, shoopDaWhoopSpawns.Length - 1)], Quaternion.identity);
    }

    private float AfterWaveWaitTime()
    {
        float time = afterWave1WaitTime + 10 * (Mathf.Log(wave + 9, 3) - Mathf.Log(10, 3));
        wave++;
        return time;
    }

    private float AfterLevelWaitTime()
    {
        float time = afterLevel1WaitTime + 10 * (Mathf.Log(3 * (level - 1) + 10, 2) - Mathf.Log(10, 2));
        level++;
        return time;
    }

    IEnumerator Level1()
    {
        for (int i = 0; i < level1Wave1Spawns[0]; i++) SpawnPepe();
        for (int i = 0; i < level1Wave1Spawns[1]; i++) SpawnKeyboardCat();
        for (int i = 0; i < level1Wave1Spawns[2]; i++) SpawnTroll();
        for (int i = 0; i < level1Wave1Spawns[3]; i++) SpawnShoopDaWhoop();

        while (GameObject.FindGameObjectsWithTag("enemy").Length != 0) ;
        yield return new WaitForSeconds(AfterWaveWaitTime());

        for (int i = 0; i < level1Wave2Spawns[0]; i++) SpawnPepe();
        for (int i = 0; i < level1Wave2Spawns[1]; i++) SpawnKeyboardCat();
        for (int i = 0; i < level1Wave2Spawns[2]; i++) SpawnTroll();
        for (int i = 0; i < level1Wave2Spawns[3]; i++) SpawnShoopDaWhoop();

        while (GameObject.FindGameObjectsWithTag("enemy").Length != 0) ;
        yield return new WaitForSeconds(AfterWaveWaitTime());

        for (int i = 0; i < level1Wave3Spawns[0]; i++) SpawnPepe();
        for (int i = 0; i < level1Wave3Spawns[1]; i++) SpawnKeyboardCat();
        for (int i = 0; i < level1Wave3Spawns[2]; i++) SpawnTroll();
        for (int i = 0; i < level1Wave3Spawns[3]; i++) SpawnShoopDaWhoop();

        while (GameObject.FindGameObjectsWithTag("enemy").Length != 0) ;
        yield return new WaitForSeconds(AfterWaveWaitTime());

        for (int i = 0; i < level1Wave4Spawns[0]; i++) SpawnPepe();
        for (int i = 0; i < level1Wave4Spawns[1]; i++) SpawnKeyboardCat();
        for (int i = 0; i < level1Wave4Spawns[2]; i++) SpawnTroll();
        for (int i = 0; i < level1Wave4Spawns[3]; i++) SpawnShoopDaWhoop();

        while (GameObject.FindGameObjectsWithTag("enemy").Length != 0) ;
        yield return new WaitForSeconds(AfterLevelWaitTime());

        StartCoroutine(Level2());
    }

    IEnumerator Level2()
    {
        for (int i = 0; i < level2Wave1Spawns[0]; i++) SpawnPepe();
        for (int i = 0; i < level2Wave1Spawns[1]; i++) SpawnKeyboardCat();
        for (int i = 0; i < level2Wave1Spawns[2]; i++) SpawnTroll();
        for (int i = 0; i < level2Wave1Spawns[3]; i++) SpawnShoopDaWhoop();

        while (GameObject.FindGameObjectsWithTag("enemy").Length != 0) ;
        yield return new WaitForSeconds(AfterWaveWaitTime());

        for (int i = 0; i < level2Wave2Spawns[0]; i++) SpawnPepe();
        for (int i = 0; i < level2Wave2Spawns[1]; i++) SpawnKeyboardCat();
        for (int i = 0; i < level2Wave2Spawns[2]; i++) SpawnTroll();
        for (int i = 0; i < level2Wave2Spawns[3]; i++) SpawnShoopDaWhoop();

        while (GameObject.FindGameObjectsWithTag("enemy").Length != 0) ;
        yield return new WaitForSeconds(AfterWaveWaitTime());

        for (int i = 0; i < level2Wave3Spawns[0]; i++) SpawnPepe();
        for (int i = 0; i < level2Wave3Spawns[1]; i++) SpawnKeyboardCat();
        for (int i = 0; i < level2Wave3Spawns[2]; i++) SpawnTroll();
        for (int i = 0; i < level2Wave3Spawns[3]; i++) SpawnShoopDaWhoop();

        while (GameObject.FindGameObjectsWithTag("enemy").Length != 0) ;
        yield return new WaitForSeconds(AfterWaveWaitTime());

        for (int i = 0; i < level2Wave4Spawns[0]; i++) SpawnPepe();
        for (int i = 0; i < level2Wave4Spawns[1]; i++) SpawnKeyboardCat();
        for (int i = 0; i < level2Wave4Spawns[2]; i++) SpawnTroll();
        for (int i = 0; i < level2Wave4Spawns[3]; i++) SpawnShoopDaWhoop();

        while (GameObject.FindGameObjectsWithTag("enemy").Length != 0) ;
        yield return new WaitForSeconds(AfterLevelWaitTime());

        StartCoroutine(Level3());
    }

    IEnumerator Level3()
    {
        for (int i = 0; i < level3Wave1Spawns[0]; i++) SpawnPepe();
        for (int i = 0; i < level3Wave1Spawns[1]; i++) SpawnKeyboardCat();
        for (int i = 0; i < level3Wave1Spawns[2]; i++) SpawnTroll();
        for (int i = 0; i < level3Wave1Spawns[3]; i++) SpawnShoopDaWhoop();

        while (GameObject.FindGameObjectsWithTag("enemy").Length != 0) ;
        yield return new WaitForSeconds(AfterWaveWaitTime());

        for (int i = 0; i < level3Wave2Spawns[0]; i++) SpawnPepe();
        for (int i = 0; i < level3Wave2Spawns[1]; i++) SpawnKeyboardCat();
        for (int i = 0; i < level3Wave2Spawns[2]; i++) SpawnTroll();
        for (int i = 0; i < level3Wave2Spawns[3]; i++) SpawnShoopDaWhoop();

        while (GameObject.FindGameObjectsWithTag("enemy").Length != 0) ;
        yield return new WaitForSeconds(AfterWaveWaitTime());

        for (int i = 0; i < level3Wave3Spawns[0]; i++) SpawnPepe();
        for (int i = 0; i < level3Wave3Spawns[1]; i++) SpawnKeyboardCat();
        for (int i = 0; i < level3Wave3Spawns[2]; i++) SpawnTroll();
        for (int i = 0; i < level3Wave3Spawns[3]; i++) SpawnShoopDaWhoop();

        while (GameObject.FindGameObjectsWithTag("enemy").Length != 0) ;
        yield return new WaitForSeconds(AfterWaveWaitTime());

        for (int i = 0; i < level3Wave4Spawns[0]; i++) SpawnPepe();
        for (int i = 0; i < level3Wave4Spawns[1]; i++) SpawnKeyboardCat();
        for (int i = 0; i < level3Wave4Spawns[2]; i++) SpawnTroll();
        for (int i = 0; i < level3Wave4Spawns[3]; i++) SpawnShoopDaWhoop();

        while (GameObject.FindGameObjectsWithTag("enemy").Length != 0) ;
        yield return new WaitForSeconds(AfterLevelWaitTime());

        StartCoroutine(Level4());
    }

    IEnumerator Level4()
    {
        for (int i = 0; i < level4Wave1Spawns[0]; i++) SpawnPepe();
        for (int i = 0; i < level4Wave1Spawns[1]; i++) SpawnKeyboardCat();
        for (int i = 0; i < level4Wave1Spawns[2]; i++) SpawnTroll();
        for (int i = 0; i < level4Wave1Spawns[3]; i++) SpawnShoopDaWhoop();

        while (GameObject.FindGameObjectsWithTag("enemy").Length != 0) ;
        yield return new WaitForSeconds(AfterWaveWaitTime());

        for (int i = 0; i < level4Wave2Spawns[0]; i++) SpawnPepe();
        for (int i = 0; i < level4Wave2Spawns[1]; i++) SpawnKeyboardCat();
        for (int i = 0; i < level4Wave2Spawns[2]; i++) SpawnTroll();
        for (int i = 0; i < level4Wave2Spawns[3]; i++) SpawnShoopDaWhoop();

        while (GameObject.FindGameObjectsWithTag("enemy").Length != 0) ;
        yield return new WaitForSeconds(AfterWaveWaitTime());

        for (int i = 0; i < level4Wave3Spawns[0]; i++) SpawnPepe();
        for (int i = 0; i < level4Wave3Spawns[1]; i++) SpawnKeyboardCat();
        for (int i = 0; i < level4Wave3Spawns[2]; i++) SpawnTroll();
        for (int i = 0; i < level4Wave3Spawns[3]; i++) SpawnShoopDaWhoop();

        while (GameObject.FindGameObjectsWithTag("enemy").Length != 0) ;
        yield return new WaitForSeconds(AfterWaveWaitTime());

        for (int i = 0; i < level4Wave4Spawns[0]; i++) SpawnPepe();
        for (int i = 0; i < level4Wave4Spawns[1]; i++) SpawnKeyboardCat();
        for (int i = 0; i < level4Wave4Spawns[2]; i++) SpawnTroll();
        for (int i = 0; i < level4Wave4Spawns[3]; i++) SpawnShoopDaWhoop();

        while (GameObject.FindGameObjectsWithTag("enemy").Length != 0) ;
    }
}
