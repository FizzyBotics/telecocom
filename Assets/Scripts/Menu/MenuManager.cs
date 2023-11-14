using Unity.Collections;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private MenuButton[] menuButtons;
    [SerializeField] private AudioPlayer audioPlayer;

    private int currentButtonIndex = -1; // Position of selection in menu (-1: no selection)

    private void Start()
    {
        for (int i = 0; i < menuButtons.Length; i++)
        {
            menuButtons[i].buttonIndex = i;
            menuButtons[i].OnButtonHovered += ChangeHoveredButton;
            menuButtons[i].OnButtonSelected += SelectButton;
        }
    }

    private void Update()
    {
        int upKey = Input.GetKeyDown(KeyCode.UpArrow) ? 1 : 0;
        int downKey = Input.GetKeyDown(KeyCode.DownArrow) ? 1 : 0;
        int verticalInput = downKey - upKey;

        if (verticalInput != 0)
        {
            if (currentButtonIndex == -1)
            {
                // If no button is currently selected, select the first one
                ChangeHoveredButton(0);
            }
            else
            {
                int newButtonIndex = currentButtonIndex + verticalInput;
                // Reset to the other end of the menu if we go out of bounds
                if (newButtonIndex < 0) newButtonIndex = menuButtons.Length - 1; // Can't use modulo with negative numbers
                else if (newButtonIndex >= menuButtons.Length) newButtonIndex = 0;
                ChangeHoveredButton(newButtonIndex);
            }
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            SelectButton(currentButtonIndex);
        }
    }

    public void ChangeHoveredButton(int buttonIndex)
    {
        if (currentButtonIndex == buttonIndex) return; // Don't do anything if we're already hovering the button
        if (currentButtonIndex != -1) menuButtons[currentButtonIndex].AnimateUnhovered();
        currentButtonIndex = buttonIndex;
        menuButtons[currentButtonIndex].AnimateHovered();
        audioPlayer.PlayAudioClip("button_hovered");
        Debug.Log("Hovered button: " + currentButtonIndex);
    }

    public void SelectButton(int buttonIndex)
    {
        if (buttonIndex != -1)
        {
            ChangeHoveredButton(buttonIndex); // In case the right button wasn't hovered (unlikely)
            menuButtons[currentButtonIndex].AnimateSelected();
            audioPlayer.PlayAudioClip("button_selected");
        }
    }
}
