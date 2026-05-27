using TMPro;
using UnityEngine;

public class BibleVisuals : MonoBehaviour
{
    public BookData data;

    [Header("Visual References")]
    public MeshRenderer coverRenderer;

    public TextMeshPro titleText;

    private void Start()
    {
        ApplyVisuals();
    }

    public void ApplyVisuals()
    {
        if (data == null)
            return;

        // Set title text
        if (titleText != null)
        {
            titleText.text = data.bookName;
        }

        // Create material instance
        Material mat = coverRenderer.material;

        // Apply texture
        mat.mainTexture = data.coverTexture;

        // Apply color
        mat.color = data.bookColor;
    }
}
