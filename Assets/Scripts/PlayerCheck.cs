using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    private Ball ballCollider;

    [SerializeField] GameObject kick;
    [SerializeField] Transform balls;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            ballCollider = other.GetComponent<Ball>();
            kick.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            ballCollider = null;
            kick.SetActive(false);
        }
    }

    public void kickBall()
    {
        if (ballCollider != null)
        {
            ballCollider.ballFly();

            ballCollider.transform.SetParent(null);

            kick.SetActive(false);
        }
    }

    public void farBall()
    {
        float Farthest = 0f;
        GameObject FarthestBall = null;

        foreach (Transform b in balls)
        {
            float fartherPalyer = Vector3.Distance(b.position, transform.position);

            if (fartherPalyer > Farthest)
            {
                Farthest = fartherPalyer;
                FarthestBall = b.gameObject;
            }
        }

        if (FarthestBall != null)
        {
            Ball bcl = FarthestBall.GetComponent<Ball>();
            if (bcl != null)
            {
                bcl.ballFly();              
                FarthestBall.transform.SetParent(null);
            }
        }
    }
}