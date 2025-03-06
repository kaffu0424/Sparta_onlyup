using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoObject : MonoBehaviour, IInformable
{
    [SerializeField] private ObjectData data;

    public void Information()
    {
        if (data == null)
            return;

        UIManager.Instance.informationUI.UpdateInformation(data.objectName, data.objectDescription);
    }
}
