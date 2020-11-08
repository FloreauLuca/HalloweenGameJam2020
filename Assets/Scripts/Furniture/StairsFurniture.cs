using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsFurniture : QuestFurniture
{
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private Vector2 endPosition;
    [SerializeField] private GameObject stairs;
    [SerializeField] private GameObject ropeSprite;
    [SerializeField] private float duration;

    public override void UseAnObject(SOObject obj)
    {
        if (!used && obj.Name == requestObject.Name)
        {
            used = true;
            StartCoroutine(OpenStairs());
            player.RemoveObject(obj);
        }
    }

    private IEnumerator OpenStairs()
    {
        stairs.transform.localPosition = startPosition;
        for (int i = 0; i < duration*20; i++) {
            yield return new WaitForSeconds(0.05f);
            stairs.transform.localPosition = Vector2.Lerp(startPosition, endPosition, i / (duration * 10));
        }
        stairs.transform.localPosition = endPosition;
        ropeSprite.SetActive(false);
    }
}
