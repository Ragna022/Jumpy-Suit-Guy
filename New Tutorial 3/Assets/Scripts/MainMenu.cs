using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;


public class MainMenu : MonoBehaviour
{
    public AudioSource buttonsSound;
    public void PlayGame()
    {
        /*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);*/
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Debug.Log("Quit!!");

        Application.Quit();
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        Debug.Log("Quit Game!!!");
#else
        Application.Quit();
        
#endif
    }
    public void Pause()
    {
        SceneManager.LoadScene(0);
    }
}
