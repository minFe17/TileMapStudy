using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadTest : MonoBehaviour
{
    [SerializeField] CsvController _controller;

    void Start()
    {
        Debug.Log(_controller.IstHero[0].NAME);    
    }

    void Update()
    {
        
    }
}
