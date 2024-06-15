using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private float intensity;
    [SerializeField] private float frequency;
    [SerializeField] private float lowest;
    [SerializeField] private Inputs inputs;

    private void Update()
    {
        renderer.flipX = inputs.Direction < 0;

        float transparency = Mathf.Sin(Time.time * frequency) * intensity + lowest;
        Color newColor = renderer.color;
        newColor.a = transparency;
        renderer.color = newColor;
    }
}
