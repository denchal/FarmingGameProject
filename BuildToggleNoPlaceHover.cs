using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class BuildToggleNoPlaceHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler// required interface when using the OnPointerEnter method.
{
    public bool isHoveredOver = false;
    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHoveredOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHoveredOver = false;
    }
}
