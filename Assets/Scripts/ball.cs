using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speedFly = 20f;
    [SerializeField] GameObject soccerGoal_1;
    [SerializeField] GameObject soccerGoal;
    [SerializeField] private ParticleSystem goallll;

    Transform target;
    private bool isGoal = false;
    private bool hasTouchedGoal = false;

    void Update()
    {
        if (isGoal && target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speedFly * Time.deltaTime);
            
        }
    }

    public void ballFly()
    {
        float go1 = Vector3.Distance(transform.position, soccerGoal_1.transform.position);
        float go = Vector3.Distance(transform.position, soccerGoal.transform.position);

        if (go1 < go) target = soccerGoal_1.transform;
        else target = soccerGoal.transform;

        isGoal = true;

        if (PointMove.Instance != null)
        {
            PointMove.Instance.currentBall = this.transform;
        }
        AudioManager.instance.playShoot();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("goal") && !hasTouchedGoal)
        {
            hasTouchedGoal = true;
            StartCoroutine(WaitBeforeDestroy());
        }
    }

    private IEnumerator WaitBeforeDestroy()
    {
        isGoal = false;

       
            goallll.Play();
         

        yield return new WaitForSeconds(2f);

        if (PointMove.Instance != null)
        {
            PointMove.Instance.currentBall = null;
        }

        Destroy(gameObject);
    }
}