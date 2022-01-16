using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstUnityGame.Assets.MyProject.Abilities;

namespace FirstUnityGame.Assets.MyProject.Target
{
    public class Kill : MonoBehaviour
    {
        [SerializeField] private AbilitySystem abilitySystem;
        [SerializeField] private Transform spawn;
        // Start is called before the first frame update
        private void OnTriggerEnter(Collider collider)
        {   
            print("shit");
            if (collider.gameObject.CompareTag("Player"))
            {
                print("shit1");

                collider.gameObject.transform.position = spawn.position;
                collider.gameObject.transform.rotation = spawn.rotation;
                abilitySystem.SetState(new AxeInHand(abilitySystem));
            }
        }
    }
}