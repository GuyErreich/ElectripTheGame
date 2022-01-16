using UnityEngine;

namespace FirstUnityGame.Assets.MyProject.Scripts
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] private float slowMotionFactore = 0.05f, slowMotionDuration = 2f;

        private float fixedDeltaTimeDefault;
        private float timeScaleDefault;
        private bool isTimeSlowed = false;

        void Start()
        {
            this.fixedDeltaTimeDefault = Time.fixedDeltaTime;
            this.timeScaleDefault = Time.timeScale;
        }

        void Update()
        {
            if(!GameManager.IsGamePaused)
            {
                Time.timeScale += (1f / slowMotionDuration) * Time.unscaledDeltaTime;
                Time.timeScale = Mathf.Clamp(Time.timeScale, 0, 1);
                Time.fixedDeltaTime = this.fixedDeltaTimeDefault * Time.timeScale;
            }
        }

        public void DoSlowMotion()
        {
            Time.timeScale = slowMotionFactore;
            Time.fixedDeltaTime = this.fixedDeltaTimeDefault * Time.timeScale;
            this.isTimeSlowed = true;
        }

        public void ReturnNormalTimeSpeed()
        {
            Time.timeScale = this.timeScaleDefault;
            Time.fixedDeltaTime = this.fixedDeltaTimeDefault;
            this.isTimeSlowed = false;
        }

        public bool IsTimeSlowed { get => this.isTimeSlowed; }
    }
}
