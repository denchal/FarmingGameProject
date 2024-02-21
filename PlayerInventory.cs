using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int goldAmount;
    public List<string> PlantTypes;
    public List<int> PlantAmounts;
    public int currentSlot = 0;
    // Start is called before the first frame update
    void Start()
    {
        goldAmount = 11;
        PlantAmounts = new List<int> {1,0,0,0,0};
        PlantTypes = new List<string>{"Wheat", "Sunflower", "Cabbage", "Corn", "Dragonfruit"};
    }

    // Update is called once per frame
    void Update()
    {

    }
}
