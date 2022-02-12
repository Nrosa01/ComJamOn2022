using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIImageDrag : MonoBehaviour, IDragHandler, IPointerExitHandler
{
    [SerializeField] RectTransform container;
    RectTransform pos;
    Vector2 anchoredPos;
    int UILayer;

    private void Awake()
    {
        UILayer = LayerMask.NameToLayer("UI");
        pos = GetComponent<RectTransform>();
        anchoredPos = pos.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position += (Vector3)eventData.delta;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (IsPointerOverUIElement())
        {
            pos.anchoredPosition = anchoredPos;
        }
        else
        {
            Destroy(this.gameObject);
        }
        ;
    }

    public bool IsPointerOverUIElement() => IsPointerOverUIElement(GetEventSystemRaycastResults());
    
    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == UILayer)
                return true;
        }
        return false;
    }

    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }

    //private void OnMouseDrag()
    //{
    //    Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    transform.position = new Vector3(newPos.x, newPos.y, 0);
    //}
}
