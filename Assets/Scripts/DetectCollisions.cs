using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dog")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

            score += 1;
            Debug.Log("Current score is: " + score);
        }
    }
}
