using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruct : MonoBehaviour
{
    public float waitTime = 4f;

    // Start is called before the first frame update
    void Start()
    {
          StartCoroutine(Destruct());
    }

    private IEnumerator Destruct()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        Destroy(this.gameObject);
    }
}
