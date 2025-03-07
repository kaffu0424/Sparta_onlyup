using UnityEngine;

[CreateAssetMenu(fileName = "BuffData", menuName = "Interaction/Buff Data")]
public class BuffData : ScriptableObject
{
    public float value;
    public float duration;
    public BuffType type;
}
