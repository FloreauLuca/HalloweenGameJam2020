using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideFurniture : Furniture
{
    bool isHidden = false;
    protected bool used = false;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
 
    public override void OpenFurniture()
    {
        if (isHidden)
        {
            _animator.SetBool("isHidden", false);
            isHidden = false;
            player.GetComponentInChildren<PlayerManager>().Hide(false);
            player.GetComponentInChildren<PlayerManager>().enabled = true;
            Debug.Log("is not hidden");
        }
        else
        {
            _animator.SetBool("isHidden", true);
            isHidden = true;
            player.GetComponentInChildren<PlayerManager>().Hide(true);
            player.GetComponentInChildren<PlayerManager>().enabled = false;
            Debug.Log("Hidden");
        }
    }
}
