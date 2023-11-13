using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] Animator animator;

    public int buttonIndex;
    public delegate void ButtonAction(int buttonIndex);
    public ButtonAction OnButtonHovered;

    public void AnimateHovered()
    {
        animator.SetBool("selected", true);
    }

    public void AnimateUnhovered()
    {
        animator.SetBool("selected", false);
    }

    public void AnimateSelected()
    {
        animator.SetBool("pressed", true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnButtonHovered(buttonIndex);
    }
}
