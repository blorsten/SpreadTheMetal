using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bronyTrigger : MonoBehaviour
{
    public BronyController controller;
    public Spawner spawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            controller.Activate();
            spawner.gameObject.SetActive(false);
        }
    }
}
