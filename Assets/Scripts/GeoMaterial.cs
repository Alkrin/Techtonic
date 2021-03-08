using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GeoMaterialName {
    NotSet,
    Air,
    Dirt,
    Gravel,
    Rock,
}

public class GeoMaterial : MonoBehaviour {
    private Image background;

    private GeoMaterialName materialName = GeoMaterialName.NotSet;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Initialize(GeoMaterialName mName) {
        background = GetComponent<Image>();

        materialName = mName;

        switch (materialName) {
            case GeoMaterialName.Air:
                // Transparent, so we can rely on the skybox or camera settings.
                background.color = new Color32(255, 255, 255, 0);
                break;
            case GeoMaterialName.Dirt:
                background.color = new Color32(155, 118, 53, 255);
                break;
            case GeoMaterialName.Gravel:
                background.color = new Color32(83, 84, 78, 255);
                break;
            case GeoMaterialName.Rock:
                background.color = new Color32(90, 77, 65, 255);
                break;
            default:
                // Screaming magenta, to let you know something is wrong.
                background.color = new Color32(255, 0, 255, 255);
                break;
        }
    }
}
