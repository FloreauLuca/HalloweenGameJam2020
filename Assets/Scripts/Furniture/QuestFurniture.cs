using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestFurniture : Furniture
{
    [SerializeField] protected SOObject requestObject;
    protected bool used = false;

    public override void OpenFurniture()
    {
        textManager.DisplayText("You need a " + requestObject.Name);
    }

    public override void UseAnObject(SOObject obj)
    {
        if (!used && obj.Name == requestObject.Name)
        {
            used = true;
            player.RemoveObject(obj);
        }
    }
}

