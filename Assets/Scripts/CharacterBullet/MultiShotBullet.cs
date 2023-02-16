using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShotBullet : MonoBehaviour
{
    [SerializeField] float _speed;

    Vector3 _direction;

    public void Init(Vector3 dir)
    {
        _direction = dir;
    }

    void Update()
    {
        transform.Translate(_direction * Time.deltaTime * _speed);
    }
}
