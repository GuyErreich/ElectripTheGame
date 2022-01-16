using UnityEngine;
using System.Collections;

namespace FirstUnityGame.Assets.MyProject.Abilities
{
    public abstract class State : MonoBehaviour
    {
        protected AbilitySystem abilitySystem;

        public State(AbilitySystem abilitySystem)
        {
            this.abilitySystem = abilitySystem;
        }

        public virtual IEnumerator Start()
        {
            yield break;
        }

        public virtual IEnumerator LeftMouseClick()
        {
            yield break;
        }
        
        public virtual IEnumerator RightMouseClick()
        {
            yield break;
        }
    }
}