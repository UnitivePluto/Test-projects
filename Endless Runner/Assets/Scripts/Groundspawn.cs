using UnityEngine;

public class Groundspawn : MonoBehaviour
{
    public GameObject Tile;
    Vector3 spawn;

    public void TileSpawner (bool spawnItems)
    {
        GameObject temp = Instantiate (Tile, spawn, Quaternion.identity);
        spawn = temp.transform.GetChild (1).transform.position;
        if (spawnItems )
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCoin();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            if (i < 2)
            {
                TileSpawner(false);
            }
            else
            {
                TileSpawner(true);
            }
        }
    }

}
