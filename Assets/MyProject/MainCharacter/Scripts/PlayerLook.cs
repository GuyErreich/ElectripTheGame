using UnityEngine;

namespace FirstUnityGame.Assets.MyProject.MainCharacter.Scripts
{
    public class PlayerLook : MonoBehaviour
    {
        [SerializeField] private float sensitivityX = 100f, sensitivityY = 100f;

        private Camera cam;
        private float mouseX, mouseY;
        private float multiplier = 0.01f;
        private float xRotation, yRotation;

        private void Start() {
            this.cam = GetComponentInChildren<Camera>();
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update() {
            if(!GameManager.IsGamePaused)
            {     
                this.MyInput();  

                this.cam.transform.localRotation = Quaternion.Euler(this.xRotation, 0, 0);
                this.transform.rotation = Quaternion.Euler(0, this.yRotation, 0);
            }
        }

        private void MyInput() {
            this.mouseX = Input.GetAxisRaw("Mouse X");
            this.mouseY = Input.GetAxisRaw("Mouse Y");

            this.yRotation += this.mouseX * this.sensitivityX * this.multiplier;
            this.xRotation -= this.mouseY * this.sensitivityY * this.multiplier;

            this.xRotation = Mathf.Clamp(this.xRotation, -90f, 90f);    
        }
    }
}