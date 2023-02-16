using System.Collections;
using UnityEngine;

public class BibleFIre : MonoBehaviour
{

    GameObject _blbleSpawnPos;
    GameObject _bible;

    int _level;

    void Awake()
    {
        _bible = Resources.Load("Prefabs/Bible") as GameObject;
    }

    public void Init(GameObject spawnPos, int level)
    {
        _blbleSpawnPos = spawnPos;
        _level = level;
        StartCoroutine(MakeBibleRoutine());
    }

    IEnumerator MakeBibleRoutine()
    {
        int count = 0;
        while (count < _level)
        {
            _blbleSpawnPos.GetComponent<BibleSpawn>().Spawn(_bible);
            yield return new WaitForSeconds(0.5f);
            count++;
        }
    }
}
