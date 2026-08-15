using System;
using UnityEngine;

[Serializable] public struct Statistics 
{
    public const int RANGE = 2;

    [field: SerializeField, Range(-RANGE, RANGE)] public int happySad;
    [field: SerializeField, Range(-RANGE, RANGE)] public int nostalgicMature;
    [field: SerializeField, Range(-RANGE, RANGE)] public int anxiousCalm;
    [field: SerializeField, Range(-RANGE, RANGE)] public int loveHeartbreak;
    [field: SerializeField, Range(-RANGE, RANGE)] public int energyDrowsiness;

    public static Statistics operator +(Statistics lhs, Statistics rhs)
    {
        Statistics newStats;
        newStats.happySad = lhs.happySad + rhs.happySad;
        newStats.nostalgicMature = lhs.nostalgicMature + rhs.nostalgicMature;
        newStats.anxiousCalm = lhs.anxiousCalm + rhs.anxiousCalm;
        newStats.loveHeartbreak = lhs.loveHeartbreak + rhs.loveHeartbreak;
        newStats.energyDrowsiness = lhs.energyDrowsiness + rhs.energyDrowsiness;
        return newStats;
    }
}
