using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : QuestFurniture
{
    private GameManager gameManager;
    [SerializeField] private GameObject fire;
    [SerializeField] protected SOObject letter;
    protected bool burned = false;

    void Start()
    {
        player = FindObjectOfType<PlayerInventory>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public override void OpenFurniture()
    {
        if (!used)
        {
            textManager.DisplayText("You need a " + requestObject.Name);
        }
        if (used && !burned)
        {
            textManager.DisplayText("You can put a " + letter.Name);
        }
    }

    public override void UseAnObject(SOObject obj)
    {
        if (!used && obj.Name == requestObject.Name)
        {
            used = true;
            fire.SetActive(true);
            player.RemoveObject(obj);
        }
        if (used && !burned && obj.Name == letter.Name)
        {
            burned = true;
            gameManager.Validate(true);
            textManager.DisplayText("One Goal validate");
            player.RemoveObject(obj);
        }
    }
}
