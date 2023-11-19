using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Queue : MonoBehaviour
{
    [SerializeField] private Server[] servers;
    [SerializeField] GameObject prefab, canva;

    public Counter tv, pc, web, phone;
    public List<VirtualMachine> bookedList = new List<VirtualMachine>();

    private bool winPopupSpawn = false;



    void Update()
    {
        if (servers.Count() > 0)
        {
            ProcessVirtualMachines(TypeElement.TV, tv);
            ProcessVirtualMachines(TypeElement.PC, pc);
            ProcessVirtualMachines(TypeElement.WEB, web);
            ProcessVirtualMachines(TypeElement.PHONE, phone);

            if (tv.value == 0 && pc.value == 0 && web.value == 0 && phone.value == 0 && winPopupSpawn == false && canva != null)
            {
                Instantiate(prefab, canva.transform);
                winPopupSpawn = true;
            }
        }
    }

    private void ProcessVirtualMachines(TypeElement elementType, Counter decrementer)
    {
        if (decrementer.value > 0)
        {
            foreach (Server server in servers)
            {
                List<VirtualMachine> elements = server.GetVirtualMachineType(elementType);
                if (elements != null && elements.Count > 0)
                {
                    foreach (VirtualMachine element in elements)
                    {
                        if (!bookedList.Contains(element))
                        {
                            bookedList.Add(element);
                            element.slotsTaken = (decrementer.value > 10) ? 10 : decrementer.value;
                            Debug.Log($"Envoie des {element.slotsTaken} users dans la machine virtuelle");
                            var target = (decrementer.value - 10 >= 0) ? (decrementer.value - 10) : 0;
                            if (decrementer.value > 0) decrementer.Decrement(target);
                        }
                    }
                }
            }
        }
    }
}
