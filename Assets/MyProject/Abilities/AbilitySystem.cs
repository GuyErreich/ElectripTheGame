using UnityEngine;
using FirstUnityGame.Assets.MyProject.Scripts;


namespace FirstUnityGame.Assets.MyProject.Abilities
{
    public class AbilitySystem : StateMachine
    {    
        private GameObject temporalAxe;

        [Header("Public References")]
        [SerializeField] private GameObject thrownAxe, handAxe;
        [SerializeField] private Transform hand, curvePoint;
        [SerializeField] private TimeManager timeManager;
        // [SerializeField] private RigidbodyFirstPersonController character;
        [Space]
        [Header("Parameters")]
        [SerializeField] private bool useGravity = false;
        [SerializeField] private float throwPower = 30, launchPower = 0.20f;

        #region Getters/Setter

        public GameObject ThrownAxe  
        {
            get => this.thrownAxe;
        }

        public GameObject HandAxe  
        {
            get => this.handAxe; 
        }

        public GameObject TemporalAxe
        {
            get => this.temporalAxe;
            set => this.temporalAxe = value;
        }

        public Transform Hand  
        {
            get => this.hand;
        }

        public Transform CurvePoint  
        {
            get => this.curvePoint;
        }

        public TimeManager TimeManager  
        {
            get => this.timeManager;
        }

        public bool UseGravity  
        {
            get => this.useGravity;
        }

        public float ThrowPower  
        {
            get => this.throwPower;
        }

        public float LaunchPower  
        {
            get => this.launchPower;
        }
        #endregion

        private void Start()
        {
            print("start");
            this.SetState(new AxeInHand(this));
        }

        private void Update() 
        {
            if (Input.GetMouseButtonDown(0))
                DoLeftClick();
            if (Input.GetMouseButtonDown(1))
                DoRightClick();
        }

        private void DoLeftClick()
        {
            if(!GameManager.IsGamePaused)
            {
                StartCoroutine(state.LeftMouseClick());
            }
        }

        private void DoRightClick()
        {
            if(!GameManager.IsGamePaused)
            {
                StartCoroutine(state.RightMouseClick());
            }
        }
    }
}