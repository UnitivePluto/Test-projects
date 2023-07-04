using UnityEngine;

public class Kamera : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.position + offset;
        dir.x = 0;
        transform.position = dir;
    }
}
