using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionPanel : MonoBehaviour
{
    [SerializeField] CharacterController _heroData;
    [SerializeField] InputField _text;

    public void MoveLobby()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Lobby");
    }

    public void ReGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void ChangeName()
    {
        _heroData.SetHeroName(_text.text);
    }


}
