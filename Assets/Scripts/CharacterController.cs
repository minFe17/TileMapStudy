using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.RuleTile.TilingRuleOutput;

public class CharacterController : MonoBehaviour
{
    [SerializeField] int _maxHp;
    [SerializeField] int _attack;
    [SerializeField] float _speed;
    [SerializeField] GameObject _bibleSpawnPos;
    [SerializeField] GameObject _uiPanel;
    [SerializeField] MonsterController _monsterController;
    [SerializeField] GameUI _gameUI;
    [SerializeField] HpBar _hpBar;
    [SerializeField] SetSkillItems _skillPanel;
    [SerializeField] CsvController _levelData;

    public Dictionary<ESkillType, int> dicSkills = new Dictionary<ESkillType, int>();


    Animator _animator;
    GameObject _rotateBullet;

    int _moveDirection = 0; //1오른쪽, 2왼쪽, 3위, 4아래
    int _curHp;
    int _heroExp = 0;
    int _heroSumExp = 0;
    int _needExp = 100;
    int _heroLevel = 1;

    bool _isGameOver;

    string _heroName;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rotateBullet = Resources.Load("Prefabs/RotateBullet") as GameObject;
        _curHp = _maxHp;
        _hpBar.ShowHp(_curHp, _maxHp);
        gameObject.AddComponent<BaseFire>().Init(this);
        _gameUI.ExpChange(_heroExp, _needExp);
        _gameUI.ShowLevel(_heroLevel);
    }

    void Update()
    {
        if (_isGameOver)
            return;
        Move();
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    HomingShot homingShot = gameObject.AddComponent<HomingShot>();
        //    homingShot.Init(SeleteMonster());
        //}

        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    DaggerFire daggerFire = gameObject.AddComponent<DaggerFire>();
        //    daggerFire.Init();
        //}

        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    GameObject bullet = Instantiate(_rotateBullet);
        //    bullet.transform.position = transform.position;
        //    bullet.GetComponent<RotateBullet>().Init(SeleteMonster().position);
        //}

        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    if (gameObject.GetComponent<BibleFIre>() == null)
        //    {
        //        BibleFIre bibleFire = gameObject.AddComponent<BibleFIre>();
        //        bibleFire.Init(_bibleSpawnPos, 3);
        //    }
        //}

        //if(Input.GetKeyDown(KeyCode.R))
        //{
        //    MultiShot multiShot = gameObject.AddComponent<MultiShot>();
        //    multiShot.Init(SeleteMonster(), 3);
        //}

        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    ExpUp();
        //}
    }

    public Transform SeleteMonster()
    {
        Transform target = _monsterController.seleteMonster();
        return target;
    }


    public void GetSkill(stSkillData data)
    {
        if (dicSkills.ContainsKey(data.ETYPE) == false)
        {
            dicSkills.Add(data.ETYPE, data.LV);
            switch (data.ETYPE)
            {
                case ESkillType.multiShot:
                    {
                        MultiShot multiShot = gameObject.AddComponent<MultiShot>();
                        multiShot.Init(SeleteMonster(), data.BULLET);
                    }
                    break;
                case ESkillType.homingShot:
                    {
                        HomingShot homingShot = gameObject.AddComponent<HomingShot>();
                        homingShot.Init(SeleteMonster());
                    }
                    break;
                case ESkillType.dagger:
                    {
                        DaggerFire dagger = gameObject.AddComponent<DaggerFire>();
                        dagger.Init();
                    }
                    break;
            }
        }
        else
        {
            dicSkills[data.ETYPE] = data.LV;
            switch (data.ETYPE)
            {
                case ESkillType.multiShot:
                    {
                        gameObject.GetComponent<MultiShot>().Init(SeleteMonster(), data.BULLET);
                    }
                    break;
                case ESkillType.homingShot:
                    {
                        gameObject.GetComponent<HomingShot>().Init(SeleteMonster());
                    }
                    break;
                case ESkillType.dagger:
                    {
                        gameObject.GetComponent<DaggerFire>().Init();
                    }
                    break;
            }
        }

    }

    public void Move()
    {
        Vector2 vec = Vector2.zero;
        bool isIdle = true;
        if (Input.GetKey(InputKeyType.d.ToString()))
        {
            _moveDirection = (int)MoveType.Right;
            vec += Vector2.right * Time.deltaTime * _speed;
            isIdle = false;
        }
        if (Input.GetKey(InputKeyType.a.ToString()))
        {
            _moveDirection = (int)MoveType.Left;
            vec += Vector2.left * Time.deltaTime * _speed;
            isIdle = false;
        }
        if (Input.GetKey(InputKeyType.w.ToString()))
        {
            _moveDirection = (int)MoveType.Up;
            vec += Vector2.up * Time.deltaTime * _speed;
            isIdle = false;
        }
        if (Input.GetKey(InputKeyType.s.ToString()))
        {
            _moveDirection = (int)MoveType.Down;
            vec += Vector2.down * Time.deltaTime * _speed;
            isIdle = false;
        }
        if (vec != Vector2.zero)
        {
            transform.Translate(vec);
            _animator.SetInteger("moveDirection", _moveDirection);
        }
        else
        {
            _moveDirection = (int)MoveType.Idle;
            _animator.SetInteger("moveDirection", _moveDirection);
        }

    }

    void SetLevelUpExp()
    {
        int nowNeedExp = 0;
        int nextNeedExp = 0;
        _heroLevel++;
        foreach (stLevelData data in _levelData.lstLevelData)
        {
            if (data.LEVEL == _heroLevel)
            {
                nowNeedExp = data.SUMEXP;
            }
            if (data.LEVEL == _heroLevel + 1)
            {
                nextNeedExp = data.SUMEXP;
            }
        }
        _needExp = nextNeedExp - nowNeedExp;
        _heroExp = _heroSumExp - nowNeedExp;
    }

    public void ExpUp()
    {
        if (!_isGameOver)
        {
            _heroExp += 60;
            _heroSumExp += 60;
            if (_heroExp >= _needExp)
            {
                SetLevelUpExp();
                _gameUI.ShowLevel(_heroLevel);
                _skillPanel.ShowSkillPanel();
            }
            _gameUI.ExpChange(_heroExp, _needExp);
        }
    }

    public void SetHeroName(string name)
    {
        _heroName = name;
        _gameUI.SetChangeName(_heroName);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Door")
            ResetPosition();

        if (collision.gameObject.tag == "Tree")
        {
            Tree tree = collision.gameObject.GetComponent<Tree>();
            if (tree != null)
                tree.HitTree();
        }
    }

    void ResetPosition()
    {
        transform.position = Vector3.zero;
    }

    public void hitted()
    {
        if (_curHp <= 0)
            return;
        _curHp -= 5;
        _hpBar.ShowHp(_curHp, _maxHp);
        if (_curHp <= 0)
        {
            _isGameOver = true;
            _uiPanel.SetActive(true);
            _skillPanel.CloseSkillPanel();
        }
    }

    public int GetAttack()
    {
        return _attack;
    }
}

enum InputKeyType
{
    d,  //RightKey
    a,  //LeftKey
    w,  //UpKey
    s,  //DownKey
}

enum MoveType
{
    Idle,
    Right,
    Left,
    Up,
    Down,
}



