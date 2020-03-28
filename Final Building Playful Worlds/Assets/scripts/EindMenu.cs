using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EindMenu : MonoBehaviour
{
 
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
            
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()

    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
