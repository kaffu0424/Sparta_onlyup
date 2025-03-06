using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] private Image staminaFill;

    public void SetHPbar(float maxStamina, float currentStamina)
    {
        staminaFill.fillAmount = currentStamina / maxStamina;
    }
}
