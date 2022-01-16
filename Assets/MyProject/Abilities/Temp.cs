
// using UnityEngine;
// using UnityEngine.VFX;
// using UnityStandardAssets.Characters.FirstPerson;
// // using DG.Tweening;
// // using System.Collections;
// // using System.Collections.Generic;

// public class AxeThrow : MonoBehaviour
// {
//     private Rigidbody weaponRb;
//     private GameObject weapon;
//     private WeaponScript weaponScript;
//     private Vector3 weaponPosition;
//     private float axeReturnTime;

//     // Triggers
//     private bool polling = false, launching = false, hasWeapon = true;
   
//     [Header("Public References")]
//     [SerializeField] private GameObject thrownAxe, handAxe;
//     [SerializeField] private Transform hand, curvePoint;
//     [SerializeField] private TimeManager timeManager;
//     [SerializeField] private RigidbodyFirstPersonController character;
//     [Space]
//     [Header("Parameters")]
//     [SerializeField] private bool useGravity = false;
//     [SerializeField] private float throwPower = 30;
    
//     [SerializeField]
//     [Range(0.01f, 1f)]
//     private float launchPower = 0.20f;

//     void Start()
//     {
//         this.hand.GetComponent<VisualEffect>().enabled = false;
//     }

//     private void Throw()
//     {
//         handAxe.SetActive(false);

//         weapon = Instantiate(thrownAxe, hand.position, hand.rotation);
//         weaponRb = weapon.GetComponent<Rigidbody>();
//         weaponScript = weapon.GetComponent<WeaponScript>();

//         hasWeapon = false;
//         // weaponScript.activated = true;
//         weaponRb.isKinematic = false;
//         weaponRb.useGravity = useGravity;
//         weaponRb.collisionDetectionMode = CollisionDetectionMode.Continuous;
//         weapon.transform.eulerAngles = new Vector3(180, this.transform.eulerAngles.y, 55);
//         weapon.GetComponent<ParticleSystem>().Play();

//         RaycastHit hitPoint;
//         Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitPoint);
//         Vector3 direction = (hitPoint.point - weapon.transform.position).normalized;

//         weaponRb.AddForce(direction * throwPower / Time.timeScale, ForceMode.Impulse);
//     }

//     // void Update()
//     // {
//     //     if (hasWeapon)
//     //     {
//     //         if (Input.GetMouseButtonDown(0))
//     //             WeaponThrow();
//     //     }
//     //     else
//     //     {
//     //         if (Input.GetMouseButtonDown(0))
//     //             WeaponStartPull();
                
//     //         if (Input.GetMouseButtonDown(1) && weaponScript.isHit)
//     //         {
//     //             this.timeManager.ReturnNormalTimeSpeed();

//     //             StartLunchToWeapon();
//     //         }
//     //     }        
            
//     //     if (!this.character.Grounded)
//     //     {
//     //         if (Input.GetMouseButtonDown(1))
//     //             this.timeManager.DoSlowMotion();
            
//     //         if (Input.GetMouseButtonUp(1))
//     //             this.timeManager.ReturnNormalTimeSpeed();
//     //     }
//     //     else
//     //          this.timeManager.ReturnNormalTimeSpeed();

//     //     if (polling)
//     //         DoPoll();

//     //     if (launching)
//     //         DoLaunch();

//     //     if(weaponScript != null && weaponScript.isHit)
//     //     {
//     //         weapon.GetComponent<ParticleSystem>().Stop();
//     //         hand.GetComponent<VisualEffect>().SetVector3("Target", weapon.transform.position);
//     //         hand.GetComponent<VisualEffect>().enabled = true;
//     //     }
//     //     else
//     //         hand.GetComponent<VisualEffect>().enabled = false;
//     // }

//     // private void WeaponStartPull()
//     // {
//     //     weaponPosition = weapon.transform.position;
//     //     weaponRb.Sleep();
//     //     weaponRb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
//     //     weaponRb.isKinematic = true;
//     //     weapon.GetComponent<ParticleSystem>().Play();
//     //     weaponScript.activated = true;
//     //     weaponScript.isHit = false;
//     //     polling = true;
//     // }

//     // private void DoPoll()
//     // {
//     //     if (this.axeReturnTime < 1)
//     //     {
//     //         weapon.transform.position = GetQuadraticCurvePoint(this.axeReturnTime, weaponPosition, curvePoint.position, hand.position);
//     //         this.axeReturnTime += Time.unscaledDeltaTime * 1.5f;
//     //     }
//     //     else
//     //         CatchWeapon();
//     // }

//     // private void StartLunchToWeapon()
//     // {
//     //     weaponPosition = weapon.transform.position;
//     //     this.GetComponent<Rigidbody>().Sleep();
//     //     this.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
//     //     this.GetComponent<Rigidbody>().isKinematic = true;
//     //     launching = true;
//     // }

//     // private void DoLaunch()
//     // {
//     //     if (Vector3.Distance(weaponPosition, this.transform.position) > 2)
//     //     {
//     //         // TODO: Ask the teacher about how to add force to the default fps controller
//     //         // var rigidbody = this.GetComponent<Rigidbody>();
//     //         // Vector3 direction = (weaponPosition - this.transform.position).normalized;
//     //         // rigidbody.AddForce(direction * launchPower, ForceMode.Acceleration);

//     //         var returnTime = launchPower * Time.timeScale;
//     //         this.transform.position = Vector3.MoveTowards(this.transform.position, weaponPosition, returnTime);
//     //     }
//     //     else
//     //         CatchWeapon();
//     // }

//     // private void CatchWeapon()
//     // {
//     //     this.axeReturnTime = 0;
        
//     //     if(polling)
//     //     {
//     //         polling = false;
//     //         weaponScript.activated = false;
//     //         weapon.GetComponent<ParticleSystem>().Stop();
//     //     }

//     //     if(launching)
//     //     {
//     //         if(this.character.Grounded)
//     //         {
//     //             this.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
//     //             this.GetComponent<Rigidbody>().isKinematic = false;
//     //             weaponScript.isHit = false;
//     //             hand.GetComponent<VisualEffect>().enabled = false;
//     //             launching = false;
//     //         }
//     //     }


//     //     Destroy(weapon);        
//     //     handAxe.SetActive(true);
//     //     hasWeapon = true;
//     // }

//     private Vector3 GetQuadraticCurvePoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
//     {
//         float u = 1 - t;
//         float tt = t * t;
//         float uu = u * u;
//         return (uu * p0) + (2 * u * t * p1) + (tt * p2);
//     }
// }


