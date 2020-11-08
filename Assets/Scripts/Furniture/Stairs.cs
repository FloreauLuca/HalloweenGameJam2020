using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Stairs : Furniture
{
    [SerializeField] Transform endTransform;

    public AnimationClip Climb;
    protected bool used = false;
    public override void OpenFurniture()
    {
        playerManager.Animator.SetBool("isOpen", true);
        Invoke(nameof(ClimbDown), Climb.length);
    }

    private void ClimbDown()
    {
        player.transform.position = endTransform.position;
        playerManager.Animator.SetBool("isOpen", false);
    }
}
