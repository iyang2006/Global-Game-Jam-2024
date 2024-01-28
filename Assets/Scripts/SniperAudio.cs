using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAudio : MonoBehaviour
{

    [SerializeField] private AudioSource shot;
    [SerializeField] private AudioSource empty;
    [SerializeField] private AudioSource powershot;

    public void PlayShot() {
        shot.Play();
    }

    public void PlayEmpty() {
        empty.Play();
    }

    public void PlayPowershot() {
        powershot.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
