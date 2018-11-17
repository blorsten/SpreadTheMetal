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

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void FireFire()
    {
        animator.SetTrigger("Shoot");
        firePushTimer = firePushTime;
    }

    private void Update()
    {
        if (firePushTimer > 0)
        {
            foreach (EnemyMovement enemy in enemies)
            {
                enemy.Push(enemy.transform.position - transform.position, firePushForce);
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
            enemies.Add(collision.GetComponent<EnemyMovement>());
        }
    }
}
