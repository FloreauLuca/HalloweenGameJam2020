using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestFurniture : Furniture
{
    [SerializeField] protected SOObject requestObject;
    protected bool used = false;

    public override void OpenFurniture()
    {
        Debug.Log("No object here.");
    }

    public override void UseAnObject(SOObject obj)
    {
        if (!used && obj.Name == requestObject.Name)
        {
            used = true;
            Debug.Log("Something is happening");
            player.RemoveObject(obj);
        }
    }
}

