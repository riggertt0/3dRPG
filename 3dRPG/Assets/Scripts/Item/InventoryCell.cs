using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class InventoryCell : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public event Action Injecting;

    [SerializeField] private Text _nameField;
    [SerializeField] private Image _iconField;

    [SerializeField] private InventoryCell _inventoryCellTemplate;

    private Transform _draggingParent;
    private Transform _originalParent;
    private Transform _container;

    private InventoryCell cell;

    public void Init(Transform daggingParent)
    {
        _draggingParent = daggingParent;
        _originalParent = transform.parent;
        _container = GameObject.Find("Inventory").GetComponent<Inventory>()._container;
    }

    public void Render(IItem item)
    {
        _nameField.text = item.Name;
        _iconField.sprite = item.UIIcon;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        cell = Instantiate(_inventoryCellTemplate, _container);
        cell.Init(_draggingParent);
        cell.transform.SetSiblingIndex(transform.GetSiblingIndex());
        transform.SetParent(_draggingParent, false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (In((RectTransform)_originalParent))
            InsertInGrid();
        else
            Inject();
        Destroy(cell.gameObject);
    }

    public void Inject()
    {
        Injecting?.Invoke();
    }

    public void InsertInGrid()
    {
        int closestIndex = 0;

        for (int i = 0; i < _originalParent.transform.childCount; i++)
        {
            if(Vector3.Distance(transform.position, _originalParent.GetChild(i).position) <
                Vector3.Distance(transform.position, _originalParent.GetChild(closestIndex).position))
            {
                closestIndex = i;
            }
        }

        
        transform.SetParent(_originalParent, false);
        int ind = cell.transform.GetSiblingIndex();
        transform.SetSiblingIndex(closestIndex);
        (transform.parent.GetChild(closestIndex + 1)).SetSiblingIndex(ind);
    }

    private bool In(RectTransform originalParent)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(originalParent, transform.position);

        //return originalParent.rect.Contains(transform.position);
    }
}
