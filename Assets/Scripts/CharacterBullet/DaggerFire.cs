using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DaggerFire : MonoBehaviour
{
    GameObject _circleBullet;

    int _circleBulletCount = 0;


    void Awake()
    {
        _circleBullet = Resources.Load("Prefabs/CircleBullet") as GameObject;
    }
    void Start()
    {
        
    }

    public void Init()
    {
        StartCoroutine(DaggerFireRoutine());
    }

    IEnumerator DaggerFireRoutine()
    {
        while(true)
        {
            float deg = 30f * _circleBulletCount;
            float x = Mathf.Cos(deg * Mathf.Deg2Rad);
            float y = Mathf.Sin(deg * Mathf.Deg2Rad);
            GameObject bullet = Instantiate(_circleBullet);
            bullet.transform.position = transform.position;
            bullet.GetComponent<CircleBullet>().Init(new Vector3(x, y, 0));
            _circleBulletCount++;

            yield return new WaitForSeconds(0.5f);
        }
    }
}
