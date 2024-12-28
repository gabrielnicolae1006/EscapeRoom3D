using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //===ITEM DATA===//
    public string itemName;
    public Sprite itemSprite;
    public GameObject itemObject;
    public bool isFull;
    public string itemDescription;
    
    //===ITEM SLOT===//
    [SerializeField]
    private Image itemImage;

    //===ITEM DESCRIPTION SLOT===//
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;

    public GameObject selectedShader;
    public bool thisItemSelected;
    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("Inventory").GetComponent<InventoryManager>();
        Deselect();
    }

    public void AddItem(string itemName, Sprite itemIcon, GameObject itemObject, string itemDescription)
    {
        this.itemName = itemName;
        this.itemSprite = itemIcon;
        this.itemObject = itemObject;
        this.itemDescription = itemDescription;
        isFull = true;

        if (itemImage != null)
        {
            itemImage.sprite = itemIcon;
            itemImage.enabled = true;
        }
    }

    public void UseItem()
    {
        if (itemObject != null)
        {
            itemObject.SetActive(true);
        }
        ClearSlot();
    }

    public void ClearSlot()
    {
        itemName = null;
        itemSprite = null;
        itemObject = null;
        isFull = false;

        if (itemImage != null)
        {
            itemImage.sprite = null;
            itemImage.enabled = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
    }

    public void OnLeftClick()
    {
        inventoryManager.SelectedSlot(this);
        Select();
        ItemDescriptionName.text = itemName;
        ItemDescriptionText.text = itemDescription;
    }

    public void Select()
    {
        selectedShader.SetActive(true);
        thisItemSelected = true;
    }

    public void Deselect()
    {
        selectedShader.SetActive(false);
        thisItemSelected = false;
    }
}