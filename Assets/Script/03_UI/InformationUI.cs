using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InformationUI : MonoBehaviour
{
    [SerializeField] private GameObject textParentObject;
    [SerializeField] private TextMeshProUGUI TextObjectName;
    [SerializeField] private TextMeshProUGUI TextObjectDescription;
    public void UpdateInformation(string name, string description)
    {
        textParentObject.SetActive(true);

        if (TextObjectName == null || TextObjectDescription == null)
        {
            textParentObject.SetActive(false);
            return;
        }

        TextObjectName.text = name;
        TextObjectDescription.text = description;
    }

    public void OffInformation()
    {
        textParentObject.SetActive(false);
    }
}
