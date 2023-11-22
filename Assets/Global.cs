using UnityEngine;

public class Global : MonoBehaviour
{
    public static Global Instance;

    public string lobbyCode;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        Instance = this;
    }
}
