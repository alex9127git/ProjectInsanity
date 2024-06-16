public interface Interactable
{
    protected abstract void OnInteract();

    public void InvokeInteract()
    {
        OnInteract();
    }
}
