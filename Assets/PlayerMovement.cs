using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private int speed = 5;

    private Animator animator;
    private float startScale;

    // Use this for initialization
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        startScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(startScale, transform.localScale.y, transform.localScale.z);
            animator.SetBool("walking", true);
            transform.position -= transform.right * -speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-startScale, transform.localScale.y, transform.localScale.z);
            animator.SetBool("walking", true);
            transform.position += transform.right * -speed * Time.deltaTime;
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }
}
