using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform[] spawnPoints;
    public Vector3 positionOffset = Vector3.zero;
    public Vector3 rotationOffset = Vector3.zero;
    public Vector3 scaleOffset = Vector3.one;
    private bool initialSpawn = true;

    void Start()
    {

    }

    public void Draw(bool isFirstDraw)
    {
        Debug.Log("Inside Draw");
        if (GameManager.Instance.CurrentState == GameManager.GameState.Draw)
        {
            if (initialSpawn)
            {
                SpawnPrefabs(isFirstDraw ? 6 : 5);
                initialSpawn = false;
            }
            else
            {
                SpawnPrefabs(1);
            }
        }
    }

    void SpawnPrefabs(int numToSpawn)
    {
        // Loop through each spawn point
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            // Check if there is no object attached to the spawn point
            if (spawnPoints[i].childCount == 0)
            {
                // Instantiate a random prefab at the spawn point
                GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
                GameObject instance = Instantiate(prefab, spawnPoints[i].position, Quaternion.identity, spawnPoints[i]);
                Debug.Log("Instantiated " + prefab.name + " at " + spawnPoints[i].name);

                // Apply position, rotation, and scale offsets
                instance.transform.localPosition += positionOffset;
                instance.transform.localRotation *= Quaternion.Euler(rotationOffset);
                instance.transform.localScale = Vector3.Scale(instance.transform.localScale, scaleOffset);

                // Decrease numToSpawn if it's greater than 1
                if (numToSpawn > 1)
                {
                    numToSpawn--;
                }
                else
                {
                    break;
                }
            }
        }
    }
}