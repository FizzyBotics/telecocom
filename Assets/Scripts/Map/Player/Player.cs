using Pathfinding;
using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(AIDestinationSetter))]
public class Player : NetworkBehaviour
{
    [SerializeField] private float speed = 5f;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (IsOwner)
        {
            GameManager.Instance.SetControlledPlayer(this);
        }
        else
        {
            GetComponent<AIDestinationSetter>().enabled = false;
        }
    }

    void FixedUpdate()
    {
        if (!IsOwner) return;

        Vector3 input = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        input.Normalize();
        transform.position += speed * Time.fixedDeltaTime * input;
    }
}
