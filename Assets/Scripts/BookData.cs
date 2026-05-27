using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "BookData", menuName = "Bible/Book Data")]
public class BookData : ScriptableObject
{
    public string bookName;

    public int bookOrder;

    public Texture2D coverTexture;

    public Color bookColor = Color.white;
}
