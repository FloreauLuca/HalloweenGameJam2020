using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestFurniture : Furniture
{
    [SerializeField] protected SOObject requestObject;

    public override void OpenFurniture()
    {
        if (player.RemoveObject(requestObject))
        {
            Debug.Log("You unlocke something");
        }
        else
        {
            Debug.Log("You need a " + requestObject.Name);
        }
    }
}

