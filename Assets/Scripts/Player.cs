using NUnit.Framework.Internal.Filters;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float limitHorizontal = 12f;
    [SerializeField] private float limitVertical = 8.5f;
    [SerializeField] private float rotationSpeed = 5f;    
    
    Vector3 MovePlayer;
    private Animator anim;
    private readonly int runAnim = Animator.StringToHash("run");


    private Rigidbody rb;

    private void Awake()
    {

        
        if(anim == null)
        {
            anim = GetComponentInChildren<Animator>();
        }
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        Movement();
    }

    private void FixedUpdate()
    {

        rb.linearVelocity = new Vector3(MovePlayer.x*speed,rb.linearVelocity.y, MovePlayer.z*speed);

        float clampedX = Mathf.Clamp(rb.position.x,-limitHorizontal,limitHorizontal);
        float clampedZ = Mathf.Clamp(rb.position.z,-limitVertical, limitVertical);

        rb.position = new Vector3(clampedX,rb.position.y,clampedZ);

        if(MovePlayer.sqrMagnitude >0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(MovePlayer, Vector3.up);

            rb.MoveRotation(Quaternion.Slerp(rb.rotation,targetRotation,rotationSpeed*Time.fixedDeltaTime ));
        }
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");         
        MovePlayer = (Vector3.right * horizontal + Vector3.forward * vertical).normalized;
        anim.SetFloat(runAnim, MovePlayer.magnitude);
    }

    



}
