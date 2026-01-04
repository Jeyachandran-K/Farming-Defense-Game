using UnityEngine;

public class SoilSpawner : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject soilPrefab;

    private float heightOffset = 0.5f;
    
    private GridManager gridManager;

    private void Awake()
    {
        SpawnSoil();
    }

    private void Start()
    {
        gridManager = new GridManager(10, 10, 1);
        // SpawnSoilOnGround();    
    }
    private void SpawnSoil()
    {
        if (soilPrefab == null) return;

        GameObject spawnedSoil = Instantiate(soilPrefab);

        spawnedSoil.transform.SetParent(parent, true);
        spawnedSoil.transform.localPosition = new Vector3(0, heightOffset,0);

    }
    private void SpawnSoilOnGround()
    {
        for (int i = 0; i < gridManager.GetGrid().GetLength(0); i++)
        {
            for (int j = 0; j < gridManager.GetGrid().GetLength(1); j++)
            {
                Instantiate(soilPrefab, gridManager.GridToWorldPosition(new Vector2(i, j)), Quaternion.identity);
            }
        }
    }
}
