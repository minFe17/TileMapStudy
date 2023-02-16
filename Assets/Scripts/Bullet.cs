using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed;
    Transform _target = null;

    public void Init(Transform target)
    {
        _target = target;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 move = _target.position - transform.position;
        transform.Translate(move.normalized * Time.deltaTime * _speed);
    }
}
