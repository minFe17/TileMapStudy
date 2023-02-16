using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bible : MonoBehaviour
{
    float _time = 0f;

    void Update()
    {
        _time += Time.deltaTime;
        transform.localPosition = new Vector3(Mathf.Cos(_time), Mathf.Sin(_time), 0) * 1.5f;
    }
}
