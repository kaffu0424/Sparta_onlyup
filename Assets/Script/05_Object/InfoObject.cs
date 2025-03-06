using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoObject : MonoBehaviour, IInformable
{
    [SerializeField] private ObjectInformationData infoData;

    public void Information()
    {
        if (infoData == null)
            return;

        UIManager.Instance.informationUI.UpdateInformation(infoData.objectName, infoData.objectDescription);
    }
}
