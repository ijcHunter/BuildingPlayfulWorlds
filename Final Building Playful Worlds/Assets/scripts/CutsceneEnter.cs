using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneEnter : MonoBehaviour
{
    public GameObject player;
    public GameObject CutsceneCamera;
    public ParticleSystem verzamelParticles;
    public AudioSource whispers;

    void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        CutsceneCamera.SetActive(true);
        player.SetActive(false);
        verzamelParticles.Play();
        whispers.Play();
        StartCoroutine(FinishCut());
    }


    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(7.4f);
        player.SetActive(true);
        player.GetComponent<PlayerController>().upKey = 0;
        player.GetComponent<PlayerController>().downKey = 0;
        player.GetComponent<PlayerController>().leftKey = 0;
        player.GetComponent<PlayerController>().rightKey = 0;
        
        CutsceneCamera.SetActive(false);
        whispers.Stop();
        //verzamelParticles.Stop();

    }
}
