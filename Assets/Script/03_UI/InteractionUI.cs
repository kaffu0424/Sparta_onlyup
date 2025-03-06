using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextGuide;

    public void UpdateGuide(string guide)
    {
        TextGuide.gameObject.SetActive(true);

        if (TextGuide == null)
        {
            TextGuide.gameObject.SetActive(false);
            return;
        }

        TextGuide.text = guide;
    }

    public void OffGuide()
    {
        TextGuide.gameObject.SetActive(false);
    }
}
