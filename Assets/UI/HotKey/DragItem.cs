using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : ThanguMonoBehavior, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] protected Transform realParent;
    public void OnBeginDrag(PointerEventData eventData)
    {
        this.realParent = transform.parent;
        transform.parent = UIHotkeyController.Instance.transform;
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
        transform.parent = this.realParent;
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
