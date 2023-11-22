using Pathfinding;
using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private TargetToFollow targetToFollow;

    private void Awake()
    {
        Instance = this;
    }

    public override void OnNetworkSpawn()
    {
        Debug.Log("Lobby code: " + Global.Instance.lobbyCode);
        base.OnNetworkSpawn();

        SpawnPlayerObjectServerRpc();
    }

    [ServerRpc(RequireOwnership = false)]
    public void SpawnPlayerObjectServerRpc(ServerRpcParams rpcParams = default)
    {
        Debug.Log("SpawnPlayerObjectServerRpc");
        GameObject playerObject = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);
        playerObject.GetComponent<AIDestinationSetter>().target = targetToFollow.transform;
        NetworkObject playerNetworkObject = playerObject.GetComponent<NetworkObject>();
        playerNetworkObject.SpawnAsPlayerObject(rpcParams.Receive.SenderClientId);
    }

    public void SetControlledPlayer(Player player)
    {
        player.GetComponent<AIDestinationSetter>().target = targetToFollow.transform;
        player.GetComponent<AIDestinationSetter>().enabled = true;
        Camera.main.transform.SetParent(player.transform);
        Camera.main.transform.localPosition = new Vector3(0, 0, -10);
    }
}
