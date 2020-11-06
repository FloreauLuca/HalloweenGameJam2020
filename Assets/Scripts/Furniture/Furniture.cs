using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    protected PlayerInventory player = null;

    void Start()
    {
        player = FindObjectOfType<PlayerInventory>();

    }

    public virtual void OpenFurniture()
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
