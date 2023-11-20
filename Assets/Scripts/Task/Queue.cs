using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Queue : MonoBehaviour
{

    private static Color green = new Color(71f / 255f, 190f / 255f, 127f / 255f);
    private static Color red = new Color(190f / 255f, 71f / 255f, 71f / 255f);

    [SerializeField] private Server[] servers;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Image bTv, bPc, bWeb, bPhone; //background colors of counter
    public List<VirtualMachine> bookedList = new List<VirtualMachine>();
    public GameObject canva;

    public int tv, pc, web, phone;

    public Counter cTv, cPc, cWeb, cPhone;
    public Dictionary<TypeElement, int> values = new Dictionary<TypeElement, int>();

    public Dictionary<TypeElement, Image> images = new Dictionary<TypeElement, Image>();

    public Dictionary<TypeElement, Counter> counters = new Dictionary<TypeElement, Counter>();
    private bool winPopupSpawn = false;



    private void Start()
    {
        images.Add(TypeElement.TV, bTv);
        images.Add(TypeElement.PC, bPc);
        images.Add(TypeElement.WEB, bWeb);
        images.Add(TypeElement.PHONE, bPhone);

        counters.Add(TypeElement.TV, cTv);
        counters.Add(TypeElement.PC, cPc);
        counters.Add(TypeElement.WEB, cWeb);
        counters.Add(TypeElement.PHONE, cPhone);

        values.Add(TypeElement.TV, tv);
        values.Add(TypeElement.PC, pc);
        values.Add(TypeElement.WEB, web);
        values.Add(TypeElement.PHONE, phone);

        foreach (var v in values.ToList()) counters[v.Key].SetValue(v.Value);
    }
    private void UpdateColor(Image element, TypeElement type) => element.color = (values[type] == 0) ? green : red;
    private void CheckColor()
    {
        foreach (TypeElement t in Enum.GetValues(typeof(TypeElement))) UpdateColor(images[t], t);
    }

    public bool AllElementsZero()
    {
        return values.Values.All(value => value == 0);
    }


    void Update()
    {
        CheckColor();
        if (servers.Length > 0)
        {
            foreach (var v in values.ToList()) ProcessVirtualMachines(v.Key);

            if (AllElementsZero() && !winPopupSpawn && canva != null)
            {
                Instantiate(prefab, canva.transform);
                winPopupSpawn = true;
            }
        }
    }

    private void ProcessVirtualMachines(TypeElement type)
    {
        foreach (Server server in servers)
        {
            List<VirtualMachine> elements = server.GetVirtualMachineType(type);
            if (elements != null && elements.Count > 0)
            {
                foreach (VirtualMachine element in elements)
                {
                    if (!bookedList.Contains(element))
                    {
                        bookedList.Add(element);
                        element.slotsTaken = (values[type] > 10) ? 10 : values[type];
                        var target = (values[type] - 10 >= 0) ? (values[type] - 10) : 0;
                        var oldvalue = values[type];
                        values[type] = target;
                        //Debug.Log(oldvalue + " " + " " + target + " " + values);
                        if (oldvalue > 0) counters[type].Decrement(oldvalue, target);
                    }
                }
            }
        }
    }
}
