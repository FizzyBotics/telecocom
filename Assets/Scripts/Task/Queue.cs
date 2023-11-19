using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Queue : MonoBehaviour
{
    [SerializeField] private Server[] servers;
    [SerializeField] GameObject prefab;
    [SerializeField] private Image bTv, bPc, bWeb, bPhone; //background colors of counter
    public GameObject canva;

    public Counter tv, pc, web, phone;
    public List<VirtualMachine> bookedList = new List<VirtualMachine>();

    private bool winPopupSpawn = false;


    private static Color green = new Color(71f / 255f, 190f / 255f, 127f / 255f);
    private static Color red = new Color(190f / 255f, 71f / 255f, 71f / 255f);

    void UpdateColor(Image element, int value) => element.color = (value == 0) ? green : red;

    void Update()
    {
        if (servers.Count() > 0)
        {
            ProcessVirtualMachines(TypeElement.TV, tv);
            ProcessVirtualMachines(TypeElement.PC, pc);
            ProcessVirtualMachines(TypeElement.WEB, web);
            ProcessVirtualMachines(TypeElement.PHONE, phone);
            UpdateColor(bTv, tv.value);
            UpdateColor(bPc, pc.value);
            UpdateColor(bWeb, web.value);
            UpdateColor(bPhone, phone.value);

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
