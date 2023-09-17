using UnityEngine;

public class OutlineableObject : MonoBehaviour, IOutlineObject
{
    [SerializeField]
    private Material[] outlineMaterial;
    [SerializeField]
    private Material originalMaterial;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;

    }

    public void SetOutlineEnabled(bool enabled)
    {
        if (enabled)
        {
            renderer.materials = outlineMaterial;
        }
        else
        {
            renderer.material = originalMaterial;
        }
    }
}
