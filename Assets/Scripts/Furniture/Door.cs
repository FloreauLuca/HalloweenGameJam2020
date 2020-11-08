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
            Debug.Log("Secret Door close.");
        }
    }
    public void OpenDoor()
    {
        collider.isTrigger = true;
    }
}
