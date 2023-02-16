using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void MoveLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void ReGame()
    {
        SceneManager.LoadScene("Main");
    }
}
