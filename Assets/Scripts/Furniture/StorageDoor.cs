using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageDoor : Door
{
    protected bool locked = true;
    [SerializeField] protected SOObject keyObject;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite goalSprite;

    public override void OpenFurniture()
    {
        if (locked)
        {
            textManager.DisplayText("You need a " + keyObject.Name + " to open the door.");
        }
    }

    public override void UseAnObject(SOObject obj)
    {
        if (!locked && obj.Name == keyObject.Name)
        {
            locked = false;
            player.RemoveObject(obj);
            OpenDoor();
            spriteRenderer.sprite = goalSprite;
            textManager.DisplayText("Door unlocked");
        }
    }
}
