using UnityEngine;

public class Book : MonoBehaviour
{
    public BookData data;
    public GameObject displayPrefab;

    [HideInInspector]
    public ShelfSlot currentSlot;

    public int BookOrder => data.bookOrder;
}
