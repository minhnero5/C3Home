using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : ThanguMonoBehavior, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] protected Transform realParent;
    [SerializeField] protected Image image;

    public virtual void SetRealParent(Transform realParent)
    {
        this.realParent = realParent;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImage();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        this.realParent = transform.parent;
        transform.SetParent(UIHotkeyController.Instance.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousPos = InputManager.Instance.MouseWorldPosition;
        mousPos.z = 0;
        transform.position = mousPos;
        this.image.raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        transform.SetParent(this.realParent);
        this.image.raycastTarget = true;
    }

    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadImage", gameObject);
    }

}
