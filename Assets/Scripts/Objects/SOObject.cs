using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOObject : ScriptableObject
{
    [SerializeField] private GameObject inventoryPrefab;
    public GameObject InventoryPrefab => inventoryPrefab;
    [SerializeField] private string name;
    public string Name => name;

}
