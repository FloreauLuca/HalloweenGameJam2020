using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    protected PlayerManager playerManager;
    protected PlayerInventory player = null;
    protected TextManager textManager = null;
    private AudioSource audioSource;
    [SerializeField] private AudioClip audioClipOpen;
    [SerializeField] private AudioClip audioClipUseObject;

    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        player = FindObjectOfType<PlayerInventory>();
        textManager = FindObjectOfType<TextManager>();
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void OpenFurniture()
    {
    }

    public virtual void UseAnObject(SOObject obj)
    {
    }

    public void OpenFurnitureSound()
    {
        if (audioSource && audioClipOpen)
        {
            audioSource.PlayOneShot(audioClipOpen);
        }
    }

    public void UseAnObjectSound(SOObject obj)
    {
        if (audioSource && audioClipUseObject)
        {
            audioSource.PlayOneShot(audioClipUseObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
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
