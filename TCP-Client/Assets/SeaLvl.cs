using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaLvl : MonoBehaviour
{
    GameObject planet;
    Material planetMaterial;
    // Start is called before the first frame update
    float i = 0;
    void Start()
    {
        planet = GameObject.Find("Sphere");
        planetMaterial = planet.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            i = i + 0.01f;
            planetMaterial.SetFloat("_WaterLevel",i);
        }
    }
}
