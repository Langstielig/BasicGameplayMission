using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 10.0f;
    private float xRange = 15.0f;
    private float lowerZRange = 0f;
    private float upperZRange = 14f;

    private int lives = 3;

    [SerializeField] private GameObject projectilePrefab;

    void Update()
    {
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.z < lowerZRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, lowerZRange);
        }
        if(transform.position.z > upperZRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, upperZRange);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate((Vector3.right * horizontalInput + Vector3.forward * verticalInput) * Time.deltaTime * speed);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dog")
        {
            lives -= 1;
            if (lives > 0)
            {
                Debug.Log("Current lives is: " + lives);
            }
            else
            {
                Debug.Log("Game over");
            }
        }
    }
}
