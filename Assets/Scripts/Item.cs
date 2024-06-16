using UnityEngine;

public class Item : MonoBehaviour, Interactable
{
    void Interactable.OnInteract()
    {
        gameObject.SetActive(false);
    }
}
