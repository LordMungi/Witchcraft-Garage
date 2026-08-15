using UnityEngine;

[CreateAssetMenu(fileName = "Statistics", menuName = "Scriptable Objects/Statistics")]

public class Statistics : ScriptableObject
{
    public const int RANGE = 2;

    [field: SerializeField, Range(-RANGE, RANGE)] public int happySad = 0;
    [field: SerializeField, Range(-RANGE, RANGE)] public int nostalgicMature = 0;
    [field: SerializeField, Range(-RANGE, RANGE)] public int anxiousCalm = 0;
    [field: SerializeField, Range(-RANGE, RANGE)] public int loveHeartbreak = 0;
    [field: SerializeField, Range(-RANGE, RANGE)] public int energyDrowsiness = 0;
}
