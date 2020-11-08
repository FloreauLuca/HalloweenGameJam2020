using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : LockedContainer
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite goalSprite;

    public override void UseAnObject(SOObject obj)
    {
        if (locked && obj.Name == keyObject.Name)
        {
            locked = false;
            player.RemoveObject(obj);
            OpenFurniture();
            spriteRenderer.sprite = goalSprite;
        }
    }
}
