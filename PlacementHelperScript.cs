using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlacementHelperScript : MonoBehaviour
{
    public GameObject helper;
    public List<GameObject> collidingWith = new List<GameObject>();
    public GameObject plane;
    public bool canPlace = true;
    private GameObject toggle;
    public bool inBuildMode = false;

    // Start is called before the first frame update
    void Start()
    {
        toggle = GameObject.FindGameObjectWithTag("BuildToggle");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = plane.GetComponent<ObjectPlacement>().point;
        if (toggle.GetComponent<Toggle>().isOn && toggle.GetComponent<BuildToggleNoPlaceHover>().isHoveredOver == false) {
            inBuildMode = true;
            helper.transform.position = point;
            if (collidingWith.Count > 1) {
                helper.GetComponent<MeshRenderer>().material.color = Color.red;
                canPlace = false;
            }
            else {
                helper.GetComponent<MeshRenderer>().material.color = Color.green;
                canPlace = true;
            }
        }
        else {
            inBuildMode = false;
            helper.transform.position = new Vector3(1000F, 1000F, 1000F);
        }
    }
    void OnCollisionEnter (Collision col) {

		// Add the GameObject collided with to the list.
		collidingWith.Add (col.gameObject);
	}

	void OnCollisionExit (Collision col) {

		// Remove the GameObject collided with from the list.
		collidingWith.Remove (col.gameObject);
	}
}
