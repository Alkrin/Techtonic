using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoGrid : MonoBehaviour {
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
        GeoNode node = Instantiate<GeoNode>(geoNodePrefab, new Vector3(0, 32), Quaternion.identity, canvas.transform);
        node.Initialize(GeoMaterialName.Rock);

        GeoNode node2 = Instantiate<GeoNode>(geoNodePrefab, new Vector3(0, 64), Quaternion.identity, canvas.transform);
        node2.Initialize(GeoMaterialName.Gravel);

        GeoNode node3 = Instantiate<GeoNode>(geoNodePrefab, new Vector3(0, 96), Quaternion.identity, canvas.transform);
        node3.Initialize(GeoMaterialName.Dirt);

        GeoNode node4 = Instantiate<GeoNode>(geoNodePrefab, new Vector3(0, 128), Quaternion.identity, canvas.transform);
        node4.Initialize(GeoMaterialName.Air);
    }
}
