using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    //public Tile[,] tileArray;
    public Tile tilePrefab;
    int mapWidth = 50;
    int mapHeight = 50;

    
	void Start () {
        Camera.main.transform.position = new Vector3(mapWidth / 2 - 0.5f, mapHeight / 2 - 0.5f, -10f);
        Camera.main.orthographicSize = (mapHeight + mapWidth) / 4;
        //tileArray = new Tile[mapWidth, mapHeight];

        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                Tile t = Instantiate(tilePrefab, this.transform);
                t.x = i;
                t.y = j;
                t.transform.position = new Vector2(i, j);
                t.transform.name = "Tile[" + i + "," + j + "]";
                //tileArray[i, j] = t;
            }
        }

        SetHeightMap();

        foreach (Tile t in FindObjectsOfType<Tile>())
        {
            if (t.height > 0.75f)
                t.sr.color += new Color(t.height, 0f, 0f);
            else if (t.height > 0.35f)
            {
                t.sr.color += new Color (0f, t.height/4, 0f);
            }
            //else if (t.height > 0.3f)
            //    t.sr.color = Color.yellow;
            else if (t.height <= 0.35f)
                t.sr.color += new Color(t.height/32, t.height/32, t.height/2);
        }
    }
	
    void SetHeightMap ()
    {
        // Choose random starting point
        float heightOffsetX = Random.Range(-100f, 100f);
        float heightOffsetY = Random.Range(-100f, 100f);
        float noiseFactor = Random.Range(0.75f, 1.25f);
        foreach (Tile t in FindObjectsOfType<Tile>())
        {
            t.SetHeightFromCoords(mapWidth, mapHeight, heightOffsetX, heightOffsetY, noiseFactor);
            t.SetColourFromHeight();
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
