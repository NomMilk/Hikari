using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerEffect : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Renderer;
    [SerializeField] private float Intensity;
    [SerializeField] private float Frequency;
    [SerializeField] private float Lowest;

    [SerializeField] private Inputs Inputs;

    private float Transparency;
    void Update()
    {
        if (Inputs.Direction > 0)
        {
            Renderer.flipX = false;
        }

        else if (Inputs.Direction < 0)
        {
            Renderer.flipX = true;
        }
        Transparency = Mathf.Sin(Time.time*Frequency)*Intensity+Lowest;
        Vector4 NewColor = new Vector4 (Renderer.color.r,Renderer.color.b,Renderer.color.g,Transparency);
        Renderer.color = NewColor;
    }
}
