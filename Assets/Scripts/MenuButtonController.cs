using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour
{


    /*
        En résumé, index représente la position actuelle de l’utilisateur dans le menu. Il est mis à jour 
        en fonction des entrées de l’utilisateur et est utilisé pour déterminer quelle option du menu doit être 
        mise en évidence ou sélectionnée.
    */
    public int currentButtonIndex; //Laissez en public ! Cette variable est utilisé dans MenuButton.cs

    /*
        Le keyDown sert à s’assurer que l’index ne change qu’une fois par pression de touche, 
        plutôt qu’à chaque frame pendant que la touche est enfoncée.

        Lorsque l’utilisateur relâche la touche, verticalInput devient 0, et keyDown est alors défini sur false. 
        Cela signifie que le code est prêt à accepter une autre entrée de l’utilisateur.
    */

    [SerializeField] bool keyDown;

    /*
        maxIndex représente le nombre total d’options dans le menu -1. Il est utilisé pour contrôler 
        la navigation de l’utilisateur à travers les options du menu.
    */
    [SerializeField] int maxIndex;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); //Cette variable sera utilisé dans AnimatorFunction
        //ça permet de faire jouer des sons c trop top :).
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        //Cette ligne de code vérifie si l’utilisateur a appuyé sur une touche (haut ou bas : clavier ou manette) et
        //si aucune touchen’était précédemment enfoncée.
        if (verticalInput != 0 && !keyDown)
        {
            //index = (int)Mathf.Repeat(index - (int)Mathf.Sign(verticalInput), maxIndex + 1);
            currentButtonIndex = (int)(currentButtonIndex - Mathf.Sign(verticalInput) + maxIndex + 1) % (maxIndex + 1);
            //On récupère l'indice du bouton correspondant à l'action
            keyDown = true; //on dit au programme qu'on vient d'enfoncer une touche
        }
        else if (verticalInput == 0) //Si on a pas appuiyé sur une touche
        {
            keyDown = false; //reset
        }
    }
    //Tu as tous lu je suis fière de toi mon bébou 
}