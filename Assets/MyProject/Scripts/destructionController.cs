using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructionController : MonoBehaviour
{
    public GameObject remains;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Instantiate(remains, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.name.Contains("ActiveAxe"))
        {
            Instantiate(remains, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
