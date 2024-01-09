using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public Renderer myRenderer;
    public float fadeDuration = 2.0f;
    public Color fadeColor = Color.black;

    public bool fadeOnStart = true;

    private void Start()
    {
        if (fadeOnStart)
            FadeIn();
    }

    public void FadeIn()
    {
        Fade(1.0f, 0.0f);
    }

    public void FadeOut()
    {
        Fade(0.0f, 1.0f);
    }

    public void FadeOutFadeIn()
    {
        StartCoroutine(FadeOutFadeInRoutine(0.0f, 1.0f));
    }
    
    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;

        while(timer < fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer/fadeDuration);

            myRenderer.material.SetColor("_Color", newColor);

            timer += Time.deltaTime;
            yield return null;
        }


    }
    
    public IEnumerator FadeOutFadeInRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;

        while(timer < fadeDuration)
        {

            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, Mathf.Sin(2.0f * Mathf.PI * timer/fadeDuration));

            myRenderer.material.SetColor("_Color", newColor);

            timer += Time.deltaTime;
            yield return null;
        }


    }
}
