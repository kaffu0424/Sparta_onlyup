using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherPlatform : MonoBehaviour
{
    [SerializeField] private InteractionGuideData guideData;

    [SerializeField] private Vector3 launcherDirection;
    [SerializeField] private float launcherPower;

    [SerializeField] private bool launchable;
    private PlayerMovement playerMovement;
    private InteractionUI interactionUI;

    private void Start()
    {
        // Ä³½Ì
        playerMovement = PlayerManager.Instance.playerMovement;
        interactionUI = UIManager.Instance.interactionUI;

        launchable = false;
    }

    private void Update()
    {
        if (!launchable)
            return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            playerMovement.onLauncher = true;

            playerMovement.rigidBody.AddForce(launcherDirection * launcherPower, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        launchable = true;
        interactionUI.OnSubGuide(launchable, guideData.objectGuide);
    }

    private void OnCollisionExit(Collision collision)
    {
        launchable = false;
        interactionUI.OnSubGuide(launchable);
    }
}
