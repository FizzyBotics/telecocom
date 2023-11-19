using UnityEngine;
using UnityEngine.UI;

public enum TypeElement
{
    TV,
    WEB,
    PC,
    PHONE
}

public class Type : MonoBehaviour
{
    [SerializeField] private Image tv, web, pc, phone, color;
    public TypeElement type;
    private Color blueTv = new Color(54f / 255f, 69f / 255f, 152f / 255f);
    private Color greenWeb = new Color(20f / 255f, 163f / 255f, 58f / 255f);
    private Color redPc = new Color(163f / 255f, 44f / 255f, 20f / 255f);
    private Color orangePhone = new Color(163f / 255f, 134f / 255f, 20f / 255f);

    public Color currentColor;

    public Type()
    {
        currentColor = blueTv;
    }

    private void SetColor(Color newColor)
    {
        color.color = newColor;
        currentColor = newColor;
    }

    private void SetVisibility(bool tvVisibility, bool webVisibility, bool pcVisibility, bool phoneVisibility)
    {
        tv.enabled = tvVisibility;
        web.enabled = webVisibility;
        pc.enabled = pcVisibility;
        phone.enabled = phoneVisibility;
    }

    public void SwitchType()
    {
        switch (type)
        {
            case TypeElement.TV:
                type = TypeElement.WEB;
                SetColor(greenWeb);
                SetVisibility(false, true, false, false);
                break;
            case TypeElement.WEB:
                type = TypeElement.PC;
                SetColor(redPc);
                SetVisibility(false, false, true, false);
                break;
            case TypeElement.PC:
                type = TypeElement.PHONE;
                SetColor(orangePhone);
                SetVisibility(false, false, false, true);
                break;
            case TypeElement.PHONE:
                type = TypeElement.TV;
                SetColor(blueTv);
                SetVisibility(true, false, false, false);
                break;
        }

    }

}
