using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookSnap : MonoBehaviour
{
       public float snapDistance = 0.3f;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private Book book;

    private void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        book = GetComponent<Book>();
    }

    private void OnEnable()
    {
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnDisable()
    {
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        TrySnapToSlot();
    }

    private void TrySnapToSlot()
    {
        ShelfSlot[] allSlots = FindObjectsByType<ShelfSlot>();

        ShelfSlot closestSlot = null;

        float closestDistance = Mathf.Infinity;

        foreach (ShelfSlot slot in allSlots)
        {
            float distance =
                Vector3.Distance(transform.position, slot.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestSlot = slot;
            }
        }

        // Too far away?
        if (closestSlot == null || closestDistance > snapDistance)
            return;

        // Clear previous slot
        if (book.currentSlot != null)
        {
            book.currentSlot.ClearSlot();
        }

        // If another book is already there
        if (closestSlot.IsOccupied)
        {
            Book otherBook = closestSlot.currentBook;

            otherBook.currentSlot = null;

            otherBook.transform.SetParent(null);

            Rigidbody otherRb =
                otherBook.GetComponent<Rigidbody>();

            otherRb.isKinematic = false;
        }

        // Assign new slot
        closestSlot.AssignBook(book);
    }
}
