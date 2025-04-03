using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ItemSlot : ThanguMonoBehavior, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropObj = eventData.pointerDrag;
        DragItem dragItem = dropObj.GetComponent<DragItem>();
        dragItem.SetRealParent(transform);
    }
}
