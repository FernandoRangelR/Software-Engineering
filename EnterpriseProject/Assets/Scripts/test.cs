using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit)
            {
                Debug.Log(hit.collider.gameObject.name);
                changeSprite();
            }
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
