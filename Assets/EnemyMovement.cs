using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyColor
{
    None,
    Green,
    Purple,
    yellow
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
            color = (EnemyColor)Random.Range(1, 2);
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
            }

            Instantiate(toSpawn, transform);
            playPonySound();
        }
    }

    // Update is called once per frame
    void Update()
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

    public void Push(Vector2 dir, float force)
    {
        rb.AddForce(dir * force);
    }

    void playPonySound(){
        audioSource.PlayOneShot(ponySoundClips[Random.Range(0, ponySoundClips.Count - 1)]);
    }

}
