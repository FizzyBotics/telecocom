using UnityEngine;
using TMPro;
using System;

public class VirtualMachine : MonoBehaviour
{

    [SerializeField] private Queue queue;

    [SerializeField] private TextMeshProUGUI onlineUserText, title;
    [SerializeField] private OnlineUser onlineUser;
    public Type type;

    [Range(0, 10)] public int slotsTaken;

    public GameObject powerButton;
    public Status status;

    public GameObject content;



    public void SwitchMode()
    {
        if (content.activeSelf == false)
        {
            content.SetActive(true);
        }
        else
        {
            ShutDown();
        }
    }

    public bool IsOnline()
    {
        return status.status == StatusType.ON;
    }

    void Update()
    {
        if (content.activeSelf)
        {
            onlineUser.slotsTaken = slotsTaken;
            onlineUserText.SetText($"Utilisateurs connectés: {onlineUser.slotsTaken}/10");
        }
    }

    public void ShutDown()
    {
        ReSendSlotToQueue();
        slotsTaken = onlineUser.slotsTaken = 0;
        content.SetActive(false);
        onlineUserText.SetText($"Utilisateur connectés: 0/10");
    }

    public void SwitchType(GameObject obj)
    {
        ReSendSlotToQueue();
        type.SwitchType();
        title.SetText($"Service : {obj.GetComponent<Type>().type}");
        title.color = type.currentColor;
    }

    public TypeElement GetTypeElement()
    {
        return type.type;
    }

    public void ReSendSlotToQueue()
    {
        if (queue != null)
        {
            var oldvalue = queue.values[type.type] + 0;
            var oldslot = slotsTaken + 0;
            queue.values[type.type] += slotsTaken;
            slotsTaken = 0;
            queue.bookedList.Remove(this);
            queue.counters[type.type].Increment(oldvalue, oldvalue + oldslot);
        }
    }

}
