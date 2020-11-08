using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float Speed;
    public bool isHidden;

    public Animator Animator;
    public SpriteRenderer _spriteRenderer;
    internal bool IsHidden;

    //private readonly List<IInteractable> _interactables = new List<IInteractable>();

    private void Awake()
    {
        Animator = GetComponent<Animator>();
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
        Animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Animator.SetBool("isCrouched", Input.GetKey(KeyCode.LeftControl) && horizontal == 0);
        Animator.SetBool("isInventory", Input.GetKey(KeyCode.E) && horizontal == 0);
        //_animator.SetBool("isItem", Input.GetKey(KeyCode.E) && horizontal == 0);

    }
    public void Hide(bool isHide)
    {
        Animator.SetBool("isOpen", isHide);

    }


}
