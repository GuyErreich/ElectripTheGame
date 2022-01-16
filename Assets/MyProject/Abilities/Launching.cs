using UnityEngine;
using System.Collections;

namespace FirstUnityGame.Assets.MyProject.Abilities
{
    public class Launching : State
    {
        private float fixedDeltaTimeDefault;
        private float timeScaleDefault;
        private bool isTimeSlowed = false;
        
        public Launching(AbilitySystem abilitySystem) : base(abilitySystem)
        {

        }

        public override IEnumerator Start()
        {
            print("Launching To Target");

            var weapon = abilitySystem.TemporalAxe;
            var weaponPosition = weapon.transform.position;
            var character = abilitySystem;

            Actions.LuanchToWeapon(abilitySystem);

            while (Vector3.Distance(weaponPosition, character.transform.position) > 2)
            {
                weaponPosition = weapon.transform.position;
                yield return null;
            }

            abilitySystem.SetState(new AxeInHand(abilitySystem));
        }

        public override IEnumerator RightMouseClick()
        {
            yield return null;

            abilitySystem.SetState(new SlowMotion(abilitySystem));
        }
    }
}