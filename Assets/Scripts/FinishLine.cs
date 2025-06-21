using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayTime = 2f;
    [SerializeField] ParticleSystem particles;
    [SerializeField] SurfaceEffector2D surfaceEffector;
    [SerializeField] float stopSpeed = 0.0f;
    [SerializeField] AudioClip crashClip;
    AudioSource audioSource;
    private void Start()
    {
        surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (audioSource == null)
                Debug.LogError("AudioSource is NULL!");

            if (crashClip == null)
                Debug.LogError("crashClip AudioClip is NULL!");

            if (audioSource != null && crashClip != null)
            {
                audioSource.PlayOneShot(crashClip);
            }

            surfaceEffector.speed = stopSpeed;
            particles.Play();
            Invoke("LoadTheScene", delayTime);
            //Debug.Log("Finished");
        }
    }

    void LoadTheScene()
    {
        SceneManager.LoadScene(0);
        
    }
}
