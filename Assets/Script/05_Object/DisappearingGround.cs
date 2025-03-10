using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingGround : MonoBehaviour, IInteractReceiver
{
    [SerializeField] private float fadeDuration;
    [SerializeField] private float respawnDuration;
    private Collider collider;
    private Renderer renderer;
    private Color defaultColor;
    private bool isFading;
    private void Start()
    {
        collider = GetComponent<Collider>();
        renderer = GetComponent<Renderer>();

        if(renderer != null)
            defaultColor = renderer.material.color;
        isFading = false;
    }

    public void OnInteraction()
    {
        if(!isFading)
            StartCoroutine(Disappearing());
    }

    IEnumerator Disappearing()
    {
        isFading = true;
        float time = 0f;
        Material material = renderer.material;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(defaultColor.a, 0f, time / fadeDuration);
            material.color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, alpha);
            yield return null;
        }

        collider.enabled = false;

        yield return new WaitForSeconds(respawnDuration);

        material.color = defaultColor;
        collider.enabled = true;
        isFading = false;
    }
}
