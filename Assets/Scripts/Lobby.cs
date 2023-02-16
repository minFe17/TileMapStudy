using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    void Start()
    {
        
    }

    public void OnButtonGameStart()
    {
        SceneManager.LoadScene("Main");
    }
}
