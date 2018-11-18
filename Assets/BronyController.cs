using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BronyController : MonoBehaviour
{
    public enum BronyState { Seeking, Elevating, Hovering, Slamming }

    public bool actvated;
    public float slamSpeed;
    public float distanceToSlam;
    public float slamHeight;
    public float slamRaiseSpeed = .5f;
    public BronyState state = BronyState.Seeking;

    private float slamTimer;
    private Transform playerTransform;
    private Rigidbody2D rb;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (actvated)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);
            if (distanceToPlayer <= distanceToSlam && state == BronyState.Seeking)
            {
                state = BronyState.Elevating;
                rb.gravityScale = 0;
            }

            if (state == BronyState.Elevating)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, slamHeight), slamRaiseSpeed);

                if (Vector2.Distance(transform.position, new Vector2(transform.position.x, slamHeight)) < .1f)
                {
                    state = BronyState.Hovering;
                }
            }

            if (state == BronyState.Hovering)
            {
                Vector2 target = new Vector2(playerTransform.position.x, slamHeight);
                transform.position = Vector2.Lerp(transform.position, target, slamRaiseSpeed);

                if (Vector2.Distance(transform.position, target) < .1f)
                {
                    state = BronyState.Slamming;
                }
            }

            if (state == BronyState.Slamming)
            {
                rb.gravityScale = 1;
                rb.AddForce(new Vector2(0, -1) * slamSpeed);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Damage player
        }
    }

    public void Activate()
    {
        actvated = true;
    }
}
