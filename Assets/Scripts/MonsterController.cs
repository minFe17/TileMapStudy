using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] Transform _hero;
    GameObject _monster;
    List<Monster> mons = new List<Monster>();

    void Start()
    {
        _monster = Resources.Load("Prefabs/Slime") as GameObject;
        MakeMonsters();
    }

    void MakeMonsters()
    {

        for (int i = 0; i < 10; i++)
        {
            GameObject mon = Instantiate(_monster, transform);
            mons.Add(mon.GetComponent<Monster>());
        }

        foreach (Monster monster in mons)
        {
            monster.Init(this, _hero);
        }
    }

    public void HeroExpUp()
    {
        _hero.gameObject.GetComponent<CharacterController>().ExpUp();
    }

    public void newMakeMonster()
    {
        bool isNew = true;

        foreach (Monster mon in mons)
        {
            if (mon.gameObject.activeSelf == false)
            {
                mon.Init(this, _hero);
                isNew = false;
                break;
            }
        }

        if (isNew)
        {
            GameObject monster = Instantiate(_monster);
            Monster mon = monster.GetComponent<Monster>();
            mon.Init(this, _hero);
            mons.Add(mon);
        }
    }

    public Transform seleteMonster()
    {
        float distance = 0f;
        Transform target = null;
        foreach (Monster mon in mons)
        {
            if (distance >= Vector3.Distance(mon.transform.position, _hero.position) || target == null)
            {
                distance = Vector3.Distance(mon.transform.position, _hero.position);
                target = mon.transform;
            }
        }
        return target;
    }
}
