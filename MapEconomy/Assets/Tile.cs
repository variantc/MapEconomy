using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    
    public int x;
    public int y;

    public float height;
    public float moisture;
    public float vegetation;

    float perlinNoiseScale_Height = 2.5f;

    public SpriteRenderer sr;
    //public Color srColor;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            Debug.LogError("No SpriteRenderer");
        }
    }

    public void SetHeightFromCoords(float w, float h, float offsetX, float offsetY, float scaleFactor)
    {
        height = Mathf.PerlinNoise(
            (x + offsetX) / w * perlinNoiseScale_Height * scaleFactor, 
            (y + offsetY) / h * perlinNoiseScale_Height * scaleFactor
            );
    }

    public void SetColourFromHeight()
    {
        sr.color = new Color(height, height, height, 1f);
    }
}
