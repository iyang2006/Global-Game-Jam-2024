using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    [SerializeField] private AudioSource ylyl;
    [SerializeField] private SceneSwitch switcher;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Death());
    }

    private bool YLYLplaying() {
        return ylyl.isPlaying == false;
    }

    IEnumerator Death() {
        yield return new WaitUntil(YLYLplaying);
        yield return new WaitForSeconds(1);
        switcher.SwitchScene();
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
