using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 tmp = transform.position;
            tmp.x = player.position.x;
            tmp.y = player.position.y;
            transform.position = tmp;
        }
    }
}
