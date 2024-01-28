using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.VirtualTexturing;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform this_enemy;
    private Transform player;
    private NavMeshPath path;
    [SerializeField] public float speed;
    [SerializeField] public float turnSpeed;
    private Vector3 boxSize;
    private bool flankDir;
    [SerializeField] private float rayDist;
    [SerializeField] private float flankDist;
    [SerializeField] private bool seeThroughWalls;
    public bool isCharging;
    private Vector3 latestPlayerPosition;


    void Start()
    {
        player = GameObject.FindWithTag("dummyPlayer").GetComponent<Transform>();
        path = new NavMeshPath();
        //boxSize = GetComponent<BoxCollider>().size;
        boxSize = GetComponentInChildren<BoxCollider>().size;
        isCharging = false;
    }
    void FixedUpdate()
    {
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("enemy");
        LayerMask mask2 = LayerMask.GetMask("dummyPlayer");
        if (seeThroughWalls)
        {
            mask = ~mask2;
        }
        if (Physics.Raycast(GetComponent<Transform>().position, player.position - this_enemy.position, out hit, Mathf.Infinity, ~mask))
        {
            if (hit.collider.gameObject.transform == player)
            {
                NavMesh.CalculatePath(this_enemy.position, player.position, NavMesh.AllAreas, path);
                //agent.SetDestination(player.position);
                //Vector3 targetDir = player.position - this_enemy.position;
                Vector3 targetDir = path.corners[0] - this_enemy.position;
                //Debug.Log(path.corners[1]);
                Vector3 newDir = Vector3.RotateTowards(this_enemy.forward, targetDir, turnSpeed * Time.fixedDeltaTime, 0.0f);
                this_enemy.rotation = Quaternion.LookRotation(newDir);

                for (int i = 0; i < path.corners.Length - 1; i++)
                {
                    Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
                }
                Vector3 move_offset = this_enemy.forward;
                RaycastHit leftHit;
                RaycastHit rightHit;
                bool leftHitBool = Physics.Raycast((this_enemy.position + (this_enemy.right * -1 * boxSize.x * 0.51f)), (this_enemy.right * -1), out leftHit, rayDist, mask);
                bool rightHitBool = Physics.Raycast((this_enemy.position + (this_enemy.right * boxSize.x * 0.51f)), this_enemy.right, out rightHit, rayDist, mask);
                if (leftHitBool && !rightHitBool)
                {
                    move_offset += this_enemy.right * 1;
                }
                else if (!leftHitBool && rightHitBool)
                {
                    move_offset += this_enemy.right * -1;
                }
                else if (leftHitBool && rightHitBool)
                {
                    move_offset += this_enemy.right * (rightHit.distance - leftHit.distance) * -1;
                }
                RaycastHit frontHit;
                if (hit.distance < flankDist)
                {

                    /*Vector3 targetPos;
                    if (isCharging)
                    {
                        targetPos = latestPlayerPosition;
                    } else
                    {
                        targetPos = player.position;
                        latestPlayerPosition = targetPos;
                    }*/
                    Vector3 targetPos = player.position;
                    if (!isCharging)
                    {
                        latestPlayerPosition = targetPos;
                    }

                    float angle = Vector3.Angle(this_enemy.right, (this_enemy.position - targetPos));
                    if (angle < 90)
                    {
                        flankDir = true;
                    }
                    else
                    {
                        flankDir = false;
                    }
                    Vector3 flank_offset = this_enemy.right;
                    if (flankDir == false)
                    {
                        flank_offset *= -1;
                    }
                    //Debug.DrawLine(this_enemy.position, (this_enemy.position + flank_offset), Color.white);
                    move_offset += flank_offset;
                }

                if (Physics.Raycast((this_enemy.position + (this_enemy.forward * boxSize.z * 0.51f)), this_enemy.forward, out frontHit, rayDist, mask))
                {

                    /*Vector3 targetPos;
                    if (isCharging)
                    {
                        targetPos = latestPlayerPosition;
                    }
                    else
                    {
                        targetPos = frontHit.collider.gameObject.transform.position;
                        latestPlayerPosition = targetPos;
                    }*/
                    Vector3 targetPos = frontHit.collider.gameObject.transform.position;
                    if (!isCharging)
                    {
                        latestPlayerPosition = targetPos;
                    }

                    float angle = Vector3.Angle(this_enemy.right, (this_enemy.position - targetPos));
                    if (angle < 90)
                    {
                        flankDir = true;
                    }
                    else
                    {
                        flankDir = false;
                    }
                    Vector3 flank_offset = this_enemy.right;
                    if (flankDir == false)
                    {
                        flank_offset *= -1;
                    }
                    //Debug.DrawLine(this_enemy.position, (this_enemy.position + flank_offset), Color.white);
                    move_offset += flank_offset;
                }

                move_offset = move_offset.normalized;
                //string pos_debug = "" + move_offset.x + " " + move_offset.y + " " + move_offset.z;
                Debug.DrawLine(this_enemy.position, (this_enemy.position + 2 * move_offset), Color.blue);

                //agent.Move(move_offset * speed * Time.fixedDeltaTime);
                if (isCharging)
                {
                    //Vector3 forward = new Vector3(0, 0, 1);
                    agent.Move(this_enemy.forward * speed * Time.fixedDeltaTime);
                }
                else
                {
                    agent.Move(move_offset * speed * Time.fixedDeltaTime);
                }

            }

        }

    }
}
