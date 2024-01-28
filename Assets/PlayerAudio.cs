using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource reload;
    [SerializeField] private AudioSource powerUp;
    [SerializeField] private AudioSource powerDown;
    [SerializeField] private AudioSource hit;
    [SerializeField] private AudioSource powerHit;
    [SerializeField] private AudioSource dash;
    [SerializeField] private AudioSource jump;

    public void PlayReload() {
        reload.Play();
    }
    public void PlayPowerup() {
        powerUp.Play();
    }
    public void PlayPowerDown() {
        powerDown.Play();
    }
    public void PlayHit() {
        hit.Play();
    }
    public void PlayPowerHit() {
        powerHit.Play();
    }
    public void PlayDash() {
        dash.Play();
    }
    public void PlayJump() {
        jump.Play();
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
