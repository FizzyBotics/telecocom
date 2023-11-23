using TMPro;
using UnityEngine;

using System;
using System.Linq;
using System.Collections.Generic;

public class Objectives : MonoBehaviour
{
    public Objective[] objs;
    public List<Objective> bookedList = new List<Objective>();

    [SerializeField] private TextMeshProUGUI titleFinish;

    void Update()
    {
        Objective unreleasedObjective = objs.FirstOrDefault(obj => obj.released && !bookedList.Contains(obj));

        if (unreleasedObjective != null)
        {
            int index = Array.IndexOf(objs, unreleasedObjective);
            for (int i = index; i < objs.Length; i++)
            {
                objs[i].MoveToUp();
            }
            bookedList.Add(unreleasedObjective);
        }

        if (IsFinish())
        {
            //titleFinish.color = Color.black;
        }
    }

    public bool IsFinish() => objs.All(objective => objective.released);
}
