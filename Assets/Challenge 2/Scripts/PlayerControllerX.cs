using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    float delay = 20.0f;
    float amountOfDelay = 20.0f;

    bool isSpacebarBlocked = false;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && delay == amountOfDelay)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            isSpacebarBlocked = true;
        }

        //Block the spacebar and wait for 3 seconds
        if(isSpacebarBlocked && delay > 0f)
        {
            Debug.Log("Block the spacebar");
            delay -= 1.0f;
        }
        else if(delay <= 0f)
        {
            delay = amountOfDelay;
            isSpacebarBlocked = false;
        }
    }
}
