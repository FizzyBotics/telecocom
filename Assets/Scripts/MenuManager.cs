using System;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private MenuButton[] menuButtons;

    private int currentButtonIndex = -1; // Position of selection in menu

    private void Start()
    {
        for (int i = 0; i < menuButtons.Length; i++)
        {
            menuButtons[i].buttonIndex = i;
            menuButtons[i].OnButtonHovered += ChangeHoveredButton;
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
                ChangeHoveredButton(0);
            }
            else
            {
                int newButtonIndex = currentButtonIndex + verticalInput;
                if (newButtonIndex < 0) newButtonIndex = menuButtons.Length - 1;
                else if (newButtonIndex >= menuButtons.Length) newButtonIndex = 0;
                ChangeHoveredButton(newButtonIndex);
            }
        }
    }

    public void ChangeHoveredButton(int buttonIndex)
    {
        if (currentButtonIndex != -1 && currentButtonIndex != buttonIndex)
        {
            menuButtons[currentButtonIndex].AnimateUnhovered();
        }
        currentButtonIndex = buttonIndex;
        menuButtons[currentButtonIndex].AnimateHovered();
        Debug.Log("Hovered button: " + currentButtonIndex);
    }
}
