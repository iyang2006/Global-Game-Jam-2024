using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public static int level = 1;
    [SerializeField] int firstLevelFirstWavePepeSpawns;
    [SerializeField] int firstLevelFirstWaveKeyboardCatSpawns;
    [SerializeField] int firstLevelFirstWaveTrollSpawns;
    [SerializeField] int firstLevelFirstWaveShoopDaWhoopSpawns;

    [SerializeField] int firstLevelSecondWavePepeSpawns;
    [SerializeField] int firstLevelSecondWaveKeyboardCatSpawns;
    [SerializeField] int firstLevelSecondWaveTrollSpawns;
    [SerializeField] int firstLevelSecondWaveShoopDaWhoopSpawns;

    [SerializeField] int firstLevelThirdWavePepeSpawns;
    [SerializeField] int firstLevelThirdWaveKeyboardCatSpawns;
    [SerializeField] int firstLevelThirdWaveTrollSpawns;
    [SerializeField] int firstLevelThirdWaveShoopDaWhoopSpawns;

    [SerializeField] int firstLevelFourthWavePepeSpawns;
    [SerializeField] int firstLevelFourthWaveKeyboardCatSpawns;
    [SerializeField] int firstLevelFourthWaveTrollSpawns;
    [SerializeField] int firstLevelFourthWaveShoopDaWhoopSpawns;

    [SerializeField] int secondLevelFirstWavePepeSpawns;
    [SerializeField] int secondLevelFirstWaveKeyboardCatSpawns;
    [SerializeField] int secondLevelFirstWaveTrollSpawns;
    [SerializeField] int secondLevelFirstWaveShoopDaWhoopSpawns;

    [SerializeField] int secondLevelSecondWavePepeSpawns;
    [SerializeField] int secondLevelSecondWaveKeyboardCatSpawns;
    [SerializeField] int secondLevelSecondWaveTrollSpawns;
    [SerializeField] int secondLevelSecondWaveShoopDaWhoopSpawns;

    [SerializeField] int secondLevelThirdWavePepeSpawns;
    [SerializeField] int secondLevelThirdWaveKeyboardCatSpawns;
    [SerializeField] int secondLevelThirdWaveTrollSpawns;
    [SerializeField] int secondLevelThirdWaveShoopDaWhoopSpawns;

    [SerializeField] int secondLevelFourthWavePepeSpawns;
    [SerializeField] int secondLevelFourthWaveKeyboardCatSpawns;
    [SerializeField] int secondLevelFourthWaveTrollSpawns;
    [SerializeField] int secondLevelFourthWaveShoopDaWhoopSpawns;

    [SerializeField] int thirdLevelFirstWavePepeSpawns;
    [SerializeField] int thirdLevelFirstWaveKeyboardCatSpawns;
    [SerializeField] int thirdLevelFirstWaveTrollSpawns;
    [SerializeField] int thirdLevelFirstWaveShoopDaWhoopSpawns;

    [SerializeField] int thirdLevelSecondWavePepeSpawns;
    [SerializeField] int thirdLevelSecondWaveKeyboardCatSpawns;
    [SerializeField] int thirdLevelSecondWaveTrollSpawns;
    [SerializeField] int thirdLevelSecondWaveShoopDaWhoopSpawns;

    [SerializeField] int thirdLevelThirdWavePepeSpawns;
    [SerializeField] int thirdLevelThirdWaveKeyboardCatSpawns;
    [SerializeField] int thirdLevelThirdWaveTrollSpawns;
    [SerializeField] int thirdLevelThirdWaveShoopDaWhoopSpawns;

    [SerializeField] int thirdLevelFourthWavePepeSpawns;
    [SerializeField] int thirdLevelFourthWaveKeyboardCatSpawns;
    [SerializeField] int thirdLevelFourthWaveTrollSpawns;
    [SerializeField] int thirdLevelFourthWaveShoopDaWhoopSpawns;

    [SerializeField] int fourthLevelFirstWavePepeSpawns;
    [SerializeField] int fourthLevelFirstWaveKeyboardCatSpawns;
    [SerializeField] int fourthLevelFirstWaveTrollSpawns;
    [SerializeField] int fourthLevelFirstWaveShoopDaWhoopSpawns;

    [SerializeField] int fourthLevelSecondWavePepeSpawns;
    [SerializeField] int fourthLevelSecondWaveKeyboardCatSpawns;
    [SerializeField] int fourthLevelSecondWaveTrollSpawns;
    [SerializeField] int fourthLevelSecondWaveShoopDaWhoopSpawns;

    [SerializeField] int fourthLevelThirdWavePepeSpawns;
    [SerializeField] int fourthLevelThirdWaveKeyboardCatSpawns;
    [SerializeField] int fourthLevelThirdWaveTrollSpawns;
    [SerializeField] int fourthLevelThirdWaveShoopDaWhoopSpawns;

    [SerializeField] int fourthLevelFourthWavePepeSpawns;
    [SerializeField] int fourthLevelFourthWaveKeyboardCatSpawns;
    [SerializeField] int fourthLevelFourthWaveTrollSpawns;
    [SerializeField] int fourthLevelFourthWaveShoopDaWhoopSpawns;

    [SerializeField] float afterFirstWaveWaitTime;
    [SerializeField] float afterFirstLevelWaitTime;
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
        Level1();
        Level2();
        Level3();
        Level4();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    //float s = log;

    IEnumerator Level1()
    {
        for (int i = 1; i < firstLevelFirstWavePepeSpawns; i++) 
        yield return new WaitForSeconds(1);
    }

    void Level2()
    {

    }

    void Level3()
    {

    }

    void Level4()
    {

    }
}
