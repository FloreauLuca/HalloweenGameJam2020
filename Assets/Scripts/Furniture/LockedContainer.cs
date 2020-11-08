using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedContainer : Container
{
    protected bool locked = true;
    [SerializeField] protected SOObject keyObject;
    
    public override void OpenFurniture()
    {
        if (containObject && !locked)
        {
            player.AddObject(objectContained);
            containObject = false;
            textManager.DisplayText(objectContained.Name + " found.");
        }
        else if (locked)
        {
            textManager.DisplayText("You need a " + keyObject.Name);
        } else
        {
            textManager.DisplayText(objectContained.Name + " already found.");
        }
    }

    public override void UseAnObject(SOObject obj)
    {
        if (locked && obj.Name == keyObject.Name)
        {
            locked = false;
            player.RemoveObject(obj);
            OpenFurniture();
        }
    }
}
