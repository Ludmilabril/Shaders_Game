using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{

    public void GameScene()
    {
        SceneManager.LoadScene("Juego");
    }
    public void ExitGame()
    {
        Application.Quit();
    }


}
