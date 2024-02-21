using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlantBar : MonoBehaviour
{
    public Text amountDisplay;
    public string plantName;
    
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GameObject().GetComponent<Button>();
        btn.onClick.AddListener(Select);
    }

    // Update is called once per frame
    void Update()
    {
        amountDisplay.text = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().PlantAmounts[MainScript.PlantNameToInt(plantName)].ToString();
    }

    void Select() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().currentSlot = MainScript.PlantNameToInt(plantName);
    }

}
