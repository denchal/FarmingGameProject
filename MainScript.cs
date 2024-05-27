using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public static int plotsBuilt = 0;
    public GameObject menuPanel;
    public class plantInfo {
        public string name;
        public float time;

        public plantInfo(string name, float time) {
            this.name = name;
            this.time = time;
        }
    }
    public static int PlantNameToInt(string plantName) {
        switch (plantName) {
            case "Wheat": return 0;
            case "Sunflower": return 1;
            case "Cabbage": return 2;
            case "Corn": return 3;
            case "Dragonfruit": return 4;
        }
        return -1;
    }
    public static float GrowthTime(string type) {
        if (type == "Wheat") {
            return 3F;
        }
        else if (type == "Sunflower") {
            return 5F;
        }
        else if (type == "Cabbage") {
            return 7F;
        }
        else if (type == "Corn") {
            return 10F;
        }
        else if (type == "Dragonfruit") {
            return 14F;
        }
        return 100000F;
    }

    public static int PlantBuyPrice(string type) {
        if (type == "Wheat") {
            return 2;
        }
        else if (type == "Sunflower") {
            return 5;
        }
        else if (type == "Cabbage") {
            return 15;
        }
        else if (type == "Corn") {
            return 50;
        }
        else if (type == "Dragonfruit") {
            return 180;
        }
        return 10000;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            menuPanel.GetComponent<CanvasGroup>().alpha = 1;
            menuPanel.GetComponent<CanvasGroup>().interactable = true;
            menuPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
}
