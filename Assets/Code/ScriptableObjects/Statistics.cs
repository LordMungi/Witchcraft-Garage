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
}
