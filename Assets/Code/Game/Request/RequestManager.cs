using System.Collections.Generic;
using UnityEngine;

public class RequestManager : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private int minimumCriteria = 2;
    [SerializeField] private int maximumCriteria = 4;

    [Space]
    [SerializeField] private int[] criteriaValues = new int[] { -5, -2, 2, 5 };

    const int superNeg = -4;
    const int neg = -2;
    const int pos = 2;
    const int superPos = 4;

    [Header("Broadcast Events")]
    [SerializeField] private RequestEventChannel onRequestPosted;
    [SerializeField] private DevolutionEventChannel onDevolutionPosted;

    [Header("Listener Events")]
    [SerializeField] private EventChannel onRequestCreated;

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

    private void OnEnable()
    {
        onRequestCreated.OnEventTriggered += CreateRequest;
    }

    private void OnDisable()
    {
        onRequestCreated.OnEventTriggered -= CreateRequest;
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
                    switch (newValue)
                    {
                        case superNeg:
                            currentRequest.text += "I want to cry my heart out. ";
                            break;
                        case neg:
                            currentRequest.text += "I just need something to help me cry a little bit. ";
                            break;
                        case pos:
                            currentRequest.text += "A little smile won't hurt. ";
                            break;
                        case superPos:
                            currentRequest.text += "I wanna be as joyful as ever. ";
                            break;
                    }

                    break;
                case 2:
                    currentRequest.stats.nostalgicMature = newValue;
                    switch (newValue)
                    {
                        case superNeg:
                            currentRequest.text += "Reliving the past is my biggest passion. ";
                            break;
                        case neg:
                            currentRequest.text += "Make me relive some good ol' memories. ";
                            break;
                        case pos:
                            currentRequest.text += "Not being so childish might come in handy. ";
                            break;
                        case superPos:
                            currentRequest.text += "I'm yearning for maturity, it's about time! ";
                            break;
                    }
                    break;
                case 3:
                    currentRequest.stats.anxiousCalm = newValue;
                    switch (newValue)
                    {
                        case superNeg:
                            currentRequest.text += "I need anxiety in my life! ";
                            break;
                        case neg:
                            currentRequest.text += "A little anxiety might help me with my assignments. ";
                            break;
                        case pos:
                            currentRequest.text += "A little relaxation is always welcome. ";
                            break;
                        case superPos:
                            currentRequest.text += "I want spa levels of relaxation! ";
                            break;
                    }
                    break;
                case 4:
                    currentRequest.stats.heartbreakLove = newValue;
                    switch (newValue)
                    {
                        case superNeg:
                            currentRequest.text += "I need to hate them! ";
                            break;
                        case neg:
                            currentRequest.text += "I need to like them less. ";
                            break;
                        case pos:
                            currentRequest.text += "I would like to fall in love. ";
                            break;
                        case superPos:
                            currentRequest.text += "I want to fall insanely in love! ";
                            break;
                    }
                    break;
                case 5:
                    currentRequest.stats.drowsinessEnergy = newValue;
                    switch (newValue)
                    {
                        case superNeg:
                            currentRequest.text += "I need to sleep for 24hs straight! ";
                            break;
                        case neg:
                            currentRequest.text += "Some rest might help me ";
                            break;
                        case pos:
                            currentRequest.text += "I've been felling tired lately, some energy wouldn't hurt. ";
                            break;
                        case superPos:
                            currentRequest.text += "I want to feel as energetic as a cheetah! ";
                            break;
                    }
                    break;
                default:
                    break;
            }
        }



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
                    sadHappyText = "I can't stop crying, what have you done?! ";
                    break;
                case SatisfactionRates.Bad:
                    newRating += 1;
                    sadHappyText = "You scammer, the potion did nothing! ";
                    break;
                case SatisfactionRates.NotEnough:
                    newRating += 2;
                    sadHappyText = "A good meal would've made me happier... ";
                    break;
                case SatisfactionRates.Perfect:
                    newRating += 3;
                    sadHappyText = "I'm so over the moon!! ";
                    break;
                case SatisfactionRates.NegUnacceptable:
                    newRating += 0;
                    sadHappyText = "How come i'm happier that before??? ";
                    break;
                case SatisfactionRates.NegBad:
                    newRating += 1;
                    sadHappyText = "It had zero effect. ";
                    break;
                case SatisfactionRates.NegNotEnough:
                    newRating += 2;
                    sadHappyText = "I just felt a little down, some more power was needed... ";
                    break;
                case SatisfactionRates.NegPerfect:
                    newRating += 3;
                    sadHappyText = "Don't know how you did it, but i'm sadder than ever!! ";
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
                    nostalgicMatureText = "Everyone stopped taking me seriously! ";
                    break;
                case SatisfactionRates.Bad:
                    newRating += 1;
                    nostalgicMatureText = "Just some weird liquid, no magical side effects, dissapointed. ";
                    break;
                case SatisfactionRates.NotEnough:
                    newRating += 2;
                    nostalgicMatureText = "Got a bit stuck in the teenager stage. ";
                    break;
                case SatisfactionRates.Perfect:
                    newRating += 3;
                    nostalgicMatureText = "Being a grown up is overhated! ";
                    break;
                case SatisfactionRates.NegUnacceptable:
                    newRating += 0;
                    nostalgicMatureText = "Now i simply canLt see the beauty of the past! ";
                    break;
                case SatisfactionRates.NegBad:
                    newRating += 1;
                    nostalgicMatureText = "I paid too much for it to be useless. ";
                    break;
                case SatisfactionRates.NegNotEnough:
                    newRating += 2;
                    nostalgicMatureText = "I would've liked to remember more. ";
                    break;
                case SatisfactionRates.NegPerfect:
                    newRating += 3;
                    nostalgicMatureText = "*sigh* nothing like the good old days... ";
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
                    anxiousCalmText = "Why was i left shaking out of nervousness?? ";
                    break;
                case SatisfactionRates.Bad:
                    newRating += 1;
                    anxiousCalmText = "You have a clear lack of experience. ";
                    break;
                case SatisfactionRates.NotEnough:
                    newRating += 2;
                    anxiousCalmText = "Still feeling a little restless. ";
                    break;
                case SatisfactionRates.Perfect:
                    newRating += 3;
                    anxiousCalmText = "I can finally chill out, yayyy! ";
                    break;
                case SatisfactionRates.NegUnacceptable:
                    newRating += 0;
                    anxiousCalmText = "How come i'm relaxed as a sloth? ";
                    break;
                case SatisfactionRates.NegBad:
                    newRating += 1;
                    anxiousCalmText = "Are you sure you know what you are doing? ";
                    break;
                case SatisfactionRates.NegNotEnough:
                    newRating += 2;
                    anxiousCalmText = "World is still a bit too quiet. ";
                    break;
                case SatisfactionRates.NegPerfect:
                    newRating += 3;
                    anxiousCalmText = "It got my mind racing, great job! ";
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
                    heartbreakLoveText = "Now I can't stand them, you failed! ";
                    break;
                case SatisfactionRates.Bad:
                    newRating += 1;
                    heartbreakLoveText = "Certainly not what I expected. ";
                    break;
                case SatisfactionRates.NotEnough:
                    newRating += 2;
                    heartbreakLoveText = "They seem a bit more atractive, but not enough... ";
                    break;
                case SatisfactionRates.Perfect:
                    newRating += 3;
                    heartbreakLoveText = "I'm head over heels for them, thanks!!! ";
                    break;
                case SatisfactionRates.NegUnacceptable:
                    newRating += 0;
                    heartbreakLoveText = "I can't get them out of my head! What did you do?! ";
                    break;
                case SatisfactionRates.NegBad:
                    newRating += 1;
                    heartbreakLoveText = "Didn't do anything :/ ";
                    break;
                case SatisfactionRates.NegNotEnough:
                    newRating += 2;
                    heartbreakLoveText = "I still find them likeable, something was missing... ";
                    break;
                case SatisfactionRates.NegPerfect:
                    newRating += 3;
                    heartbreakLoveText = "I can finally stop thinking about them... ";
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
                    drowsinessEnergyText = "*yawn* this isn't what I wanted! ";
                    break;
                case SatisfactionRates.Bad:
                    newRating += 1;
                    drowsinessEnergyText = "Meh, felt like drinking water. ";
                    break;
                case SatisfactionRates.NotEnough:
                    newRating += 2;
                    drowsinessEnergyText = "A cup of coffee would've been better. ";
                    break;
                case SatisfactionRates.Perfect:
                    newRating += 3;
                    drowsinessEnergyText = "The world seems much slower now, just what I wanted! ";
                    break;
                case SatisfactionRates.NegUnacceptable:
                    newRating += 0;
                    drowsinessEnergyText = "Everything feels too loud and bright now!!! ";
                    break;
                case SatisfactionRates.NegBad:
                    newRating += 1;
                    drowsinessEnergyText = "I donLt remember ordering a potion with no effect. ";
                    break;
                case SatisfactionRates.NegNotEnough:
                    newRating += 2;
                    drowsinessEnergyText = "Drained, but still agitated. ";
                    break;
                case SatisfactionRates.NegPerfect:
                    newRating += 3;
                    drowsinessEnergyText = "Zzz... perfect. ";
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
