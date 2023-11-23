using UnityEngine;

public class Objective2Popup : MonoBehaviour
{
    public GameObject canva;
    [SerializeField] private Popup prefab;
    [SerializeField] private Objective objective;

    private bool spawn = false;

    void Update()
    {
        if (objective.released && !spawn)
        {
            prefab.textContent.SetText("Les machines virtuelles réduisent les serveurs physiques, économisant l'énergie et réduisant l'empreinte carbone télécoms.");
            Instantiate(prefab, canva.transform); Debug.Log("POPUP");
            spawn = true;
        }
    }
}
