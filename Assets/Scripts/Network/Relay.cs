using System.Threading.Tasks;
using QFSW.QC;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;

public class Relay : MonoBehaviour
{
    [SerializeField] private int maxNumberOfParticipants = 10;
    private bool authenticated = false;

    private async Task Authenticate()
    {
        try
        {
            if (authenticated) return;
            await UnityServices.InitializeAsync();
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            authenticated = true;
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    [Command]
    public async Task CreateRelay()
    {
        try
        {
            await Authenticate();

            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(maxNumberOfParticipants);

            string joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

            Debug.Log($"Join code: {joinCode}");
            Global.Instance.lobbyCode = joinCode;

            RelayServerData relayServerData = new(allocation, "dtls");

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

            NetworkManager.Singleton.StartHost();
        }
        catch (RelayServiceException e)
        {
            Debug.Log(e.Message);
        }
    }

    [Command]
    public async Task JoinRelay(string joinCode)
    {
        try
        {
            await Authenticate();

            JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);

            RelayServerData relayServerData = new(joinAllocation, "dtls");

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

            NetworkManager.Singleton.StartClient();
        }
        catch (RelayServiceException e)
        {
            Debug.Log(e.Message);
        }
    }
}

