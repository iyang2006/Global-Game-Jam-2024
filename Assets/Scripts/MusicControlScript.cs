using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControlScript : MonoBehaviour
{

    [SerializeField] private AudioSource buildup;
    [SerializeField] private AudioSource mainBGM;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayMusic());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool buildupPlayingFalse() {
        return buildup.isPlaying == false;
    }

    private bool mainPlayingFalse() {
        return mainBGM.isPlaying == false;
    }

    IEnumerator PlayMusic() {
        buildup.Play();
        yield return new WaitUntil(buildupPlayingFalse);
        mainBGM.Play();
        yield return new WaitUntil(mainPlayingFalse);
        yield break;
    }
}
