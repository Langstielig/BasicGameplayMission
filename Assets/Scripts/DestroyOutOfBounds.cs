using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topZBound = 20f;
    private float lowerZBound = -5f;

    private float xBound = 20f;

    void Update()
    {
        if(transform.position.z > topZBound || transform.position.z < lowerZBound)
        {
            Destroy(gameObject);
        }
        else if(transform.position.x < -xBound || transform.position.x > xBound)
        {
            Destroy(gameObject);
        }
    }
}
