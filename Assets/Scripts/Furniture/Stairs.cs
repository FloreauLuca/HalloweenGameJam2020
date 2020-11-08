using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : Furniture
{
    [SerializeField] Transform endPosition;
    bool isStairs = false;
    protected bool used = false;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public override void OpenFurniture()
    {
        Debug.Log("There's no stairs");


        if (isStairs)
        {
            _animator.SetBool("isStairs", false);
            isStairs = false;
            player.GetComponentInChildren<PlayerManager>().Hide(false); 
            player.GetComponentInChildren<PlayerManager>().enabled = true;
            Debug.Log("Not going through the stairs");
        }
        else
        {
            _animator.SetBool("isStairs", true);
            isStairs = true;
            player.GetComponentInChildren<PlayerManager>().Hide(true);
            player.GetComponentInChildren<PlayerManager>().enabled = false;
            Debug.Log("Take the stairs");
        }
    }
}
