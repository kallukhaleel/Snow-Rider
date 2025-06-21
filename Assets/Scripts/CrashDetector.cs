using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField]float delayTime = 1f;
    [SerializeField] ParticleSystem crashParticle;

 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            crashParticle.Play();
            Invoke("LoadTheScene", delayTime);
        }
    }
    void LoadTheScene()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Ouch!!!");
    }
}
