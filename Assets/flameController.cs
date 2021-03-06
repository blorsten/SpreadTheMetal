﻿using System.Collections;
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
    public float damage = 10;

    public BronyController brony;

    private EnemyColor lastColor;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void FireFire(EnemyColor color)
    {
        lastColor = color;
        animator.SetTrigger("Shoot");
        firePushTimer = firePushTime;
        playGuitarSound();
    }

    private void Update()
    {
        if (firePushTimer > 0)
        {
            if (brony != null && brony.color == lastColor)
                brony.Damage();

            firePushTimer -= Time.deltaTime;
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                if (enemies[i].color == lastColor)
                    enemies[i].Damage((enemies[i].transform.position - transform.position).normalized, firePushForce, damage);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (firePushTimer > 0)
        {
            if (collision.gameObject.tag == "Brony" && brony.color == lastColor)
            {
                brony.Damage();
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

    void playGuitarSound()
    {

        audioSource.PlayOneShot(guitarSoundClips[Random.Range(0, guitarSoundClips.Count - 1)]);
    }

}
