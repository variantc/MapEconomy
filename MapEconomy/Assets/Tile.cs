using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    
    public int x;
    public int y;

    public float height;
    public float moisture;
    public float vegetation;

    float perlinNoiseScale = 10f;

    SpriteRenderer sr;
    public Color srColor;

    private void Start()
    {

        sr = GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            Debug.LogError("No SpriteRenderer");
        }
        //else
            //Debug.Log(sr);
    }

    public void SetHeightFromCoords(float width, float height)
    {
        //Debug.Log(x + y);
        height = Mathf.PerlinNoise(x / width * perlinNoiseScale, y / height * perlinNoiseScale);
        Debug.Log(height);
        srColor = new Color(height, height, height, 1f);
        this.sr.color = srColor;
    }
    public void SetColourFromHeight ()
    {
        srColor = new Color(height, height, height, 1f);
        sr.color = srColor;
    }
}
