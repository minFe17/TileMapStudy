using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBullet : MonoBehaviour
{
    [SerializeField] float _speed;

    Vector3 _target;
    float _lifeTime;

    public void Init(Vector3 target)
    {
        _target = target;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(_target * Time.deltaTime * _speed);

    }
}
