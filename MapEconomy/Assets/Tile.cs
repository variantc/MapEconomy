using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    World world;

    public int x;
    public int y;

    public float height;
    public float moisture;
    public float vegetation;

    float perlinNoiseScale_Height = 2.5f;

    float cummulateScaler = 0f;

    public SpriteRenderer sr;
    //public Color srColor;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        world = FindObjectOfType<World>();
        if (sr == null)
        {
            Debug.LogError("No SpriteRenderer");
        }
    }

    public void SetHeightFromCoords(float w, float h, float offsetX, float offsetY, float scaleFactor, float layerFactor)
    {
        height += Mathf.PerlinNoise(
            (x + layerFactor * offsetX) / w * layerFactor * perlinNoiseScale_Height * layerFactor * scaleFactor, 
            (y + layerFactor * offsetY) / h * layerFactor * perlinNoiseScale_Height * layerFactor * scaleFactor
            );
        cummulateScaler += layerFactor;
        height = height / cummulateScaler;
        cummulateScaler = 1f;

        if (height < world.minHeight)
            world.minHeight = height;
        if (height > world.maxHeight)
            world.maxHeight = height;
    }


    public void SetColourFromHeight()
    {
        sr.color = new Color(height, height, height, 1f);
    }
}
