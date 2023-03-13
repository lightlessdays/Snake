using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene(1);
    }

    public void ShowAbout()
    {
        SceneManager.LoadScene(2);
    }

    public void ShowMenu()
    {
        SceneManager.LoadScene(0);
    }
}
