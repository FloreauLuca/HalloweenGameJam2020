using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : QuestFurniture
{
    private GameManager gameManager;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite goalSprite;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();   
    }

    public override void UseAnObject(SOObject obj)
    {
        if (!used && obj.Name == requestObject.Name)
        {
            used = true;
            gameManager.Validate(true);
            spriteRenderer.sprite = goalSprite;
            textManager.DisplayText("One Goal validate");
            player.RemoveObject(obj);
        }
    }
}
