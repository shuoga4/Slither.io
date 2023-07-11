using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailChaser : MonoBehaviour
{
    /*
     * 期待される挙動
     * 後ろに追従するようにsphereを生成する
     * prefab、instantiateあたりが使えそう
     * 生成されたものの後ろに次のsphereが生成される
     * 
     * そのまえにまず物体がしっぽのようについていく挙動を作る
     * 普通に何fか前の座標を記憶しておくだけで良さそう
     * 
     * tailを一つだけinstantiateして作ってみる、やべ一緒につくったせいで正しく座標を読み取れなさそう
     * 
     * 次に時間でinstantiateする挙動にする
     */

    /*
     * ごちゃごちゃになってきたから整理する
     * chaserのコルーチンは作った、これを各オブジェクトに持ってもらう
     * これに他スクリプトを導入する
     * ほかスクリプトではこのオブジェクトの生成を行ってもらう
     * その中にある生成何体目かの情報が入った変数をこっちに読み取る（読み取り一回のみにする）
     * その数字をこっちで保持して遅延量を決定する
     */
    // Start is called before the first frame update
    public TailMaker tailMaker;
    public GameObject chased;
    private Vector3 pos;
    private float delay;
    public Starter starter;
    [System.NonSerialized] public float tailnum;
    void Start()
    {
        tailnum = tailMaker.counter;
        delay = tailnum / 8;
        delay += 0.05f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (starter.updateGenesis)
        {
            pos = chased.transform.position;
            StartCoroutine(Chaser());
        }
    }
    public IEnumerator Chaser() // tailがあればupdateで動作するのは確認済み、時間だけ外部管理にして配り屋さんつくる？お仕事：何体目か確認するグローバル変数
    {
        var rawPosition = pos;
        yield return new WaitForSeconds(delay);
        transform.position = rawPosition;
    }
    public void StopChase()
    {
        StopAllCoroutines();
    }
}
