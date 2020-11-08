using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : Furniture
{
    protected bool containObject = true;
    [SerializeField] protected SOObject objectContained;

    public override void OpenFurniture() 
    {
        if (containObject)
        {
            player.AddObject(objectContained);
            containObject = false;
            textManager.DisplayText(objectContained.Name + " found.");
        }
        else
        {
            textManager.DisplayText(objectContained.Name + " already found.");
        }
    }

    public override void UseAnObject(SOObject obj)
    {
    }
}
