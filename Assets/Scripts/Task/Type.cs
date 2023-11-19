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
    private Color whitePc = new Color(173f / 255f, 130f / 255f, 122f / 255f);
    private Color purpleWeb = new Color(133f / 255f, 123f / 255f, 212f / 255f);
    private Color orangePhone = new Color(164f / 255f, 128f / 255f, 66f / 255f);
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

    private void SetVisibility(bool tvVisibility, bool pcVisibility, bool webVisibility, bool phoneVisibility)
    {
        tv.enabled = tvVisibility;
        pc.enabled = pcVisibility;
        web.enabled = webVisibility;
        phone.enabled = phoneVisibility;
    }

    public void SwitchType()
    {
        switch (type)
        {
            case TypeElement.TV:
                type = TypeElement.PC;
                SetColor(whitePc);
                SetVisibility(false, true, false, false);
                break;
            case TypeElement.PC:
                type = TypeElement.WEB;
                SetColor(purpleWeb);
                SetVisibility(false, false, true, false);
                break;
            case TypeElement.WEB:
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
