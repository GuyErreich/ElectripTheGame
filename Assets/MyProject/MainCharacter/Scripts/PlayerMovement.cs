using UnityEngine;

namespace FirstUnityGame.Assets.MyProject.MainCharacter.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        private float playerHeight = 2f;

        [Header("Movement")]
        [SerializeField] private float moveSpeed = 6f;
        private float movementMultiplier = 10f;
        private float airMultiplier = 0.4f;

        [Header("Jumping")]
        [SerializeField] private float jumpForce = 5f;

        [Header("Keybinds")]
        private KeyCode jumpKey =  KeyCode.Space;

        [Header("Drag")]
        [SerializeField] private float groundDrag = 6f;
        [SerializeField] private float airDrag = 2f;

        private float horizontalMovement, verticalMovement;

        private bool isGrounded = true;

        private Vector3 moveDirection;

        private Rigidbody rb;

        void Start() {
            this.rb = this.GetComponent<Rigidbody>();
            this.rb.freezeRotation = true;
        }

        void Update() {
            if(!GameManager.IsGamePaused)
            {
                this.isGrounded = Physics.Raycast(this.transform.position, Vector3.down, this.playerHeight / 2 + 0.5f);

                this.MyInput();
                this.ControlDrag();

                if (Input.GetKeyDown(this.jumpKey) && this.isGrounded) {
                    this.Jump();
                }
            }
        }

        private void FixedUpdate() {
            this.MovePlayer();
        }

        private void MyInput() {
            this.horizontalMovement = Input.GetAxisRaw("Horizontal");
            this.verticalMovement = Input.GetAxisRaw("Vertical");

            this.moveDirection = this.transform.forward * this.verticalMovement + this.transform.right * this.horizontalMovement;
        }

        private void Jump() {
            this.rb.AddForce(this.transform.up * (this.jumpForce * this.rb.mass / this.airDrag), ForceMode.Impulse);
        }

        private void MovePlayer() {
            // if (this.isGrounded)
            //     this.rb.AddForce(this.moveDirection.normalized * this.moveSpeed * this.movementMultiplier, ForceMode.Acceleration);
            // else
            //     this.rb.AddForce(this.moveDirection.normalized * this.moveSpeed * this.movementMultiplier * this.airMultiplier, ForceMode.Acceleration);
            this.rb.AddForce(this.moveDirection.normalized * (this.moveSpeed * this.rb.mass * (this.rb.drag / 100f)), ForceMode.Acceleration);
        }

        private void ControlDrag() {
            if (this.isGrounded)
                this.rb.drag = this.groundDrag;
            else
                this.rb.drag = this.airDrag;
        }
    }
}