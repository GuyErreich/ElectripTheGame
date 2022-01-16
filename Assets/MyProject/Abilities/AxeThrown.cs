using UnityEngine;
using System.Collections;
using FirstUnityGame.Assets.MyProject.Scripts;

namespace FirstUnityGame.Assets.MyProject.Abilities
{
    public class AxeThrown : State
    {
        private TimeManager timeManager;

        public AxeThrown(AbilitySystem abilitySystem) : base(abilitySystem)
        {
            this.timeManager = abilitySystem.TimeManager;
        }

        public override IEnumerator Start()
        {
            print("Axe not in hand");

            var weapon = abilitySystem.TemporalAxe;
            var weaponScript = weapon.GetComponent<WeaponScript>();
            
            if (timeManager.IsTimeSlowed)
                timeManager.ReturnNormalTimeSpeed();

            while(!weaponScript.IsHit)
                yield return null;

            abilitySystem.SetState(new TargetHit(abilitySystem));
        }

        public override IEnumerator LeftMouseClick()
        {
            print("Pull");

            yield return Actions.PullWeapon(abilitySystem);

            abilitySystem.SetState(new AxeInHand(abilitySystem));
        }
    }
}
