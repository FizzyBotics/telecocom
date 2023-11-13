using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;
	[SerializeField] Image button;
    bool animationNotExecuted = true;
    void Update()
    {
		if(menuButtonController.currentButtonIndex == thisIndex)
		{
			animator.SetBool ("selected", true);
			if(Input.GetAxis ("Submit") == 1 || Input.GetMouseButtonDown(0)){
				animator.SetBool ("pressed", true);

                //On met le menu en fondu
                Debug.Log("le bout à été cliqué, fondu !s");
                FadeMenu.fadeOut = true;


			}else if (animator.GetBool ("pressed")){
				animator.SetBool ("pressed", false);
				animatorFunctions.disableOnce = true;
			}
		}else{
			animator.SetBool ("selected", false);
		}

        if (button != null)
        {
            // Obtenir les coordonnées de la souris
            Vector3 sourisPosition = Input.mousePosition;

            // Obtenir le RectTransform du button
            RectTransform buttonRect = button.GetComponent<RectTransform>();

            // Convertir la position de la souris en coordonnées locales du rectangle du button
            Vector2 localMousePosition;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(buttonRect, sourisPosition, null, out localMousePosition))
            {
                // Vérifier si la souris est sur le button
                if (buttonRect.rect.Contains(localMousePosition))
                {
                    if (animationNotExecuted)
                    {
                        menuButtonController.currentButtonIndex = thisIndex;
                        animationNotExecuted = false;
                    }
                }
                else
                {
                    animationNotExecuted = true;
                }
            }


        }

    }
}
