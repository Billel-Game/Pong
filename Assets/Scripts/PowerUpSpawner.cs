using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public int rows = 5;
    public int columns = 5;
    public float spawnInterval = 5f;
    public float gridWidth = 10f;
    public float gridHeight = 10f;

    public Vector3 gridCenter = Vector3.zero;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPowerUp), 0f, spawnInterval);
    }

    void SpawnPowerUp()
    {
        int randomRow = Random.Range(0, rows);
        int randomColumn = Random.Range(0, columns);

        float xPosition = (randomColumn - (columns / 2)) * (gridWidth / columns);
        float yPosition = (randomRow - (rows / 2)) * (gridHeight / rows);
        Vector3 spawnPosition = new Vector3(xPosition, yPosition, 0f) + gridCenter;

        Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        for (int i = 0; i <= rows; i++)
        {
            float yPosition = (i - (rows / 2)) * (gridHeight / rows) + gridCenter.y;
            Gizmos.DrawLine(new Vector3(-gridWidth / 2 + gridCenter.x, yPosition, 0),
                            new Vector3(gridWidth / 2 + gridCenter.x, yPosition, 0));
        }

        for (int i = 0; i <= columns; i++)
        {
            float xPosition = (i - (columns / 2)) * (gridWidth / columns) + gridCenter.x;
            Gizmos.DrawLine(new Vector3(xPosition, -gridHeight / 2 + gridCenter.y, 0),
                            new Vector3(xPosition, gridHeight / 2 + gridCenter.y, 0));
        }
    }
}
