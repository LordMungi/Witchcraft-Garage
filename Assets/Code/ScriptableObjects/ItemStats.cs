using UnityEngine;

[CreateAssetMenu(fileName = "ItemStats", menuName = "Scriptable Objects/ItemStats")]
public class ItemStats : ScriptableObject
{
    [field: SerializeField, Range(-10, 10)] public int happy { get; private set; } = 0;
    [field: SerializeField, Range(-10, 10)] public int nostalgic { get; private set; } = 0;
    [field: SerializeField, Range(-10, 10)] public int sweet { get; private set; } = 0;
}
