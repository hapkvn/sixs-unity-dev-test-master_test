using UnityEngine;

public class PointMove : MonoBehaviour
{
    public static PointMove Instance;

    [SerializeField] private Transform player;
    public Transform currentBall;
    public float smoothSpeed = 5f;

    private float fixedHeight; 

    private void Awake()
    {
        Instance = this;
        fixedHeight = transform.position.y;
    }

    void Update()
    {
        Vector3 targetPosition;

        if (currentBall != null)
        {
            float midX = (player.position.x + currentBall.position.x) / 2f;
            float midZ = (player.position.z + currentBall.position.z) / 2f;

            targetPosition = new Vector3(midX, fixedHeight, midZ);
        }
        else
        {
            targetPosition = new Vector3(player.position.x, fixedHeight, player.position.z);
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}