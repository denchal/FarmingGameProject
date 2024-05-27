using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacement : MonoBehaviour
{
    public Camera cam;
    public GameObject prefab;
    public GameObject soil;
    private GameObject plant;
    public List<GameObject> plants;
    public Vector3 point;
    public Vector3 soilPoint;
    public Vector3 plantPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        plant = plants[GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().currentSlot];
        Vector3 mousePos = Input.mousePosition;
        RaycastHit hit;
        RaycastHit soilHit;
        RaycastHit plantHit;
        Ray ray = cam.ScreenPointToRay(mousePos);
        Physics.Raycast(ray, out hit, Mathf.Infinity, 1<<6);
        Physics.Raycast(ray, out soilHit, Mathf.Infinity, 1<<7);
        Physics.Raycast(ray, out plantHit, Mathf.Infinity, 1<<8);
        point = hit.point;
        soilPoint = soilHit.point;
        plantPoint = plantHit.point;
        if (Input.GetMouseButtonDown(0)) {
            GameObject helper = GameObject.FindGameObjectWithTag("PlacementHelper");
            if (helper.GetComponent<PlacementHelperScript>().canPlace && helper.GetComponent<PlacementHelperScript>().inBuildMode && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().goldAmount >= (int) Math.Pow(10, MainScript.plotsBuilt + 1)) {
                Instantiate(prefab, point, Quaternion.identity);
                Instantiate(soil, point, Quaternion.identity);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().goldAmount -= (int) Math.Pow(10, MainScript.plotsBuilt + 1);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().plotPositions.Add(point);
                MainScript.plotsBuilt += 1;
            }
            else {
                GameObject plantHelper = GameObject.FindGameObjectWithTag("PlantHelper");
                int inventoryAmount = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().PlantAmounts[GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().currentSlot];
                if (plantHelper.GetComponent<PlantingScript>().canPlant && plantHelper.GetComponent<PlantingScript>().inPlantMode && inventoryAmount > 0) {
                    GameObject planted = Instantiate(plant, plantHelper.GetComponent<PlantingScript>().soil.transform.position, plant.GetComponent<Transform>().rotation);
                    plantHelper.GetComponent<PlantingScript>().soil.GetComponent<SoilBehaviour>().contains = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().PlantTypes[GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().currentSlot];
                    plantHelper.GetComponent<PlantingScript>().soil.GetComponent<SoilBehaviour>().containsGO = planted;
                    plantHelper.GetComponent<PlantingScript>().soil.GetComponent<SoilBehaviour>().isEmpty = false;
                    planted.GetComponent<PlantBehaviour>().type = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().PlantTypes[GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().currentSlot];
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().PlantAmounts[GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().currentSlot] -= 1;
                }
            }
        }
    }
}
