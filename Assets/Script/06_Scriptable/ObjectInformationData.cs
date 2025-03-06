using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "objectInformationData", menuName = "Interaction/object Information Data")]
public class ObjectInformationData : ScriptableObject
{
    public string objectName;
    public string objectDescription;
}
