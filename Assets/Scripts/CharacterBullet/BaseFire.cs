using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BaseFire : MonoBehaviour
{
    GameObject _bullet;
    CharacterController _hero;
    void Awake()
    {
        _bullet = Resources.Load("Prefabs/Bullet") as GameObject;
    }

    public void Init(CharacterController hero)
    {
        _hero = hero;
        StartCoroutine(CoFire());
    }

    IEnumerator CoFire()
    {
        while(true)
        {
            Transform target = _hero.SeleteMonster();
            if(target == null)
            {
                yield return new WaitForSeconds(1f);
                continue;
            }
            else
            {
                GameObject temp = Instantiate(_bullet);
                temp.transform.position = transform.position;
                Vector3 vec = target.position - transform.position;
                temp.GetComponent<MultiShotBullet>().Init(vec.normalized);
                yield return new WaitForSeconds(1);
            }
            
        }
    }
}
