using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public void execute()
    {
        // Call Destroy on itself after 3 seconds
        Destroy(gameObject);
    }
}