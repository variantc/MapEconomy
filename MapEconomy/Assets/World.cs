using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    public Tile[,] tileArray;
    public Tile tilePrefab;
    public int mapWidth = 20;
    public int mapHeight = 20;


	// Use this for initialization
	void Start () {
        Camera.main.transform.position = new Vector3(mapWidth / 2 - 0.5f, mapHeight / 2 - 0.5f, -10f);
        tileArray = new Tile[mapWidth, mapHeight];

        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                tileArray[i, j] = Instantiate(tilePrefab, this.transform);
                tileArray[i, j].x = i;
                tileArray[i, j].y = j;
                tileArray[i, j].transform.position = new Vector2(i, j);
                tileArray[i, j].transform.name = "Tile[" + i + "," + j + "]";
            }
        }

        foreach (Tile t in tileArray)
        {
            t.SetHeightFromCoords(mapWidth,mapHeight);
        }
        //foreach (Tile t in tileArray)
        //{
        //    t.SetColourFromHeight();
        //}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
