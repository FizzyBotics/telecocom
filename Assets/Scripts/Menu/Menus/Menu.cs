using UnityEngine;

public abstract class Menu : MonoBehaviour
{
	public delegate void MenuClosedHandler(Menu menu);
	public event MenuClosedHandler OnMenuClosed;

	public void Close()
	{
		OnMenuClosed?.Invoke(this);
	}
}