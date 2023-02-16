using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class HomingShot : MonoBehaviour
{
    GameObject _bullet;
    Transform _target;

    void Awake()
    {
        _bullet = Resources.Load("Prefabs/Homing") as GameObject;
    }

    public void Init(Transform target)
    {
        _target = target;
        
        StartCoroutine(HomingShotRoutine());
    }

    IEnumerator HomingShotRoutine()
    {
        while (true)
        {
            GameObject temp = Instantiate(_bullet);
            temp.transform.position = transform.position;
            temp.name = "Bullet";
            temp.GetComponent<Bullet>().Init(_target);

            yield return new WaitForSeconds(0.5f);
        }
    }
}
