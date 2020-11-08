﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    protected PlayerInventory player = null;
    protected PlayerManager playerManager;

    void Start()
    {
        player = FindObjectOfType<PlayerInventory>();
        playerManager = FindObjectOfType<PlayerManager>();
    }

    public virtual void OpenFurniture()
    {

    }

    public virtual void UseAnObject(SOObject obj)
    {

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            player.SetReachableFurniture(this);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.SetReachableFurniture(null);
        }
    }
}
