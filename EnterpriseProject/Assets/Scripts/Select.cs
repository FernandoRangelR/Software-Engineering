using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public Sprite not_pressed;
    public Sprite pressed; 

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = not_pressed; // set the sprite to sprite1
    }

    void Update()
    { 
        if (Input.GetMouseButtonDown(0))
        {
            changeSprite();
        }
    }

    void changeSprite()
    {
        if (spriteRenderer.sprite == not_pressed) // if the spriteRenderer sprite = sprite1 then change to sprite2
        {
            spriteRenderer.sprite = pressed;
        }
        else
        {
            spriteRenderer.sprite = not_pressed; // otherwise change it back to sprite1
        }
    }
}
