using System.Collections.Generic;
using UnityEngine;

public partial class RequestManager : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private int minimumCriteria = 2;
    [SerializeField] private int maximumCriteria = 4;

    [Space]
    [SerializeField] private int[] criteriaValues = new int[] { -5, -2, 2, 5 };

    public Request currentRequest;

    public void CreateRequest()
    {
        currentRequest = new Request();
        currentRequest.stats = new Statistics();

        int criteriaQuantity = Random.Range(minimumCriteria, maximumCriteria + 1);
        List<int> usedCriteria = new List<int>();

        for (int i = 0; i < criteriaQuantity; i++)
        {
            int newCriteria;
            do
            {
                newCriteria = Random.Range(1, 5);
            } while (usedCriteria.Contains(newCriteria));
            usedCriteria.Add(newCriteria);

            int newValue = criteriaValues[Random.Range(0, criteriaValues.Length)];

            switch (newCriteria)
            {
                case 1:
                    currentRequest.stats.happySad = newValue;
                    break;
                case 2:
                    currentRequest.stats.nostalgicMature = newValue;
                    break;
                case 3:
                    currentRequest.stats.anxiousCalm = newValue;
                    break;
                case 4:
                    currentRequest.stats.loveHeartbreak = newValue;
                    break;
                case 5:
                    currentRequest.stats.energyDrowsiness = newValue;
                    break;
                default:
                    break;
            }
        }

        Debug.Log("H/S: " + currentRequest.stats.happySad + "  N/M: " + currentRequest.stats.nostalgicMature + "  A/C: " + currentRequest.stats.anxiousCalm + "  L/H: " + currentRequest.stats.loveHeartbreak + "  E/D: " + currentRequest.stats.energyDrowsiness);
    }
}
