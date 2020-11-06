using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedContainer : Container
{
    [SerializeField] protected SOObject keyObject;
    
    public override void OpenFurniture()
    {
        if (containObject && player.RemoveObject(keyObject))
        {
            player.AddObject(objectContained);
            containObject = false;
            Debug.Log(objectContained.Name + " found.");
        }
        else if (containObject)
        {
            Debug.Log("You need a " + keyObject.Name);
        } else
        {
            Debug.Log(objectContained.Name + " already found.");
        }
    }
}
