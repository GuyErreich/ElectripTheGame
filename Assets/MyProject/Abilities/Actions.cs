using UnityEngine;
using UnityEngine.VFX;
using System.Collections;

namespace FirstUnityGame.Assets.MyProject.Abilities
{
    public class Actions : MonoBehaviour
    {        
        public static void ThrowWeapon(AbilitySystem abilitySystem)
        {
            abilitySystem.HandAxe.SetActive(false);

            var weapon = abilitySystem.TemporalAxe = Instantiate(abilitySystem.ThrownAxe, abilitySystem.Hand.position, abilitySystem.Hand.rotation);
            var weaponRb = weapon.GetComponent<Rigidbody>();
            var weaponScript = weapon.GetComponent<WeaponScript>();

            weaponRb.isKinematic = false;
            weaponRb.useGravity = abilitySystem.UseGravity;
            weaponRb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            weapon.transform.eulerAngles = new Vector3(180, abilitySystem.transform.eulerAngles.y, 55);
            weapon.GetComponent<ParticleSystem>().Play();

            RaycastHit hitPoint;
            Vector3 direction;

            // Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitPoint);
            bool isHit = Physics.SphereCast(Camera.main.transform.position, 0.5f, Camera.main.transform.forward, out hitPoint, LayerMask.GetMask("Player"));
            
            if (isHit)
                direction = (hitPoint.point - weapon.transform.position).normalized;
            else
                direction = Camera.main.transform.forward;

            weaponRb.AddForce(direction * abilitySystem.ThrowPower * 100f * Time.unscaledDeltaTime, ForceMode.VelocityChange);
        }

        public static IEnumerator PullWeapon(AbilitySystem abilitySystem)
        {
            var axeReturnTime = 0f;
            var weapon = abilitySystem.TemporalAxe;
            var weaponRb = weapon.GetComponent<Rigidbody>();
            var weaponScript = weapon.GetComponent<WeaponScript>();
            var weaponPosition = weapon.transform.position;
            var curvePoint = abilitySystem.CurvePoint;
            var hand = abilitySystem.Hand;

            weaponRb.Sleep();
            weaponRb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            weaponRb.isKinematic = true;
            weaponScript.Start();
            weapon.GetComponent<ParticleSystem>().Play();
            hand.GetComponent<VisualEffect>().enabled = false;

            while(axeReturnTime < 1)
            {
                weapon.transform.position = GetQuadraticCurvePoint(axeReturnTime, weaponPosition, curvePoint.position, hand.position);
                axeReturnTime += Time.unscaledDeltaTime * 1.5f;

                yield return null;
            }
        }

        public static void LuanchToWeapon(AbilitySystem abilitySystem)
        {
            var weapon = abilitySystem.TemporalAxe;
            var weaponPosition = weapon.transform.position;
            var character = abilitySystem;
            var characterRb = abilitySystem.GetComponent<Rigidbody>();
            var launchPower = abilitySystem.LaunchPower;

            characterRb.Sleep();
            characterRb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            // characterRb.isKinematic = true;
            // TODO: Ask the teacher about how to add force to the default fps controller
            Vector3 direction = (weaponPosition - character.transform.position) * 1.15f;
            direction.y = direction.y * 1.25f;
            characterRb.AddForce(direction * launchPower * 100f * Time.unscaledDeltaTime, ForceMode.Impulse);
        }

        private static Vector3 GetQuadraticCurvePoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
        {
            float u = 1 - t;
            float tt = t * t;
            float uu = u * u;
            return (uu * p0) + (2 * u * t * p1) + (tt * p2);
        }
    }
}
