using UnityEngine;

public class ShelfSlot : MonoBehaviour
{

    public int slotIndex;

    [HideInInspector]
    public Book currentBook;

    public bool IsOccupied => currentBook != null;

    public void AssignBook(Book book)
    {
        currentBook = book;

        book.currentSlot = this;

        bool correct =
            book.BookOrder == slotIndex;

        if (correct)
        {
            PlaceCorrectBook(book);
        }
        else
        {
            SnapInteractableBook(book);
        }
    }

    private void SnapInteractableBook(Book book)
    {
        book.transform.position = transform.position;
        book.transform.rotation = transform.rotation;

        book.transform.SetParent(transform);

        Rigidbody rb = book.GetComponent<Rigidbody>();

        rb.isKinematic = true;
    }

    private void PlaceCorrectBook(Book book)
    {
        if (book.displayPrefab != null)
        {
            Instantiate(
            book.displayPrefab,
            transform.position,
            transform.rotation,
            transform
            );
        }
        else
        {
            Debug.LogWarning($"{book.name} has no display prefab assigned.");
        }

        Destroy(book.gameObject);

        Debug.Log("Correct placement!");
    }

    public void ClearSlot()
    {
        currentBook = null;
    }
}
