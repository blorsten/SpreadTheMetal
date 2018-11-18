using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyColor
{
    None,
    Green,
    Purple,
    yellow,
    Orange
}

public class EnemyMovement : MonoBehaviour
{
    public float jumpInterval = 1;
    public float jumpForce = 100;
    public EnemyColor color = EnemyColor.None;

    [Header("Prefabs")]
    public GameObject purplePrefab;
    public GameObject greenPrefab;
    public GameObject yellowPrefab;
    public GameObject orangePrefab;
    public float health = 100;
    public GameObject explotion;
    public float speed = 10;

    private Transform playerTransform;
    private Rigidbody2D rb;
    private float jumpTimer = 0;

    public List<AudioClip> ponySoundClips = new List<AudioClip>();
    public AudioSource audioSource;



    // Use this for initialization
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        jumpTimer = jumpInterval;

        if (color == EnemyColor.None)
        {
            //TODO CHANGE TO 3 when yellow prefab is available
            color = (EnemyColor)Random.Range(1, 4);
            GameObject toSpawn = null;

            switch (color)
            {
                case EnemyColor.Green:
                    toSpawn = greenPrefab;
                    break;
                case EnemyColor.Purple:
                    toSpawn = purplePrefab;
                    break;
                case EnemyColor.yellow:
                    toSpawn = yellowPrefab;
                    break;
                case EnemyColor.Orange:
                    toSpawn = orangePrefab;
                    break;
            }

            Instantiate(toSpawn, transform);
            playPonySound();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (color == EnemyColor.Green || color == EnemyColor.Purple)
        {
            if (jumpTimer <= 0)
            {
                jumpTimer = jumpInterval;
                Vector2 direction = (playerTransform.position - transform.position).normalized;
                direction.y = 1;

                rb.AddForce(direction * jumpForce, ForceMode2D.Impulse);
            }
            else
            {
                jumpTimer -= Time.deltaTime;
            }
        }
        else
        {
            rb.gravityScale = 0;
            rb.MovePosition(transform.position + (new Vector3(-1, 0) * Time.deltaTime * speed));
        }
    }

    public void Damage(Vector2 dir, float force, float damage)
    {
        health -= damage * Time.deltaTime;
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explotion, transform.position, Quaternion.identity);
        }
    }

    void playPonySound(){
        audioSource.PlayOneShot(ponySoundClips[Random.Range(0, ponySoundClips.Count - 1)]);
    }

}
