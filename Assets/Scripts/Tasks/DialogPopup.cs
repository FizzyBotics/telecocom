using System;
using System.Collections;
using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class DialogPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI arrow, arrow2, choice, choice2, textClient, nameClient;

    public Dictionary<TextMeshProUGUI, TextMeshProUGUI> values = new();

    private bool hasMoved = false;

    [Range(0.1f, 2f)][SerializeField] private float durationPeriod = 1;

    private TreeNode parentTree;

    [SerializeField] private GameObject parentDisplay;
    [SerializeField] private WinPopup winPopup;

    string[] prenoms = {
             "Bob", "Charlie",  "Ethan", "George",  "Isaac",
    };

    string[] nomsDeFamille = {
        "Martin", "Bernard", "Dubois", "Thomas", "Richard", "Petit", "Durand", "Leroy", "Moreau", "Simon"
    };

    static string CenterText(string text, int width)
    {
        if (text.Length >= width)
        {
            return text;
        }

        int spaces = width - text.Length;
        int leftPadding = spaces / 2;
        int rightPadding = spaces - leftPadding;

        return new string(' ', leftPadding) + text + new string(' ', rightPadding);
    }


    private void Start()
    {
        parentDisplay = gameObject.transform.parent.gameObject;
        values.Add(choice, arrow);
        values.Add(choice2, arrow2);
        CreateTreeDialogue();
        choice.SetText(parentTree.Children.ToArray()[0].Tag);
        choice2.SetText(parentTree.Children.ToArray()[1].Tag);
        System.Random rand = new();
        nameClient.SetText(CenterText(prenoms[rand.Next(prenoms.Length)] + " " + nomsDeFamille[rand.Next(nomsDeFamille.Length)], textClient.text.Length));
        StartCoroutine(Animation());
    }


    private IEnumerator Animation()
    {
        while (true)
        {
            if (!hasMoved)
            {
                arrow.SetText(" >");
                arrow2.SetText(" >");
                hasMoved = true;
            }
            else
            {
                arrow.SetText(">");
                arrow2.SetText(">");
                hasMoved = false;
            }
            yield return new WaitForSeconds(durationPeriod);
        }

    }

    public void UpdateParentOnClick(TextMeshProUGUI t)
    {
        if (parentTree == null) return;
        if (parentTree.Children.Count > 0)
        {
            if (parentTree.Children.ToArray()[0].Tag == t.text)
                parentTree = parentTree.Children.ToArray()[0];
            else
                parentTree = parentTree.Children.ToArray()[1];

            textClient.SetText(parentTree.ResponseClient);
            if (parentTree.Children.Count > 0)
            {
                choice.SetText(parentTree.Children.ToArray()[0].Tag);
                choice2.SetText(parentTree.Children.ToArray()[1].Tag);
            }
            else
            {
                Debug.Log("Parent actuel: " + parentTree.Tag + " " + parentTree.Stars);
                winPopup = Instantiate(winPopup, parentDisplay.transform);
                winPopup.stars = parentTree.Stars;
            }
        }

    }

    public void SetHover(TextMeshProUGUI text) => text.color = values[text].color = new Color(14f / 255f, 12f / 255f, 196f / 255f);

    public void SetExitColor(TextMeshProUGUI text) => text.color = values[text].color = Color.black;

    private void CreateTreeDialogue()
    {
        TreeNode root = new("", "Bonjour puis-je avoir un téléphone ?");
        TreeNode node1 = new("Je vous propose un modèle haut de gamme", "Oh bien ! ");
        TreeNode node2 = new("Je vous Propose un modèle milieu de gamme reconditionné", "D'accord...");

        TreeNode node3 = new("Proposez un fairphone", "Je vais prendre ce téléphone");
        TreeNode node4 = new("Il n'y a aucun problèmes.", "Ok ahah Il y a une garantie ?");
        TreeNode node5 = new("Proposez un téléphone reconditionné en très bon état", "Ha");
        TreeNode node6 = new("Excellente décision", "Merci je pense revenir bientôt pour une télé", 3);
        TreeNode node7 = new("Excellent choix", "Merci je pense revenir bientôt pour une télé", 3);
        TreeNode node8 = new("Je vous proposez une garantie de 12 mois", "Ok Très bien", 1);
        TreeNode node9 = new("Je vous propose une garantie de 24 mois", "Ok très bien", 2);

        root.AddChild(node1);
        root.AddChild(node2);

        node1.AddChild(node3);
        node1.AddChild(node5);

        node2.AddChild(node3);
        node2.AddChild(node4);

        node3.AddChild(node6);
        node3.AddChild(node7);

        node4.AddChild(node8);
        node4.AddChild(node9);

        node5.AddChild(node8);
        node5.AddChild(node9);
        parentTree = root;
        textClient.SetText(parentTree.ResponseClient);
    }



}
