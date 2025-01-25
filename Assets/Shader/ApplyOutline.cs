using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ApplyOutline : MonoBehaviour
{
    public Color outlineColor = Color.black;
    public float outlineThickness = 0.02f;

    void Start()
    {
        // Check if the object is tagged as "OL"
        if (gameObject.CompareTag("OL"))
        {
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                Material outlineMaterial = new Material(Shader.Find("Custom/OutlineShader"));
                outlineMaterial.SetColor("_OutlineColor", outlineColor);
                outlineMaterial.SetFloat("_OutlineThickness", outlineThickness);
                renderer.material = outlineMaterial;
            }
        }
    }
}
