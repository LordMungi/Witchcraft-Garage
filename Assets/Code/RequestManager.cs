using System.Collections.Generic;
using UnityEngine;

public class RequestManager : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private int minimumCriteria = 2;
    [SerializeField] private int maximumCriteria = 4;

    [Space]
    [SerializeField] private int[] criteriaValues = new int[] { -5, -2, 2, 5 };

    public Request currentRequest;

    enum SatisfactionRates
    {
        Perfect,
        NotEnough,
        Bad,
        NegPerfect,
        NegNotEnough,
        NegBad,
        Invalid
    }

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

    public Devolution ComparePotion(Statistics stats)
    {
        Devolution newDevolution = new Devolution();

        int criteriaQuantity = 0;
        int newRating = 0;

        #region HappySad
        SatisfactionRates happySadRating = compareStat(currentRequest.stats.happySad, stats.happySad);
        string happySadText = "";

        if (happySadRating != SatisfactionRates.Invalid)
        {
            criteriaQuantity++;
            switch (happySadRating)
            {
                case SatisfactionRates.Bad:
                    newRating += 1;
                    happySadText = "It didn't make me happy. ";
                    break;
                case SatisfactionRates.NotEnough:
                    newRating += 2;
                    happySadText = "It could have made me happier. ";
                    break;
                case SatisfactionRates.Perfect:
                    newRating += 3;
                    happySadText = "It made me very happy. ";
                    break;
                case SatisfactionRates.NegBad:
                    newRating += 1;
                    happySadText = "It didn't make me sad. ";
                    break;
                case SatisfactionRates.NegNotEnough:
                    newRating += 2;
                    happySadText = "It could have made me sadder. ";
                    break;
                case SatisfactionRates.NegPerfect:
                    newRating += 3;
                    happySadText = "It made me very sad. ";
                    break;
                default:
                    break;
            }
        }
        newDevolution.text += happySadText;
        #endregion

        if (criteriaQuantity != 0)
            newDevolution.rating = newRating / criteriaQuantity / 3 * 10;

        Debug.Log(newDevolution.rating + ": " + newDevolution.text);
        return newDevolution;
    }

    private SatisfactionRates compareStat(int requestStat, int potionStat)
    {
        if (requestStat == 0)
        {
            return SatisfactionRates.Invalid;
        }
        else if (requestStat > 0)
        {
            if (potionStat >= requestStat)
                return SatisfactionRates.Perfect;
            else if (potionStat >= requestStat / 2)
                return SatisfactionRates.NotEnough;
            else
                return SatisfactionRates.Bad;
        }
        else
        {
            if (potionStat <= requestStat)
                return SatisfactionRates.Perfect;
            else if (potionStat <= requestStat / 2)
                return SatisfactionRates.NotEnough;
            else
                return SatisfactionRates.Bad;
        }
    }
}
