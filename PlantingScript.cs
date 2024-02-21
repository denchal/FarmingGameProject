using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantingScript : MonoBehaviour
{
    private GameObject plantToggle;
    public GameObject plantHelper;
    public List<GameObject> collidingWith = new List<GameObject>();
    public GameObject plane;
    public bool inPlantMode = false;
    public bool canPlant = false;
    public GameObject soil;
    // Start is called before the first frame update
    void Start()
    {
        plantToggle = GameObject.FindGameObjectWithTag("PlantToggle");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = plane.GetComponent<ObjectPlacement>().soilPoint;
        GameObject helper = GameObject.FindGameObjectWithTag("PlantHelper");
        helper.GetComponent<MeshFilter>().mesh = GameObject.FindGameObjectWithTag("Ground").GetComponent<ObjectPlacement>().plants[GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().currentSlot].GetComponent<MeshFilter>().sharedMesh;
        helper.transform.rotation = GameObject.FindGameObjectWithTag("Ground").GetComponent<ObjectPlacement>().plants[GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().currentSlot].transform.rotation;
        if (plantToggle.GetComponent<Toggle>().isOn && plantToggle.GetComponent<BuildToggleNoPlaceHover>().isHoveredOver == false) {
            inPlantMode = true;
            if (collidingWith.Count == 0 || point == new Vector3(0,0,0)) {
                plantHelper.transform.position = plane.GetComponent<ObjectPlacement>().point;
                helper.GetComponent<MeshRenderer>().material.color = Color.red;
                canPlant = false;
            }
            else {
                soil = collidingWith[0];
                plantHelper.transform.position = point;
                if (soil.GetComponent<SoilBehaviour>().isEmpty) {
                    helper.GetComponent<MeshRenderer>().material.color = Color.green;
                    canPlant = true; 
                }
                else {
                    helper.GetComponent<MeshRenderer>().material.color = Color.red;
                    canPlant = false;
                }
            }
        }
        else {
            inPlantMode = false;
            plantHelper.transform.position = new Vector3(1000F, 1000F, 1000F);
        }
    }

    void OnCollisionEnter (Collision col) {

		if (col.collider.includeLayers == 1<<7)
		    collidingWith.Add (col.gameObject);
	}

	void OnCollisionExit (Collision col) {

		if (col.collider.includeLayers == 1<<7)
		    collidingWith.Remove (col.gameObject);
	}
}
