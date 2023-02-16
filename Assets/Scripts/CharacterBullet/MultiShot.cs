using System.Collections;
using UnityEngine;

public class MultiShot : MonoBehaviour
{
    GameObject _bullet;
    Transform _target;
    float _deg;
    int _count;
    //float _gap;

    void Awake()
    {
        _bullet = Resources.Load("Prefabs/MultiShotBullet") as GameObject;
        _deg = 45f;
    }

    public void Init(Transform target, int count)
    {
        _target = target;
        _count = count;
        StartCoroutine(MultiShotRoutine());
    }

    IEnumerator MultiShotRoutine()
    {
        while (true)
        {
            Vector3 v3Temp = _target.position - transform.position;
            float degTemp = Mathf.Atan2(v3Temp.y, v3Temp.x);
            float radDeg = degTemp * Mathf.Rad2Deg;
            for (int i = 0; i < _count; i++)
            {
                GameObject temp = Instantiate(_bullet);
                temp.transform.position = transform.position;
                float deg = i * (_deg / (_count - 1)) - _deg / 2 + radDeg;
                Vector3 dir = new Vector3(Mathf.Cos(deg * Mathf.Deg2Rad), Mathf.Sin(deg * Mathf.Deg2Rad), 0);
                temp.GetComponent<MultiShotBullet>().Init(dir.normalized);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
