using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryIcon : MonoBehaviour
{
    private SOObject obj;
    [SerializeField] private GameObject bubble;
    [SerializeField] private Image image;
    private PlayerInventory playerInventory;

    void Start() {
        playerInventory = FindObjectOfType<PlayerInventory>();
        bubble.SetActive(false);
    }

    public void SetObject(SOObject obj)
    {
        this.obj = obj;
        image.sprite = obj.InventorySprite;
    }

    public void Click()
    {
        bubble.SetActive(true);
    }

    public void Use()
    {
        playerInventory.UseAnObject(obj);
    }
}
