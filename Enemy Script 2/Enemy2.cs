using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour {

    public Transform visionPoint;
    private Player player;

    public Transform Player;

    public float visionAngle = 30f;
    public float visionDistance = 10f;
    public float chaseDistance = 10f;
    public float moveSpeed;
    public float stoppingDistance;

    private Transform target;

    private Vector3? lastKnownPlayerPosition;
    // Use this for initialization
    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
        {
            Vector3 lookAt = Player.position;
            lookAt.y = transform.position.y;
            transform.LookAt(lookAt);
        }



    void FixedUpdate ()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    void Look () {
        Vector3 deltaToPlayer = player.transform.position - visionPoint.position;
        Vector3 directionToPlayer = deltaToPlayer.normalized;

        float dot = Vector3.Dot (transform.forward, directionToPlayer);

        if (dot < 0) {
            return;
        }

        float distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer > visionDistance)
        {
            return;
        }

        float angle = Vector3.Angle (transform.forward, directionToPlayer);

        if(angle > visionAngle)
        {
            return;
        }

        RaycastHit hit;
        if(Physics.Raycast(transform.position, directionToPlayer, out hit, visionDistance))
        {
            if (hit.collider.gameObject == player.gameObject)
            {
                lastKnownPlayerPosition = player.transform.position;
            }
        }
    }
}