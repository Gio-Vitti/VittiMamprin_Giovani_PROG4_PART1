using UnityEngine;
using System.Collections.Generic;

public class SpritePicker : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();
    private SpriteRenderer sr;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
