using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public enum StatType
{
    Hp,
    Stamina
}

public class PlayerStatUI : MonoBehaviour
{
    [SerializeField] private Image[] fillList;

    public void UpdateStat(float max, float current, StatType type)
    {
        if (fillList == null)
            return;

        fillList[(int)type].fillAmount = current / max;
    }
}
