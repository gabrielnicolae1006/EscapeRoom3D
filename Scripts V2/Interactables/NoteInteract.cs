using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteInteract : Interactable
{
    [SerializeField]
    private Image noteImage;

    private bool isNoteVisible = false;

    protected override void Interact()
    {
        if (noteImage != null)
        {
            isNoteVisible = !isNoteVisible;
            noteImage.gameObject.SetActive(isNoteVisible);
        }
    }
    public void CloseNote()
    {
        if (isNoteVisible != false)
        {
            isNoteVisible = false;
            noteImage.gameObject.SetActive(false);
        }
    }
}