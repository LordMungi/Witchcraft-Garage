using System.Collections.Generic;
using UnityEngine;

public class RequestManager : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private int minimumCriteria = 2;
    [SerializeField] private int maximumCriteria = 4;

    [Space]
    [SerializeField] private int[] criteriaValues = new int[] { -5, -2, 2, 5 };

    [Header("Broadcast Events")]
    [SerializeField] private RequestEventChannel onRequestPosted;
    [SerializeField] private DevolutionEventChannel onDevolutionPosted;

    public Request currentRequest;
    public bool requestCompleted = true;

    enum SatisfactionRates
    {
        Perfect,
        NotEnough,
        Bad,
        Unacceptable,
        NegPerfect,
        NegNotEnough,
        NegBad,
        NegUnacceptable,
        Invalid
    }

    private void Start()
    {
        requestCompleted = true;
    }

    public void CreateRequest()
    {
        if (!requestCompleted)
            return;

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
                    currentRequest.stats.sadHappy = newValue;
                    break;
                case 2:
                    currentRequest.stats.nostalgicMature = newValue;
                    break;
                case 3:
                    currentRequest.stats.anxiousCalm = newValue;
                    break;
                case 4:
                    currentRequest.stats.heartbreakLove = newValue;
                    break;
                case 5:
                    currentRequest.stats.drowsinessEnergy = newValue;
                    break;
                default:
                    break;
            }
        }
        currentRequest.text = " H/S: " + currentRequest.stats.sadHappy + "\n  N/M: " + currentRequest.stats.nostalgicMature + "\n  A/C: " + currentRequest.stats.anxiousCalm + "\n  L/H: " + currentRequest.stats.heartbreakLove + "\n  E/D: " + currentRequest.stats.drowsinessEnergy;
        requestCompleted = false;

        onRequestPosted.RaiseEvent(currentRequest);
    }

    public Devolution ComparePotion(Statistics stats)
    {
        Devolution newDevolution = new Devolution();

        int criteriaQuantity = 0;
        float newRating = 0f;

        #region SadHappy
        SatisfactionRates sadHappyRating = compareStat(currentRequest.stats.sadHappy, stats.sadHappy);
        string sadHappyText = "";

        if (sadHappyRating != SatisfactionRates.Invalid)
        {
            criteriaQuantity++;
            switch (sadHappyRating)
            {
                case SatisfactionRates.Unacceptable:
                    newRating += 0;
                    sadHappyText = "It was awful, it made me sad. ";
                    break;
                case SatisfactionRates.Bad:
                    newRating += 1;
                    sadHappyText = "It didn't make me happy. ";
                    break;
                case SatisfactionRates.NotEnough:
                    newRating += 2;
                    sadHappyText = "It could have made me happier. ";
                    break;
                case SatisfactionRates.Perfect:
                    newRating += 3;
                    sadHappyText = "It made me very happy. ";
                    break;
                case SatisfactionRates.NegUnacceptable:
                    newRating += 0;
                    sadHappyText = "It was awful, it made me happy. ";
                    break;
                case SatisfactionRates.NegBad:
                    newRating += 1;
                    sadHappyText = "It didn't make me sad. ";
                    break;
                case SatisfactionRates.NegNotEnough:
                    newRating += 2;
                    sadHappyText = "It could have made me sadder. ";
                    break;
                case SatisfactionRates.NegPerfect:
                    newRating += 3;
                    sadHappyText = "It made me very sad. ";
                    break;
                default:
                    break;
            }
        }
        newDevolution.text += sadHappyText;
        #endregion

        #region NostalgicMature
        SatisfactionRates nostalgicMatureRating = compareStat(currentRequest.stats.nostalgicMature, stats.nostalgicMature);
        string nostalgicMatureText = "";

        if (nostalgicMatureRating != SatisfactionRates.Invalid)
        {
            criteriaQuantity++;
            switch (nostalgicMatureRating)
            {
                case SatisfactionRates.Unacceptable:
                    newRating += 0;
                    nostalgicMatureText = "It was awful, it made me nostalgic. ";
                    break;
                case SatisfactionRates.Bad:
                    newRating += 1;
                    nostalgicMatureText = "It didn't make me feel mature. ";
                    break;
                case SatisfactionRates.NotEnough:
                    newRating += 2;
                    nostalgicMatureText = "It could have made me feel more mature. ";
                    break;
                case SatisfactionRates.Perfect:
                    newRating += 3;
                    nostalgicMatureText = "It made me feel very mature. ";
                    break;
                case SatisfactionRates.NegUnacceptable:
                    newRating += 0;
                    nostalgicMatureText = "It was awful, it made me feel mature. ";
                    break;
                case SatisfactionRates.NegBad:
                    newRating += 1;
                    nostalgicMatureText = "It didn't make me nostalgic. ";
                    break;
                case SatisfactionRates.NegNotEnough:
                    newRating += 2;
                    nostalgicMatureText = "It could have made me more nostalgic. ";
                    break;
                case SatisfactionRates.NegPerfect:
                    newRating += 3;
                    nostalgicMatureText = "It made me very nostalgic. ";
                    break;
                default:
                    break;
            }
        }
        newDevolution.text += nostalgicMatureText;
        #endregion

        #region AnxiousCalm
        SatisfactionRates anxiousCalmRating = compareStat(currentRequest.stats.anxiousCalm, stats.anxiousCalm);
        string anxiousCalmText = "";

        if (anxiousCalmRating != SatisfactionRates.Invalid)
        {
            criteriaQuantity++;
            switch (anxiousCalmRating)
            {
                case SatisfactionRates.Unacceptable:
                    newRating += 0;
                    anxiousCalmText = "It was awful, it made me anxious. ";
                    break;
                case SatisfactionRates.Bad:
                    newRating += 1;
                    anxiousCalmText = "It didn't make me calm. ";
                    break;
                case SatisfactionRates.NotEnough:
                    newRating += 2;
                    anxiousCalmText = "It could have made me calmer. ";
                    break;
                case SatisfactionRates.Perfect:
                    newRating += 3;
                    anxiousCalmText = "It made me very calm. ";
                    break;
                case SatisfactionRates.NegUnacceptable:
                    newRating += 0;
                    anxiousCalmText = "It was awful, it made me feel calm. ";
                    break;
                case SatisfactionRates.NegBad:
                    newRating += 1;
                    anxiousCalmText = "It didn't make me anxious. ";
                    break;
                case SatisfactionRates.NegNotEnough:
                    newRating += 2;
                    anxiousCalmText = "It could have made me more anxious. ";
                    break;
                case SatisfactionRates.NegPerfect:
                    newRating += 3;
                    anxiousCalmText = "It made me very anxious. ";
                    break;
                default:
                    break;
            }
        }
        newDevolution.text += anxiousCalmText;
        #endregion

        #region HeartbreakLove
        SatisfactionRates heartbreakLoveRating = compareStat(currentRequest.stats.heartbreakLove, stats.heartbreakLove);
        string heartbreakLoveText = "";

        if (heartbreakLoveRating != SatisfactionRates.Invalid)
        {
            criteriaQuantity++;
            switch (heartbreakLoveRating)
            {
                case SatisfactionRates.Unacceptable:
                    newRating += 0;
                    heartbreakLoveText = "It was awful, it made me feel heartbroken. ";
                    break;
                case SatisfactionRates.Bad:
                    newRating += 1;
                    heartbreakLoveText = "It didn't make me feel love. ";
                    break;
                case SatisfactionRates.NotEnough:
                    newRating += 2;
                    heartbreakLoveText = "It could have made me feel more love. ";
                    break;
                case SatisfactionRates.Perfect:
                    newRating += 3;
                    heartbreakLoveText = "It made me feel a lot of love. ";
                    break;
                case SatisfactionRates.NegUnacceptable:
                    newRating += 0;
                    heartbreakLoveText = "It was awful, it made me feel love. ";
                    break;
                case SatisfactionRates.NegBad:
                    newRating += 1;
                    heartbreakLoveText = "It didn't make me feel heartbroken. ";
                    break;
                case SatisfactionRates.NegNotEnough:
                    newRating += 2;
                    heartbreakLoveText = "It could have made me more heartbroken. ";
                    break;
                case SatisfactionRates.NegPerfect:
                    newRating += 3;
                    heartbreakLoveText = "It made me feel very heartbroken. ";
                    break;
                default:
                    break;
            }
        }
        newDevolution.text += heartbreakLoveText;
        #endregion

        #region DrowsinessEnergy
        SatisfactionRates drowsinessEnergyRating = compareStat(currentRequest.stats.drowsinessEnergy, stats.drowsinessEnergy);
        string drowsinessEnergyText = "";

        if (drowsinessEnergyRating != SatisfactionRates.Invalid)
        {
            criteriaQuantity++;
            switch (drowsinessEnergyRating)
            {
                case SatisfactionRates.Unacceptable:
                    newRating += 0;
                    drowsinessEnergyText = "It was awful, it made me sleepy. ";
                    break;
                case SatisfactionRates.Bad:
                    newRating += 1;
                    drowsinessEnergyText = "It didn't make me energetic. ";
                    break;
                case SatisfactionRates.NotEnough:
                    newRating += 2;
                    drowsinessEnergyText = "It could have made me more energetic. ";
                    break;
                case SatisfactionRates.Perfect:
                    newRating += 3;
                    drowsinessEnergyText = "It made me feel very energetic. ";
                    break;
                case SatisfactionRates.NegUnacceptable:
                    newRating += 0;
                    drowsinessEnergyText = "It was awful, it made me feel energetic. ";
                    break;
                case SatisfactionRates.NegBad:
                    newRating += 1;
                    drowsinessEnergyText = "It didn't make me sleepy. ";
                    break;
                case SatisfactionRates.NegNotEnough:
                    newRating += 2;
                    drowsinessEnergyText = "It could have made me sleepier. ";
                    break;
                case SatisfactionRates.NegPerfect:
                    newRating += 3;
                    drowsinessEnergyText = "It made me very sleepy. ";
                    break;
                default:
                    break;
            }
        }
        newDevolution.text += drowsinessEnergyText;
        #endregion


        if (criteriaQuantity != 0)
            newDevolution.rating = newRating / criteriaQuantity / 3 * 10;

        requestCompleted = true;

        onDevolutionPosted.RaiseEvent(newDevolution);
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
            else if (potionStat >= 0)
                return SatisfactionRates.Bad;
            else 
                return SatisfactionRates.Unacceptable;
        }
        else
        {
            if (potionStat <= requestStat)
                return SatisfactionRates.NegPerfect;
            else if (potionStat <= requestStat / 2)
                return SatisfactionRates.NegNotEnough;
            else if (potionStat <= 0)
                return SatisfactionRates.NegBad;
            else
                return SatisfactionRates.NegUnacceptable;
        }
    }
}
