using UnityEngine;
using System.Collections;
using FirstUnityGame.Assets.MyProject.Scripts;

namespace FirstUnityGame.Assets.MyProject.Abilities
{
    public class SlowMotion : State 
    {
        private TimeManager timeManager;

        public SlowMotion(AbilitySystem abilitySystem) : base(abilitySystem) {
            this.timeManager = abilitySystem.TimeManager;
        }

        public override IEnumerator Start()
        {
            print("SlowMotion");

            this.timeManager.DoSlowMotion();

            yield return Actions.PullWeapon(abilitySystem);

            abilitySystem.SetState(new AxeInHand(abilitySystem));
        }
    }
}