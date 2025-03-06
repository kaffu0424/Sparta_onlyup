using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInteractionInfo", menuName = "Interaction/Interaction Info")]
public class ObjectData : ScriptableObject
{
    public string objectName;
    public string objectDescription;
}
