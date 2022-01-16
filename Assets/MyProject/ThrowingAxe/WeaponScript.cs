using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private bool _activated = true, isHit = false;
    private string targetHit;

    public bool IsHit
    {
        get => this.isHit;
    }

    public string TargetHit
    {
        get => this.targetHit;
    }

    public void Start()
    {
        _activated = true;
    }

    void Update()
    {
        if (_activated)
            this.transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.targetHit = collision.gameObject.tag;
        if (collision.gameObject.CompareTag("Target") || collision.gameObject.name.Contains("Terrain"))
        {
            print(collision.gameObject.name);
            GetComponent<Rigidbody>().Sleep();
            GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            GetComponent<Rigidbody>().isKinematic = true;
            _activated = false;
            this.isHit = true;
        }
    }
}