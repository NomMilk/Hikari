using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerEffect : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Renderer;
    [SerializeField] private float Intensity;
    [SerializeField] private float Frequency;
    [SerializeField] private float Lowest;

    private float Transparency;

    void Start()
    {
    }
    void Update()
    {
        Transparency = Mathf.Sin(Time.time*Frequency)*Intensity+Lowest;
        Vector4 NewColor = new Vector4 (Renderer.color.r,Renderer.color.b,Renderer.color.g,Transparency);
        Renderer.color = NewColor;
    }
}
