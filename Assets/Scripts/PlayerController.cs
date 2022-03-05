using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*[SerializeField]*/
    public float speed = 12f;
    public float gravity = -10;
    Vector3 velocity;
    CharacterController characterController;

    public Transform groundCheck;
    public LayerMask groundMask;
 
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        playerMove();
    }

    void playerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Vector3 move = Vector3.right * x + Vector3.forward * z;
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        CheckGround();
    }

    private void CheckGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(
                    groundCheck.position,
                    transform.TransformDirection(Vector3.down),
                    out hit,
                    4f,
                    groundMask
                )
            )
        {
            Debug.DrawRay(groundCheck.position, transform.TransformDirection(Vector3.down), Color.green);
            string terrainType = hit.collider.gameObject.tag;
            switch (terrainType)
            {
                default:
                    speed = 12;
                    Debug.Log("Default detected");
                    break;
                case "Low":
                    speed = 3;
                    Debug.Log("Low detected");
                    break;
                case "High":
                    speed = 20;
                    Debug.Log("High detected");
                    break;
            }
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
       
        if (hit.gameObject.tag == "PickUp")
            hit.gameObject.GetComponent<PickUp>().Picked();
    }
}
