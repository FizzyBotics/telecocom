using System.Collections.Generic;
using UnityEngine;

public class HouseTaskManager : MonoBehaviour
{
    [SerializeField] private GameObject testPointsContainer;
    private List<NetworkTester> testPoints;

    private void Start()
    {
        testPoints = new List<NetworkTester>();
        foreach (Transform child in testPointsContainer.transform)
        {
            if (child.TryGetComponent(out NetworkTester testPoint))
            {
                testPoints.Add(testPoint);
                testPoint.networkReceiver.OnRangeChange += CheckVictory;
            }
        }
    }

    private void CheckVictory(bool osef)
    {
        bool allInRange = true;
        foreach (NetworkTester testPoint in testPoints)
        {
            if (!testPoint.networkReceiver.IsInRange())
            {
                allInRange = false;
                break;
            }
        }
        if (allInRange)
        {
            Win();
        }
    }

    private void Win()
    {
        Debug.Log("Win");
        Destroy(gameObject);
    }
}
