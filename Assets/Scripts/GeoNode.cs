using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoNode : MonoBehaviour {
    private GeoMaterial geoMaterial;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Initialize(GeoMaterialName mName) {
        geoMaterial = gameObject.GetComponentInChildren<GeoMaterial>();

        geoMaterial.Initialize(mName);
    }
}
