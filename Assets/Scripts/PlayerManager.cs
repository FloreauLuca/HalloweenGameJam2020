﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float Speed;
    public bool isHidden;

    private Animator _animator;
    public SpriteRenderer _spriteRenderer;
    internal bool IsHidden;

    //private readonly List<IInteractable> _interactables = new List<IInteractable>();

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
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        _animator.SetFloat("Speed", Mathf.Abs(horizontal));
        _animator.SetBool("isCrouched", Input.GetKey(KeyCode.LeftControl) && horizontal == 0);
        _animator.SetBool("isInventory", Input.GetKey(KeyCode.E) && horizontal == 0);
        //_animator.SetBool("isItem", Input.GetKey(KeyCode.E) && horizontal == 0);

    }
    public void Hide(bool isHide)
    {
        _animator.SetBool("isOpen", isHide);

    }


}
