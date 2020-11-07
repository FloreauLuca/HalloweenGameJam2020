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
            Debug.Log(objectContained.Name + " found.");
        }
        else if (locked)
        {
            Debug.Log("You need a " + keyObject.Name);
        } else
        {
            Debug.Log(objectContained.Name + " already found.");
        }
    }

    public override void UseAnObject(SOObject obj)
    {
        if (!locked && obj.Name == keyObject.Name)
        {
            locked = false;
            player.RemoveObject(obj);
            Debug.Log("Container open");
        }
    }
}
