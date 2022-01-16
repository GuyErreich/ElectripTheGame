using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBracking : MonoBehaviour
{
    private GameObject _wallPiece;

    // Start is called before the first frame update
    void Start()
    {
        var pieces = GameObject.FindGameObjectsWithTag("BreakableWallPiece");
        // this.CreateFixedJointOnClosestPiece(pieces);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.name.Contains("ActiveAxe"))
        {
            // this.GetComponent<MeshCollider>().isTrigger = false;
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<Rigidbody>().useGravity = true;
            this.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
        if (collision.gameObject.name.Contains("BreakableWallPiece"))
        {            
            this.gameObject.AddComponent<FixedJoint>();
            this.gameObject.GetComponent<FixedJoint>().connectedBody = collision.rigidbody;
            this.gameObject.GetComponent<FixedJoint>().breakForce = 1000;
        }
    }

    private void CreateFixedJointOnClosestPiece(GameObject[] pieces)
    {
        Vector3 currentPos = this.transform.position;
        foreach (GameObject g in pieces)
        {
            float dist = Vector3.Distance(g.transform.position, currentPos);
            if (dist == 0)
            {
                if (g != gameObject)
                {
                    var fixedJoint = gameObject.AddComponent<FixedJoint>();
                    fixedJoint.connectedBody = g.GetComponent<Rigidbody>();
                    fixedJoint.breakForce = 10000;
                }
            }
        }
    }
}
