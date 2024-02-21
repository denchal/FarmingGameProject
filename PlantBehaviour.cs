using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlantBehaviour : MonoBehaviour
{
    public float timeSincePlanting = 0F;
    private float growthTime;
    public string type;
    public Material grownColor;
    // Start is called before the first frame update
    void Start()
    {
        growthTime = MainScript.GrowthTime(type);
    }

    // Update is called once per frame
    void Update()
    {
        timeSincePlanting += Time.deltaTime;
        if (growthTime <= timeSincePlanting) {
            this.GetComponent<MeshRenderer>().material = grownColor;
            if (this.GetComponent<Collider>().bounds.Contains(GameObject.FindGameObjectWithTag("Ground").GetComponent<ObjectPlacement>().plantPoint)) {
                Destroy(this.gameObject);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().PlantAmounts[MainScript.PlantNameToInt(type)] += 2;
            }
        }
    }
}
