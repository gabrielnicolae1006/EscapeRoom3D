using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;

    public ItemSlot[] itemSlots;

    private ItemSlot currentlySelectedSlot;

    private void Start()
    {
        menuActivated = false;
    }

    public void ToggleInventory()
    {
        menuActivated = !menuActivated;
        InventoryMenu.SetActive(menuActivated);

        if (menuActivated)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
        }
    }

    public void AddItem(string itemName, Sprite itemIcon, GameObject itemObject, string itemDescription)
    {
        foreach (ItemSlot slot in itemSlots)
        {
            if (!slot.isFull)
            {
                slot.AddItem(itemName, itemIcon, itemObject, itemDescription);
                return;
            }
        }
    }

    public void SelectedSlot(ItemSlot newSlot)
    {
        if (currentlySelectedSlot != null)
        {
            currentlySelectedSlot.Deselect();
        }

        currentlySelectedSlot = newSlot;
    }
}