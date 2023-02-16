using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] float _deg;
    [SerializeField] float _gap;
    [SerializeField] int _count;
    [SerializeField] Transform _target;

    void Start()
    {
        //GameObject temp = Instantiate(_bullet);
        //temp.transform.position = transform.position;
        //float deg = _deg - 15;
        //Vector3 dir = new Vector3(Mathf.Cos(deg * Mathf.Deg2Rad), Mathf.Sin(deg * Mathf.Deg2Rad), 0);
        //temp.GetComponent<Bullet>().Init(dir.normalized);

        //GameObject temp2 = Instantiate(_bullet);
        //temp2.transform.position = transform.position;
        //float deg2 = _deg + 15;
        //Vector3 dir2 = new Vector3(Mathf.Cos(deg2 * Mathf.Deg2Rad), Mathf.Sin(deg2 * Mathf.Deg2Rad), 0);
        //temp2.GetComponent<Bullet>().Init(dir2.normalized);

        //StartCoroutine(CoShot());
        //StartCoroutine(CoInfiniteShot());
        StartCoroutine(CoInfiniteMultiShot());
    }

    IEnumerator CoShot()
    {
        while (true)
        {
            for (int i = 0; i < _count; i++)
            {
                GameObject temp = Instantiate(_bullet);
                temp.transform.position = transform.position;
                float deg = i * (_deg / _count) + 30;
                Vector3 dir = new Vector3(Mathf.Cos(deg * Mathf.Deg2Rad), Mathf.Sin(deg * Mathf.Deg2Rad), 0);
                temp.GetComponent<MultiShotBullet>().Init(dir.normalized);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator CoInfiniteShot()
    {
        int i = 0;
        while (true)
        {
            GameObject temp = Instantiate(_bullet);
            temp.transform.position = transform.position;
            float deg = i * _gap;
            Vector3 dir = new Vector3(Mathf.Cos(deg * Mathf.Deg2Rad), Mathf.Sin(deg * Mathf.Deg2Rad), 0);
            temp.GetComponent<MultiShotBullet>().Init(dir.normalized);
            i++;
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator CoInfiniteMultiShot()
    {
        while(true)
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
