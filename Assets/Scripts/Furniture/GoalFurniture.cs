using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalFurniture : QuestFurniture
{
    private GameManager gameManager;
    [SerializeField] private bool crucifix;

    void Start()
    {
        player = FindObjectOfType<PlayerInventory>();
        gameManager = FindObjectOfType<GameManager>();   
    }

    public override void UseAnObject(SOObject obj)
    {
        if (!used && obj.Name == requestObject.Name)
        {
            used = true;
            gameManager.Validate(crucifix);
            Debug.Log("Goal validate");
            player.RemoveObject(obj);
        }
    }
}
