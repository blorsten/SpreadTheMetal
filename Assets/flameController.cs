using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flameController : MonoBehaviour
{
    Animator animator;
    List<EnemyMovement> enemies = new List<EnemyMovement>();
    public float firePushTime = 1;
    public float firePushForce = 1;
    float firePushTimer;
    public float damage = 10;

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
    }

    private void Update()
    {
        if (firePushTimer > 0)
        {
            firePushTimer -= Time.deltaTime;
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                if (enemies[i].color == lastColor)
                    enemies[i].Damage((enemies[i].transform.position - transform.position).normalized, firePushForce, damage);
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
}
