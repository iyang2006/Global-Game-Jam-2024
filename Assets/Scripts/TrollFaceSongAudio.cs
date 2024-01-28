using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollFaceSongAudio : MonoBehaviour
{
    public AudioSource audioSouceConst;

    // Start is called before the first frame update
    void Start()
    {
        audioSouceConst.loop = true;
        audioSouceConst.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
