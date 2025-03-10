using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDoor : MonoBehaviour, IInteractReceiver
{
    public void OnInteraction()
    {
        gameObject.SetActive(false);
    }
}

