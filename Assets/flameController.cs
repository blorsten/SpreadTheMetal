using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flameController : MonoBehaviour
{
    Animator animator;
    List<EnemyMovement> enemies = new List<EnemyMovement>();
   public List<AudioClip> guitarSoundClips = new List<AudioClip>();
    public float firePushTime = 1;
    public float firePushForce = 1;
    float firePushTimer;
    public AudioSource audioSource;



    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void FireFire()
    {
        animator.SetTrigger("Shoot");
        firePushTimer = firePushTime;
        playGuitarSound();
    }

    private void Update()
    {
        if (firePushTimer > 0){

            firePushTimer -= Time.deltaTime;
            foreach (EnemyMovement enemy in enemies)
            {
                enemy.Push((enemy.transform.position - transform.position).normalized, firePushForce);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemies.Add(collision.GetComponent<EnemyMovement>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemies.Remove(collision.GetComponent<EnemyMovement>());
        }
    }

    void playGuitarSound(){

        audioSource.PlayOneShot(guitarSoundClips[Random.Range(0, guitarSoundClips.Count - 1)]);
    }

}
