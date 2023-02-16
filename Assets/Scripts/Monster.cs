using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] HpBar _hpBar;

    Transform _hero;
    MonsterController _monsterController;
    Animator _animator;
    SpriteRenderer _sprite;

    int _maxHp;
    int _curHp;

    float _speed;
    float _colorTimer;
    float _runTimer;

    bool _isHitted;
    bool _isRun;
    bool _isDead;
    bool _isGiveExp;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    public void Init(MonsterController monsterController, Transform hero)
    {
        gameObject.SetActive(true);
        _monsterController = monsterController;
        _hero = hero;
        _maxHp = 30;
        _curHp = _maxHp;
        _speed = 2;
        _isDead = false;
        _isGiveExp = false;
        Vector3 ranPos = _hero.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 6;
        transform.position = ranPos;
        _hpBar.ShowHp(_curHp, _maxHp);
    }

    void Update()
    {
        Move();
        ColorChange();
        Run();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Character")
            collision.gameObject.GetComponent<CharacterController>().hitted();

        if (collision.gameObject.GetComponent<Damage>() != null)
        {
            int damage = collision.gameObject.GetComponent<Damage>().GetDamage();
            OnHitted(damage);
            if (collision.gameObject.GetComponent<BulletRemove>() != null)
                collision.gameObject.GetComponent<BulletRemove>().Remove();
        }
    }

    void Move()
    {
        if (!_isRun && !_isDead)
        {
            Vector2 direction = _hero.transform.position - transform.position;
            transform.Translate(direction.normalized * Time.deltaTime * _speed);
        }
    }

    void OnHitted(int hitPower)
    {
        _curHp -= hitPower;
        _hpBar.ShowHp(_curHp, _maxHp);
        _isHitted = true;

        if (_curHp <= 0)
        {
            _isDead = true;
            _animator.SetTrigger("Dead");
            if(!_isGiveExp)
            {
                _monsterController.HeroExpUp();
                _isGiveExp = true;
            }
        }
        else
        {
            _isRun = true;
        }
    }

    void ColorChange()
    {
        if (_isHitted)
        {
            _colorTimer += Time.deltaTime;
            _sprite.color = Color.red;
            if (_colorTimer >= 0.1f)
            {
                _isHitted = false;
                _sprite.color = Color.white;
                _colorTimer = 0f;
            }
        }
    }

    void Run()
    {
        if (_isRun)
        {
            transform.position += (transform.position - _hero.position).normalized * Time.deltaTime * _speed;
            _runTimer += Time.deltaTime;
            if (_runTimer >= 0.5f)
            {
                _isRun = false;
                _runTimer = 0f;
            }
        }
    }

    public void DeadEnd()
    {
        gameObject.SetActive(false);
        _monsterController.newMakeMonster();
    }
}
