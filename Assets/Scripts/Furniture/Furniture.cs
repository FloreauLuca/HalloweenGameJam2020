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
        player = FindObjectOfType<PlayerInventory>();
        textManager = FindObjectOfType<TextManager>();
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void OpenFurniture()
    {
        if (audioSource)
        {
            audioSource.PlayOneShot(audioClipOpen);
        }
    }

    public virtual void UseAnObject(SOObject obj)
    {
        if (audioSource)
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
