using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BronyController : MonoBehaviour
{
    public enum BronyState { Seeking, Elevating, Hovering, Slamming, Resting }

    public bool actvated;
    public float slamSpeed;
    public float distanceToSlam;
    public float slamHeight;
    public float slamRaiseSpeed = .5f;
    public float restingTime = 5;
    public BronyState state = BronyState.Seeking;

    public List<AudioClip> bronySounds = new List<AudioClip>();
    public AudioSource audioSource;

    public float audioInterval = 1;
    private float audioTimer;

    private Vector2 playerTarget;
    private float restingTimer;
    private float slamTimer;
    private Transform playerTransform;
    private Rigidbody2D rb;
    private SpriteRenderer spr;

    public int HP = 3;

    public Color purple;
    public Color yellow;
    public Color orange;
    public Color green;

    public EnemyColor color = EnemyColor.None;
    public GameObject explotion;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (playerTransform.position.x < transform.position.x)
            spr.flipX = true;
        else
            spr.flipX = false;

        if (actvated)
        {
            if (audioTimer <= 0)
            {
                audioSource.PlayOneShot(bronySounds[Random.Range(0, bronySounds.Count - 1)]);
                audioTimer = audioInterval;
            }
            else
            {
                audioTimer -= Time.deltaTime;
            }

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
                if (playerTarget == Vector2.zero)
                    playerTarget = new Vector2(playerTransform.position.x, slamHeight);

                transform.position = Vector2.Lerp(transform.position, playerTarget, slamRaiseSpeed);

                if (Vector2.Distance(transform.position, playerTarget) < .1f)
                {
                    playerTarget = Vector2.zero;
                    state = BronyState.Slamming;
                }
            }

            if (state == BronyState.Slamming)
            {
                rb.gravityScale = 1;
                rb.AddForce(new Vector2(0, -1) * slamSpeed);
            }

            if (state == BronyState.Resting)
            {
                if (restingTimer <= 0)
                {
                    state = BronyState.Seeking;
                    spr.color = Color.white;
                    color = EnemyColor.None;
                }
                else
                    restingTimer -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (state == BronyState.Slamming)
        {
            state = BronyState.Resting;
            restingTimer = restingTime;
            CameraShaker.Instance.ShakeOnce(7, 7, .5f, 1);

            color = (EnemyColor)Random.Range(1, 4);
            switch (color)
            {
                case EnemyColor.Green:
                    spr.color = green;
                    break;
                case EnemyColor.Purple:
                    spr.color = purple;
                    break;
                case EnemyColor.yellow:
                    spr.color = yellow;
                    break;
                case EnemyColor.Orange:
                    spr.color = orange;
                    break;
            }
        }

        if (collision.tag == "Player")
        {
            //Damage player
        }

    }

    public void Damage()
    {
        if (state == BronyState.Resting)
        {
            HP--;
            if (HP <= 0)
            {
                Instantiate(explotion, transform.position, Quaternion.identity);
                CameraShaker.Instance.ShakeOnce(10, 10, .5f, 1);
                playerTransform.GetComponent<PlayerMovement>().WinStance();
                Destroy(gameObject);
            }
            state = BronyState.Seeking;
            spr.color = Color.white;
        }
    }

    public void Activate()
    {
        actvated = true;
    }
}
