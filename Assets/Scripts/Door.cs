using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour, Interactable
{
    private bool opened = false;

    void Interactable.OnInteract()
    {
        opened = !opened;
        StartCoroutine(AnimateDoor());
    }

    IEnumerator AnimateDoor()
    {
        float startValue = opened ? 0f : 90f;
        float endValue = opened ? 90f : 0f;
        for (float t = 0f; t < 1f; t += Time.deltaTime / 0.5f)
        {
            transform.localEulerAngles = new Vector3(0f, Mathf.Lerp(startValue, endValue, -t * t + 2 * t), 0f);
            yield return new WaitForEndOfFrame();
        }
    }
}
