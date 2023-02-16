using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BibleSpawn : MonoBehaviour
{
    [SerializeField] Transform _hero;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = _hero.position;
    }

    public void Spawn(GameObject bible)
    {
        Instantiate(bible, transform);
    }
}
