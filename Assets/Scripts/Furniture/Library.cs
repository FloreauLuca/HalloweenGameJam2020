using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : QuestFurniture
{
    [SerializeField] private Door door;

    public override void OpenFurniture()
    {
        Debug.Log("No object here.");
    }

    public override void UseAnObject(SOObject obj)
    {
        if (!used && obj.Name == requestObject.Name)
        {
            used = true;
            door.OpenDoor();
            player.RemoveObject(obj);
        }
    }
}
