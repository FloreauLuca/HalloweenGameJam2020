using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    List<SOObject> objectsList = new List<SOObject>();
    [SerializeField] GameObject spriteContainer;
    List<GameObject> spriteList = new List<GameObject>();

    Furniture reachableFurniture = null;

    bool isVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteContainer.SetActive(isVisible);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Open") && reachableFurniture != null)
        {
            reachableFurniture.OpenFurniture();
        }
        if (Input.GetButtonDown("Inventory"))
        {
            if (isVisible)
            {
                isVisible = false;
                spriteContainer.SetActive(isVisible);
            } else
            {
                isVisible = true;
                spriteContainer.SetActive(isVisible);
            }
        }
        
    }

    public void UseAnObject(SOObject obj)
    {
        if (reachableFurniture != null)
        {
            reachableFurniture.UseAnObject(obj);
            isVisible = false;
            spriteContainer.SetActive(isVisible);
        }
    }

    public void AddObject(SOObject obj)
    {
        objectsList.Add(obj);
        GameObject gameObject = Instantiate(obj.InventoryPrefab, spriteContainer.transform);
        gameObject.GetComponent<InventoryIcon>().SetObject(obj);
        spriteList.Add(gameObject);
    }

    public bool HasObject(SOObject obj)
    {
        for (int i = 0; i < objectsList.Count; i++) {
            if (objectsList[i].Name == obj.Name)
            {
                return true;
            }
        }
        return false;
    }

    public bool RemoveObject(SOObject obj)
    {
        for (int i = 0; i < objectsList.Count; i++)
        {
            if (objectsList[i].Name == obj.Name)
            {
                objectsList.RemoveAt(i);
                Destroy(spriteList[i]);
                spriteList.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public void SetReachableFurniture(Furniture furniture)
    {
        reachableFurniture = furniture;
    }
}
