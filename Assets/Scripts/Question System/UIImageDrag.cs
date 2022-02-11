using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIImageDrag : MonoBehaviour, IDragHandler, IPointerExitHandler
{
    [SerializeField] RectTransform container;
    RectTransform pos;
    Vector2 anchoredPos;

    private void Awake()
    {
        pos = GetComponent<RectTransform>();
        anchoredPos = pos.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position += (Vector3)eventData.delta;
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (container.rect.Contains(anchoredPos))
        {
            pos.anchoredPosition = anchoredPos;
            Debug.Log("Hola");

        }
        ;
    }

    //private void OnMouseDrag()
    //{
    //    Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    transform.position = new Vector3(newPos.x, newPos.y, 0);
    //}
}
