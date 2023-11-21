using UnityEngine;

public class MenusManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private Menu[] subMenus;

    private void Start()
    {
        foreach (Menu menu in subMenus)
        {
            menu.OnMenuClosed += OnMenuClosed;
        }
    }

    private void OnMenuClosed(Menu menu)
    {
        mainMenu.SetActive(true);
        menu.gameObject.SetActive(false);
    }

    public void OpenSubMenu(Menu menu)
    {
        mainMenu.SetActive(false);
        menu.gameObject.SetActive(true);
    }
}
