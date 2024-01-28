using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SmokeController : MonoBehaviour
{

    [SerializeField] private MeshRenderer smokeMesh;
    [SerializeField] private float fadeRate;
    [SerializeField] private float initialAlpha;
    private float currAlpha;
    private Color tempCol;

    // Start is called before the first frame update
    void Start()
    {
        // currAlpha = initialAlpha;
        // tempCol = smokeMesh.material.color;
        // tempCol.a = currAlpha;
        // smokeMesh.material.color = tempCol;
        StartCoroutine(Fade());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fade() {
        //Debug.Log("fade");
        // while (currAlpha > 0) {
        //     currAlpha -= fadeRate;
        //     tempCol = smokeMesh.material.color;
        //     tempCol.a = currAlpha;
        //     smokeMesh.material.color = tempCol;
        //     yield return new WaitForEndOfFrame();
        // }
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
        yield break;
    }
}
