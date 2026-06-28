using UnityEngine;
namespace Project1
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpForce = 5f;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private bool isJumping = true;
        [SerializeField] private bool isMoving = true;
        [SerializeField] private float cubeDetectionRange = 2f;// Range for detecting cubes in front of the player
        [SerializeField] private GameManager gameManager;
        private Rigidbody rb;
        private bool isGrounded;
        private Vector3 StartPostion;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            StartPostion = transform.position;
        }

        private void Update()
        {
            if (!gameManager.itsOnceDetect)
            {
                Move();
                Jump();
                CubeDedect();
            }
        }
        //Player Movement Controls
        private void Move()
        {
            if (isMoving)
            {
                float moveX = Input.GetAxis("Horizontal");
                float moveZ = Input.GetAxis("Vertical");

                Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;
                transform.Translate(move, Space.World);
            }
        }

        private void Jump()
        {
            if (isJumping)
            {
                isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);

                if (isGrounded && Input.GetButtonDown("Jump"))
                {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                }
            }
        }
        //Cube Detection Logic
        private void CubeDedect()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, cubeDetectionRange))
            {
                CubeController cubeController = hit.collider.GetComponent<CubeController>();
                if (cubeController != null)
                {
                    gameManager.itsOnceDetect = true;
                    cubeController.HighlightCube();
                    cubeController = null;
                }
            }
        }

        public void ResetPositon()
        {
            transform.position = StartPostion;
        }
    }
}
