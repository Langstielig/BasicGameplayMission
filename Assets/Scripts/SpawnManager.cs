using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefabs;

    private float spawnPosX = 19f;
    private float spawnRangeX = 15f;

    private float spawnPosZ = 20f;
    private float spawnRangeZ = 16f;

    private float startTime = 2f;
    private float spawnInterval = 1.5f;

    private void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startTime, spawnInterval);
    }

    private void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        int isVertical = Random.Range(0, 2);
        Vector3 animalPos;
        Quaternion rotation;
        //Animals move vertical
        if (isVertical == 0)
        {
            animalPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            rotation = animalPrefabs[animalIndex].transform.rotation;
        }
        //Animals move horizontal
        else
        {
            int direction = Random.Range(0, 2);
            //animals move to the right
            if (direction == 0)
            {
                animalPos = new Vector3(-spawnPosX, 0, Random.Range(-spawnRangeZ, spawnRangeZ));
                rotation = Quaternion.Euler(0, 90f, 0);
            }
            //animals move to the left
            else
            {
                animalPos = new Vector3(spawnPosX, 0, Random.Range(-spawnRangeZ, spawnRangeZ));
                rotation = Quaternion.Euler(0, -90f, 0);
            }
            //rotation
        }

        //Instantiate
        Instantiate(animalPrefabs[animalIndex], animalPos, rotation);
    }
}
