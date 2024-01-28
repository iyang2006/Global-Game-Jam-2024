using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FootColliderHelper : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerMovement pmove;
    void Start()
    {
        pmove = this.gameObject.GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "world") { 
            pmove.SetGround(true);
        }
    }

    private void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "world") { 
            pmove.SetGround(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
