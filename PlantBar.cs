using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PlantBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text amountDisplay;
    public string plantName;
    public GameObject panel;
    private bool isTrackingMouse = false;
    public Text priceDisplay;
    public Text timeDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GameObject().GetComponent<Button>();
        btn.onClick.AddListener(Select);
        panel.GetComponentInChildren<Text>().text = plantName.ToUpper();
        timeDisplay.text = MainScript.GrowthTime(plantName).ToString();
        int i = MainScript.PlantNameToInt(plantName);
        priceDisplay.text = (Math.Pow(2, i) + i).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrackingMouse) {
            panel.transform.position = new Vector3(Input.mousePosition.x + 200, Input.mousePosition.y + 100, 0);
        }
        amountDisplay.text = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().PlantAmounts[MainScript.PlantNameToInt(plantName)].ToString();
    }

    void Select() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().currentSlot = MainScript.PlantNameToInt(plantName);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isTrackingMouse = true;
        panel.GetComponent<CanvasGroup>().alpha = 1;
        panel.GetComponent<CanvasGroup>().interactable = true;
        panel.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isTrackingMouse = false;
        panel.GetComponent<CanvasGroup>().alpha = 0;
        panel.GetComponent<CanvasGroup>().interactable = false;
        panel.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

}
