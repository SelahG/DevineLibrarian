using UnityEngine;

public class ShelfManager : MonoBehaviour
{
       public ShelfSlot[] slots;

    public void CheckOrder()
    {
        bool correct = true;

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].currentBook == null)
            {
                correct = false;
                break;
            }

            if (slots[i].currentBook.BookOrder != i)
            {
                correct = false;
                break;
            }
        }

        if (correct)
        {
            Debug.Log("Books are in correct order!");
        }
        else
        {
            Debug.Log("Books are NOT in correct order.");
        }
    }
}
