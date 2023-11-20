using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum TutorialPopupDirection { LEFT_TOP, RIGHT_TOP, LEFT_DOWN, RIGHT_DOWN }

public class TutorialPopup : MonoBehaviour
{
    [SerializeField] private TutorialPopupDirection direction;
    [SerializeField] private GameObject leftTop, rightTop, leftDown, rightDown;

    [SerializeField] private Image circleLT, circleRT, circleLD, circleRD;

    [SerializeField] private bool withCircle = true;

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string content;

    void Start()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + new Vector3(0f, -200f, 0f);
        LeanTween.move(gameObject, endPos, 2f).setEase(LeanTweenType.easeOutElastic);
    }

    void SetActiveObject(GameObject obj)
    {
        leftTop.SetActive(obj == leftTop);
        circleLT.gameObject.SetActive(withCircle);
        rightTop.SetActive(obj == rightTop);
        circleRT.gameObject.SetActive(withCircle);
        leftDown.SetActive(obj == leftDown);
        circleLD.gameObject.SetActive(withCircle);
        rightDown.SetActive(obj == rightDown);
        circleRD.gameObject.SetActive(withCircle);
    }

    void Update()
    {
        text.SetText(content);
        switch (direction)
        {
            case TutorialPopupDirection.LEFT_TOP:
                SetActiveObject(leftTop);
                break;
            case TutorialPopupDirection.RIGHT_TOP:
                SetActiveObject(rightTop);
                break;
            case TutorialPopupDirection.LEFT_DOWN:
                SetActiveObject(leftDown);
                break;
            case TutorialPopupDirection.RIGHT_DOWN:
                SetActiveObject(rightDown);
                break;
        }
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
