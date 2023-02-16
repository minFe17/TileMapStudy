using System.Collections;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] float _destroyTime;
    Animator _animator;


    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Character")
            StartCoroutine(BoxOpenRoutine());
    }

    IEnumerator BoxOpenRoutine()
    {
        Debug.Log("�������ϴ�");
        _animator.SetBool("isOpen", true);
        yield return new WaitForSeconds(_destroyTime);
        Destroy(this.gameObject);
    }
}
