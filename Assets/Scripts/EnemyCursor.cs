using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCursor : MonoBehaviour
{
    // Start is called before the first frame update
    //範囲内で何秒かに一回ランダムにtpする謎物体
    /*
     * intを２つ作ってrangeでrandomして、coroutineでその関数を何秒に一回するか決める
     * 範囲は面白さ考えたら2倍ぐらい大きくしてもいいかも、いや急ターンのほうがおもろいから狭くするかと思ったらもし画面内にピンたって回り始めたら自滅や
     * 
     */
    public int minX = -100;
    public int maxX = 100;
    public int minZ = -50;
    public int maxZ = 50;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.frameCount % 200 == 0)
        {
            var x = Random.Range(minX, maxX);
            var z = Random.Range(minZ, maxZ);
            transform.position = new Vector3(x, transform.position.y, z);
        }
    }
}
