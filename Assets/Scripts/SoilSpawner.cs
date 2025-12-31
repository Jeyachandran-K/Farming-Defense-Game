using UnityEngine;

public class SoilSpawner : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject soilPrefab;

    private float heightOffset = 0.5f;

    private void Start()
    {
        SpawnSoil();
    }
    private void SpawnSoil()
    {
        if (soilPrefab == null) return;

        GameObject spawnedSoil = Instantiate(soilPrefab);

        spawnedSoil.transform.SetParent(parent, true);
        spawnedSoil.transform.localPosition = new Vector3(0, heightOffset,0);

    }
}
