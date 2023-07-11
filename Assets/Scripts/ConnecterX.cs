using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnecterX : MonoBehaviour
{
    // Start is called before the first frame update
    public ConnectSetting pCS;
    public ConnectSetting eCS;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Red"))
        {
            if (pCS.pass == false)
            {
                Vector3 pos = other.ClosestPoint(transform.position); // onboundsなるものもあるらしい
                other.transform.position = new Vector3(pos.x * -1, pos.y, pos.z); // 反対側の座標を確かめる
                pCS.pass = true;
            }
        }
        if (other.CompareTag("Blue"))
        {
            if (eCS.pass == false)
            {
                Vector3 pos = other.ClosestPoint(transform.position); // onboundsなるものもあるらしい
                other.transform.position = new Vector3(pos.x * -1, pos.y, pos.z); // 反対側の座標を確かめる
                eCS.pass = true;
            }
        }

    }
}

