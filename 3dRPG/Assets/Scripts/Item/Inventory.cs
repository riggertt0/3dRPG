using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<AssetItem> Items;
    [SerializeField] private InventoryCell _inventoryCellTemplate;
    [SerializeField] public Transform _container;
    [SerializeField] private Transform _draggingParent;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _itemHeap;
    [SerializeField] private GameObject _findHeap;

    public bool IsFreePlace = true;

    public void OnEnable()
    {
        Render(Items);
    }

    public void Render(List<AssetItem> items)
    {
        foreach (Transform child in _container)
            Destroy(child.gameObject);

        items.ForEach(item =>
        {
            var cell = Instantiate(_inventoryCellTemplate, _container);
            cell.Init(_draggingParent);
            cell.Render(item);
            
            cell.Injecting += () => Destroy(cell.gameObject);
            cell.Injecting += () => {
                GameObject aa = Instantiate(_findHeap, _player.transform.position - new Vector3(0, 0.26f, 0) + _player.transform.forward * 3, _player.transform.rotation);
                
                if (IsFreePlace)
                    Instantiate(_itemHeap, _player.transform.position - new Vector3(0, 0.26f, 0) + _player.transform.forward * 3, _player.transform.rotation);
                else
                    IsFreePlace = true;

            };
        });
    }
}
