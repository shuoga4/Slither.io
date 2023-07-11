using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailMaker : MonoBehaviour
{
    // Start is called before the first frame update
    //タイムデルタでinstantiate生成遅らせつつ、updateでコルーチン走らせつつ、生成したオブジェクトたちはみんなコルーチンを持ってもらう、時間をずらす
    public GameObject tail;
    [System.NonSerialized] public int counter = 1;
    public Starter starter;
    public GameObject[] deletetail = new GameObject[200];
    // Update is called once per frame
    void Update()
    {
        if (starter.updateGenesis)
        {
            if (Time.frameCount % 800 == 0) // シーンがロードされてからだから、ボタンを押したあとのしっぽの生え始め方に差ができる、クロックの実装？タイムアタックとか時間表示に使えそう
            {
                var top = Instantiate(tail, new Vector3(0, 100, 0), Quaternion.identity);
                top.transform.SetParent(transform);
                deletetail[counter] = top;
                counter++;
            }
        }
        
    }
    public void DeleteTail()
    {
        foreach(GameObject b in deletetail)
        {
            if (b == null)
                continue;
            Destroy(b);
        }
    }
}
