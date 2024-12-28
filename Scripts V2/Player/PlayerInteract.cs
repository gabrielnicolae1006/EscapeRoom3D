using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;

    [SerializeField]
    private float distance = 3f;

    [SerializeField]
    private LayerMask mask;

    private PlayerUI playerUI;
    private InputManager inputManager;

    private NoteInteract currentNote;

    [SerializeField]
    private InventoryManager inventoryManager;

    void Start()
    {
        cam = GetComponent<PlayerLook>().playerCamera;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();

        if (inventoryManager == null)
        {
            inventoryManager = FindObjectOfType<InventoryManager>();
        }

    }

    void Update()
    {
        if (currentNote != null)
        {
            if (inputManager.onFoot.Interact.triggered)
            {
                currentNote.CloseNote();
                currentNote = null;
            }
            return;
        }

        if (inputManager.onFoot.Inventory.triggered)
        {
            if (inventoryManager != null)
            {
                inventoryManager.ToggleInventory();
            }
            return;
        }

        playerUI.UpdateText(string.Empty);

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                playerUI.UpdateText(interactable.promptMessage);

                if (inputManager.onFoot.Interact.triggered)
                {
                    interactable.BaseInteract();

                    if (interactable is NoteInteract)
                    {
                        currentNote = interactable as NoteInteract;
                    }
                }
            }
        }
    }
}