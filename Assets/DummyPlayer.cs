using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayer : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(player.transform.position, (-1 * player.transform.up), out RaycastHit hit, 128, layerMask);
        transform.position = hit.point;
    }
}
