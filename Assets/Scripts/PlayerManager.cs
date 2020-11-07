using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float Speed;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 movement = Vector2.right * (horizontal * Speed * Time.deltaTime);


        transform.Translate(movement);

        if (horizontal > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (horizontal < 0)
        {
            _spriteRenderer.flipX = true;
        }

            _animator.SetFloat("Speed", Mathf.Abs(horizontal));
        _animator.SetBool("isCrouched", Input.GetKey(KeyCode.LeftControl) && horizontal == 0);
 
    }

}
