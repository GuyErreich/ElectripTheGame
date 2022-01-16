using UnityEngine;
using System.Collections;
using UnityEngine.VFX;


namespace FirstUnityGame.Assets.MyProject.Abilities
{
    public class TargetHit : State
    {
        private WeaponScript weaponScript;
        private GameObject weapon;
        private Transform hand; 
        
        public TargetHit(AbilitySystem abilitySystem) : base(abilitySystem)
        {
            this.weaponScript = abilitySystem.TemporalAxe.GetComponent<WeaponScript>();
            this.weapon = abilitySystem.TemporalAxe;
            this.hand = abilitySystem.Hand;
        }

        public override IEnumerator Start()
        {
            print("Hit");

            this.weapon.GetComponent<ParticleSystem>().Stop();

            if(this.weaponScript.TargetHit == "Target")
            {
                this.hand.GetComponent<VisualEffect>().SetVector3("Target", this.weapon.transform.position);
                this.hand.GetComponent<VisualEffect>().enabled = true;
            }

            yield break;
        }

        public override IEnumerator LeftMouseClick()
        {
            print("Pull");

            yield return Actions.PullWeapon(abilitySystem);

            abilitySystem.SetState(new AxeInHand(abilitySystem));
        }

        public override IEnumerator RightMouseClick()
        {
            print("Luanch");
            
            yield return null;

            if(this.weaponScript.TargetHit == "Target")
            {            
                abilitySystem.SetState(new Launching(abilitySystem));
            }
        }
    }
}