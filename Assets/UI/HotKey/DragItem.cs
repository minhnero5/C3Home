using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : ThanguMonoBehavior, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousPos = InputManager.Instance.MouseWorldPosition;
        mousPos.z = 0;
        transform.position = mousPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
