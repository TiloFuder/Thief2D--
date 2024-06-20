using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : interractionscript
{
    public GameObject key;
    public bool isOpen = false;
    public bool isLocked = false;
    public Collider2D collider2d;
    public Sprite doorOpen;
    public Sprite doorClose;
    public SpriteRenderer doorRenderer;
    public interractionscript ITSC;

    private void Update()
    {
        if(isOpen == false)
        {
            collider2d.enabled = true;
            doorRenderer.sprite = doorClose;
        }
        else
        {
            collider2d.enabled=false;
            doorRenderer.sprite = doorOpen;
        }
    }
    protected override void Activate()
    {
        if (ITSC.clickableObjects.Contains(gameObject))
        {
            if (isOpen == false)
            {
                isOpen = true;
            }
            else
            {
                isOpen = false;
            }
        }
        
    }
}
