using TMPro;
using UnityEngine;

public class MultiplayerMenu : Menu
{
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField joinCodeInputField;
    [SerializeField] private Relay relay;

    public void OnHostButtonClicked()
    {
        string username = usernameInputField.text;
        if (string.IsNullOrEmpty(username))
        {
            Debug.Log("Username is empty");
            return;
        }

        relay.CreateRelay();
    }

    public void OnJoinButtonClicked()
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

        relay.JoinRelay(joinCode);
    }
}
