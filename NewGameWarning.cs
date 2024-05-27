using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewGameWarning : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isTrackingMouse = false;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrackingMouse) {
            panel.transform.position = new Vector3(Input.mousePosition.x + 200, Input.mousePosition.y + 100, 0);
        }
    }

        public void OnPointerEnter(PointerEventData eventData)
    {
        if (File.Exists(Application.dataPath + "/save.txt")) {
            isTrackingMouse = true;
            panel.GetComponent<CanvasGroup>().alpha = 1;
            panel.GetComponent<CanvasGroup>().interactable = true;
            panel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isTrackingMouse = false;
        panel.GetComponent<CanvasGroup>().alpha = 0;
        panel.GetComponent<CanvasGroup>().interactable = false;
        panel.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
