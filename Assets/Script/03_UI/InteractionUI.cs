using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textGuide;
    [SerializeField] private TextMeshProUGUI subGuide;

    public void UpdateGuide(string guide)
    {
        textGuide.gameObject.SetActive(true);
        textGuide.text = guide;
    }

    public void OffGuide()
    {
        textGuide.gameObject.SetActive(false);
    }

    public void OnSubGuide(bool active, string guide = null)
    {
        subGuide.gameObject.SetActive(active);
        subGuide.text = guide;
    }
}
