using UnityEngine;

public class Knight : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _jumpPower;


    Animator _animator;
    SpriteRenderer _sprite;
    Rigidbody2D _rigid;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float move = 0f;
        move += x * Time.deltaTime * _speed;
        if (move == 0f)
            _animator.SetBool("isWalk", false);
        else
        {
            if (move < 0f)
                _sprite.flipX = true;
            else
                _sprite.flipX = false;

            _animator.SetBool("isWalk", true);
            transform.Translate(move, 0, 0);
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            _rigid.velocity = new Vector2(0, _jumpPower);
            //_animator.SetBool("isJump", true);
        }
    }
}
