using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GeoGrid : MonoBehaviour {
    public Tilemap terrainTilemap;
    public Tile airTile;
    public Tile dirtTile;
    public Tile gravelTile;
    public Tile rockTile;
    public GeoNode geoNodePrefab;
    private GameObject canvas;

    // Start is called before the first frame update
    void Start() {
        canvas = GameObject.Find("Canvas");
        
        GenerateMap();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void GenerateMap() {
        const int kMaxHeight = 15;
        const int kAverageHeight = 10;
        const int kMaxDepth = 5;

        // Max number of y-steps across one x-step.
        const int kMaxSlope = 3;

        // Number of tiles on the far left and right that will have no slope (for easy entrance and exit).
        const int kEdgeSize = 4;

        // TODO: Stick these somewhere more shared?
        const int kNodeWidth = 32;
        const int kNodeHeight = 32;

        const int kNumCols = 25;
        const int kNumRows = 25;

        terrainTilemap.ClearAllTiles();

        System.Random rand = new System.Random();
        int currentHeight = kAverageHeight;
        for (int x = 0; x < kNumCols; ++x) {
            if (x < kEdgeSize || x >= kNumCols - kEdgeSize) {
                // First and last few tiles don't change height.
            } else {
                // Generate peaks and valleys
                int deltaHeight = rand.Next(-kMaxSlope, kMaxSlope + 1);
                int nextHeight = Math.Min(Math.Max(kMaxDepth, currentHeight + deltaHeight), kMaxHeight);
                currentHeight = nextHeight;
            }

            // Generate the actual nodes in this column.
            for (int y = 0; y < kNumRows; ++y) {
                Tile materialTile = y < currentHeight ? rockTile : airTile;

                terrainTilemap.SetTile(new Vector3Int(x, y, 0), materialTile);
            }
        }
    }
}
