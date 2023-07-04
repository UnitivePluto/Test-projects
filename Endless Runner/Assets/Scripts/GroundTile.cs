using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    Groundspawn groundSpawn;
    [SerializeField] GameObject tall;
    [SerializeField] float tallChance = .2f;
    [SerializeField] GameObject lShape;
    [SerializeField] float lShapeChance=.5f;
    [SerializeField] GameObject jShape;
    [SerializeField] float jShapeChance = .7f;
    // Start is called before the first frame update
    private void Start()
    {
        groundSpawn = GameObject.FindObjectOfType<Groundspawn>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawn.TileSpawner(true);
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject ObstaclePrefab;

    public void SpawnObstacle()
    {
        GameObject obstacleToSpawn = ObstaclePrefab;
        float random = Random.Range(0f, 1f);
        if(random <=tallChance && random <lShapeChance)
        {
            
            obstacleToSpawn = tall;

        }
        else if(random >tallChance && random <=lShapeChance)
        {
            
            obstacleToSpawn = lShape;
        }
        else if(random >lShapeChance && random <=jShapeChance)
        {
            obstacleToSpawn=jShape;
        }
        int index = Random.Range(2,5);
        Transform spawnPoint=transform.GetChild(index).transform;

        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }
    public GameObject coinPrefab;

    public void SpawnCoin()
    {
        int spawnNumber = 5;
        for (int i = 0; i < spawnNumber; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = randomPointToSpawn(GetComponent<Collider>());
        }
    }

    Vector3 randomPointToSpawn(Collider collider)
    {
        Vector3 point = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        if (point != collider.ClosestPoint(point))
        {
            point = randomPointToSpawn(collider);
        }

        point.y = 1;
        return point;
    }
}
