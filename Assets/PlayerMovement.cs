using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public Text hp;

public class PlayerMovement : MonoBehaviour
{

  
    public List<AudioClip> footstepClips = new List<AudioClip>(); 

    [SerializeField]
    private int speed = 5;
    public AudioSource audioSource;
    private float timer;
    private float interval = 0.2f;
    private bool canPlaySound;
    
    

    private Animator animator;
    private float startScale;

    // Use this for initialization
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        startScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update() {

        checkIfCanPlaySound();

        if (Input.GetKey(KeyCode.D))
        {
            doesPlaySound();
  
            transform.localScale = new Vector3(startScale, transform.localScale.y, transform.localScale.z);
            animator.SetBool("walking", true);
            transform.position -= transform.right * -speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {

            doesPlaySound();
            transform.localScale = new Vector3(-startScale, transform.localScale.y, transform.localScale.z);
            animator.SetBool("walking", true);
            transform.position += transform.right * -speed * Time.deltaTime;
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }

    void checkIfCanPlaySound() {
       
        if (timer <= 0)
        {

            canPlaySound = true;
        }
        else
        {

            timer -= Time.deltaTime;
        }
    }

    void doesPlaySound(){
       
        if (canPlaySound == true) {
            canPlaySound = false;
            timer = interval;
            playFootstep();
        }
    }

    void playFootstep(){
        audioSource.PlayOneShot(footstepClips[Random.Range(0,footstepClips.Count-1)]);
    }



}
