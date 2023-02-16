using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PathTest : MonoBehaviour
{
    void Start()
    {
        //PlayerPrefs.DeleteAll();

        //PlayerPrefs.SetFloat("soundVolume", 0.5f);
        //PlayerPrefs.SetString("userName", "¿µ¿õ");
        //PlayerPrefs.SetInt("userID", 123);

        float soundVolume = PlayerPrefs.GetFloat("soundVolume");
        string userName = PlayerPrefs.GetString("userName");
        int userID = PlayerPrefs.GetInt("userID");

        Debug.Log(soundVolume);
        Debug.Log(userName);
        Debug.Log(userID);
        //Debug.Log("dataPath : " + Application.dataPath);
        //Debug.Log("persistentPath : " + Application.persistentDataPath);

        //Debug.Log(Directory.Exists(Application.persistentDataPath + "/datas"));

        //if (!Directory.Exists(Application.persistentDataPath + "/user00"))
        //{
        //    Directory.CreateDirectory(Application.persistentDataPath + "/user00");
        //}
    }

    void Update()
    {
        
    }
}
