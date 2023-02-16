using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int _damage;

    public int GetDamage()
    {
        return _damage;
    }
}
