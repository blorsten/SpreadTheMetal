using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bronyTrigger : MonoBehaviour
{
    public BronyController controller;
    public Spawner spawner;
    public AudioSource audioSource;
    public AudioClip introClip;
    public AudioClip BossClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            controller.Activate();
            spawner.gameObject.SetActive(false);
            audioSource.Stop();
            audioSource.clip = introClip;
            audioSource.Play();
            audioSource.volume = .5f;
            StartCoroutine(playNext(audioSource.clip.length));
        }
    }

    IEnumerator playNext(float time)
    {
        yield return new WaitForSeconds(time);
        audioSource.Stop();
        audioSource.clip = BossClip;
        audioSource.Play();
        audioSource.volume = .5f;
    }
}
