using System.Collections.Generic;
using UnityEngine;

public class Server : MonoBehaviour
{
    [SerializeField] private EnergyMonitor serverEnergy;
    [SerializeField] public Status serverStatus;

    [SerializeField] private VirtualMachine machine1, machine2, machine3;

    // Méthode pour calculer l'énergie utilisée en fonction du nombre de machines en ligne
    private float GetEnergyUsed(float min, float numberOfMachine, int sum)
    {
        float minInit = 0;
        float maxInit = 30;
        float newMin = min;
        float newMax = 0.3f * numberOfMachine + 0.1f;
        float valueNormalize = (sum - minInit) / (maxInit - minInit);
        float value = newMin + (newMax - newMin) * valueNormalize;
        return value;
    }

    public bool IsOnline()
    {
        return serverStatus.status == StatusType.ON;
    }

    public void StartOrCloseServer()
    {
        serverStatus.SwitchMode();
        if (!IsOnline())
        {
            ShutDown();
        }
        else
        {
            serverEnergy.value = 0.04f;
            // Activer les boutons des machines virtuelles uniquement lorsque le serveur est démarré
            machine1.powerButton.SetActive(true);
            machine2.powerButton.SetActive(true);
            machine3.powerButton.SetActive(true);
        }
    }

    public void OnClickPowerButton(VirtualMachine machine)
    {
        if (machine.status.status == StatusType.ON)
        {
            serverEnergy.value += 0.02f;
        }
        else
        {
            serverEnergy.value -= 0.02f;
        }
    }

    public void ShutDown()
    {
        serverEnergy.value = 0f;
        // Désactiver les boutons pour allumer les machines virtuelles
        machine1.powerButton.SetActive(false);
        machine2.powerButton.SetActive(false);
        machine3.powerButton.SetActive(false);
        machine1.status.status = StatusType.OFF;
        machine2.status.status = StatusType.OFF;
        machine3.status.status = StatusType.OFF;
        // Appel de la méthode Shutdown() des préfabs
        machine1.ShutDown();
        machine2.ShutDown();
        machine3.ShutDown();
    }

    void Update()
    {
        if (IsOnline())
        {
            int numberOfOnlineMachines = 0;

            if (machine1.IsOnline())
            {
                numberOfOnlineMachines++;
            }
            if (machine2.IsOnline())
            {
                numberOfOnlineMachines++;
            }
            if (machine3.IsOnline())
            {
                numberOfOnlineMachines++;
            }

            // Utilisation de switch-case pour gérer les différents cas
            switch (numberOfOnlineMachines)
            {
                case 1:
                    serverEnergy.value = GetEnergyUsed(0.06f, numberOfOnlineMachines, machine1.slotsTaken + machine2.slotsTaken + machine3.slotsTaken);
                    break;
                case 2:
                    serverEnergy.value = GetEnergyUsed(0.08f, numberOfOnlineMachines, machine1.slotsTaken + machine2.slotsTaken + machine3.slotsTaken);
                    break;
                case 3:
                    serverEnergy.value = GetEnergyUsed(0.1f, numberOfOnlineMachines, machine1.slotsTaken + machine2.slotsTaken + machine3.slotsTaken);
                    break;
                default:
                    break;
            }
        }
    }

    public List<VirtualMachine> GetVirtualMachineType(TypeElement type)
    {
        List<VirtualMachine> machinesOfType = new List<VirtualMachine>();

        if (machine1.IsOnline() && machine1.GetTypeElement() == type)
        {
            machinesOfType.Add(machine1);
        }
        if (machine2.IsOnline() && machine2.GetTypeElement() == type)
        {
            machinesOfType.Add(machine2);
        }
        if (machine3.IsOnline() && machine3.GetTypeElement() == type)
        {
            machinesOfType.Add(machine3);
        }
        return machinesOfType.Count > 0 ? machinesOfType : null;
    }



}
