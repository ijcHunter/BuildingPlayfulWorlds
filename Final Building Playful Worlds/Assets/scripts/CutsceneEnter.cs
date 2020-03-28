using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneEnter : MonoBehaviour
{
    public GameObject player;
    public GameObject CutsceneCamera;

    public ParticleSystem verzamelParticles1;
    public ParticleSystem verzamelParticles2;
    public ParticleSystem verzamelParticles3;
    public ParticleSystem verzamelParticles4;
    public ParticleSystem verzamelParticles5;
    public ParticleSystem verzamelParticles6;
    public ParticleSystem verzamelParticles7;

    public AudioSource whispers;
    public AudioSource DoorlopendeAudio;

    


    void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        CutsceneCamera.SetActive(true);
        player.SetActive(false);

        verzamelParticles1.Play();
        verzamelParticles2.Play();
        verzamelParticles3.Play();
        verzamelParticles4.Play();
        verzamelParticles5.Play();
        verzamelParticles6.Play();
        verzamelParticles7.Play();

        whispers.Play();
        StartCoroutine(FinishCut());
        DoorlopendeAudio.Stop();




    }


    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(12f);

        player.SetActive(true);
        player.GetComponent<PlayerController>().upKey = 0;
        player.GetComponent<PlayerController>().downKey = 0;
        player.GetComponent<PlayerController>().leftKey = 0;
        player.GetComponent<PlayerController>().rightKey = 0;
        
        CutsceneCamera.SetActive(false);
        whispers.Stop();
        DoorlopendeAudio.Play();
               

    }
}
