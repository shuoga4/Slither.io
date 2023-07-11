using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectSetting : MonoBehaviour
{
    // Start is called before the first frame update
    [System.NonSerialized] public bool pass = false;
    private bool one = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (one == false)
        {
            if (pass == true)
            {
                StartCoroutine(DelayPass());
                one = true;
            }
        }

    }
    IEnumerator DelayPass()
    {
        yield return new WaitForSeconds(0.5f);
        pass = false;
        one = false;
    }
}
