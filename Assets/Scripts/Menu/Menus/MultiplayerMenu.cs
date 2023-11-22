using TMPro;
using Unity.Netcode;
using UnityEngine;

public class MultiplayerMenu : Menu
{
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField joinCodeInputField;
    [SerializeField] private Relay relay;

    public async void OnHostButtonClicked()
    {
        string username = usernameInputField.text;
        if (string.IsNullOrEmpty(username))
        {
            Debug.Log("Username is empty");
            return;
        }

        await relay.CreateRelay();
        NetworkManager.Singleton.SceneManager.LoadScene("Map", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    public async void OnJoinButtonClicked()
    {
        string username = usernameInputField.text;
        if (string.IsNullOrEmpty(username))
        {
            Debug.Log("Username is empty");
            return;
        }

        string joinCode = joinCodeInputField.text;
        if (string.IsNullOrEmpty(joinCode))
        {
            Debug.Log("Join code is empty");
            return;
        }

        await relay.JoinRelay(joinCode);
    }
}
