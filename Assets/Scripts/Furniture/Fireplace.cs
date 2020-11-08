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

    public override void UseAnObject(SOObject obj)
    {
        if (!used && obj.Name == requestObject.Name)
        {
            used = true;
            fire.SetActive(true);
            player.RemoveObject(obj);
        }
        if (!burned && obj.Name == letter.Name)
        {
            burned = true;
            gameManager.Validate(true);
            Debug.Log("Goal validate");
            player.RemoveObject(obj);
        }
    }
}
