using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

namespace FirstUnityGame.Assets.MyProject.Abilities
{
    public class AxeInHand : State
    {
        private Rigidbody characterRb;
        private Transform hand;

        public AxeInHand(AbilitySystem abilitySystem) : base(abilitySystem)
        {
            characterRb = abilitySystem.GetComponent<Rigidbody>();
            hand = abilitySystem.Hand;
        }

        public override IEnumerator Start()
        {
            print("Axe In Hand");
            
            characterRb.collisionDetectionMode = CollisionDetectionMode.Discrete;
            characterRb.isKinematic = false;

            hand.GetComponent<VisualEffect>().enabled = false;

            Destroy(abilitySystem.TemporalAxe);    
            abilitySystem.HandAxe.SetActive(true);

            yield break;
        }

        public override IEnumerator LeftMouseClick()
        {
            Actions.ThrowWeapon (abilitySystem);

            yield return null;

            abilitySystem.SetState(new AxeThrown(abilitySystem));
        }
    }
}
