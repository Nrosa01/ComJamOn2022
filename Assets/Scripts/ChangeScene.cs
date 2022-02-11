using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ChangeScene : MonoBehaviour
{
    public void SceneGame()
    {
        SceneManager.LoadScene("Escena Rioni");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu Inicio");
    }
}
