using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObject : MonoBehaviour, IInteractReceiver
{
    public void OnInteraction()
    {
        gameObject.SetActive(false);
    }
}
