using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRemove : MonoBehaviour
{
    float _lifeTime = 0f;

    void Update()
    {
        _lifeTime += Time.deltaTime;
        if(_lifeTime >= 5f)
        {
            Remove();
        }
    }

    public void Remove()
    {
        Destroy(this.gameObject);
    }
}
