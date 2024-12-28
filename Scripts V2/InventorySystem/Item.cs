using UnityEngine;

public class Item : Interactable
{
    [SerializeField]
    private string itemName;

    [SerializeField]
    private Sprite itemIcon;

    [SerializeField]
    private GameObject itemObject;

    [TextArea]
    [SerializeField]
    private string itemDescription;

    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("Inventory").GetComponent<InventoryManager>();
    }

    protected override void Interact()
    {
        if (inventoryManager != null)
        {
            inventoryManager.AddItem(itemName, itemIcon, itemObject, itemDescription);
            gameObject.SetActive(false);
        }
    }
}