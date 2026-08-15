using System;
using UnityEngine;

[Serializable] public struct Statistics 
{
    public const int RANGE = 2;

    [field: SerializeField, Range(-RANGE, RANGE)] public int sadHappy;
    [field: SerializeField, Range(-RANGE, RANGE)] public int nostalgicMature;
    [field: SerializeField, Range(-RANGE, RANGE)] public int anxiousCalm;
    [field: SerializeField, Range(-RANGE, RANGE)] public int heartbreakLove;
    [field: SerializeField, Range(-RANGE, RANGE)] public int drowsinessEnergy;

    public static Statistics operator +(Statistics lhs, Statistics rhs)
    {
        Statistics newStats;
        newStats.sadHappy = lhs.sadHappy + rhs.sadHappy;
        newStats.nostalgicMature = lhs.nostalgicMature + rhs.nostalgicMature;
        newStats.anxiousCalm = lhs.anxiousCalm + rhs.anxiousCalm;
        newStats.heartbreakLove = lhs.heartbreakLove + rhs.heartbreakLove;
        newStats.drowsinessEnergy = lhs.drowsinessEnergy + rhs.drowsinessEnergy;
        return newStats;
    }
}
