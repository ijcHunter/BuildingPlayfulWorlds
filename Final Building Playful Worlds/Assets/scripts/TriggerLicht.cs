using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerLicht : MonoBehaviour
{
    public GameObject bloem;
    //public GameObject bloem2;

    public static bool disabled = false;

    public ParticleSystem IngezameldParticle;
    public Light lightToSwitch = null;
    public AudioSource Sparkles;

    public Text scoreText;
    public int scorePoint;

    public GameObject EndCutsceneCamera;
    public GameObject player;
    public AudioSource thankYou;
    public AudioSource doorlopendeSounds;


    void Start()
    {
        scorePoint = 0;
        //SetScoreText();
    }


    public void OnTriggerEnter(Collider other)
    {
        lightToSwitch.enabled = true;
       

        if (other.gameObject.tag == "Object")
        {
           other.gameObject.SetActive(false);

            scorePoint = scorePoint + 1;
            SetScoreText();
                
            Sparkles.Play();
            IngezameldParticle.Play();


         }

    }

    public void OnTriggerExit(Collider other)
    {
        lightToSwitch.enabled = false;
        IngezameldParticle.Stop();
    }

    void SetScoreText()
    {
        scoreText.text = "" + scorePoint.ToString();
        if (scorePoint >= 7)
        {
            EndCutsceneCamera.SetActive(true);
            thankYou.Play();
            doorlopendeSounds.Stop();
            player.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            StartCoroutine(FinishCut());
            
        }
    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(5.05f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        
        

    }
}
