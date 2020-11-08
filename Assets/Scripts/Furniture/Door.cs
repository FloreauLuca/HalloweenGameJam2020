using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Furniture
{
    protected bool isOpen = false;
    [SerializeField] private Collider2D collider;

    public override void OpenFurniture()
    {
        if (!isOpen)
        {
            textManager.DisplayText("Secret Door close.");
        }
    }
    public void OpenDoor()
    {
        collider.isTrigger = true;
    }
}
