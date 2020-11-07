using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOObject : ScriptableObject
{
    [SerializeField] private GameObject inventoryPrefab;
    public GameObject InventoryPrefab => inventoryPrefab;
    [SerializeField] private Sprite inventorySprite;
    public Sprite InventorySprite => inventorySprite;
    [SerializeField] private string name;
    public string Name => name;

}
