using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBullet : MonoBehaviour
{
    [SerializeField] float _speed;

    Vector3 _lastPos;
    Vector3 _target;
    float _timer;

    public void Init(Vector3 target)
    {
        _lastPos = transform.position;
        _target = (target - _lastPos).normalized;

    }

    void Update()
    {
        _timer += Time.deltaTime;
        _lastPos += _target * Time.deltaTime * _speed;
        transform.position = new Vector3(Mathf.Cos(_timer), Mathf.Sin(_timer), 0) * 2f;
        transform.position += _lastPos;
    }
}
