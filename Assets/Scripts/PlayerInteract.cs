using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Image image;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<Item>() is Item item)
        {
            image.gameObject.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        image.gameObject.SetActive(false);
    }
}
