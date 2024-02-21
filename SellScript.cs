using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellScript : MonoBehaviour
{
    public string plantName;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(Sell);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Sell() {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        int i = MainScript.PlantNameToInt(plantName);
        if (player.PlantAmounts[i] > 0) {
            player.goldAmount += (int) (Math.Pow(2, i) + i)*player.PlantAmounts[i];
            player.PlantAmounts[i] = 0;
        }
    }
}
