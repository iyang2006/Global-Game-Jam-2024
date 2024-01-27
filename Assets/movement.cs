using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    [SerializeField] private Transform playerPos;
    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private Camera cam;
    [SerializeField] private float speed;
    [SerializeField] private float jumpStrength;
    [SerializeField] private float dashLength;
    

    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move_offset = Vector3.zero;
    }
}
