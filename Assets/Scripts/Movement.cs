using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject cursor;
    [SerializeField] private float speed = 1.0f;
    public Starter starter;
    // Start is called before the first frame update

    // Update is called once per frame
    /*
     * 実装したいもの
     * 一定の速度でカーソルオブジェクト方向に追従するブロック
     * 曲がり角度制限をつけたい
     */

    /*
     * 追従について
     * カーソルをインポートして、その方向に向かって進み続ける
     * 速度は一定、speed変数
     * 力を加えるよりvelocityから速度を定数で入れるのがいいのか？
     * rigidbodyの必要性
     * 
     * velocityはvector3型だからmagnitude
     * 進む方角の単位ベクトルがほしい
     * カーソルの場所-今いる場所=進む方向
     * 進む方向/magnitude = 単位ベクトル
     * 単位ベクトル ×　定数speed = playerのvelocity
     */

    /*
     * 曲がり角度制限について
     * eulerで角度を出せる？
     * 今進んでる方向と進みたい方向の位相差を取る
     * その角度が一定値以上=一定値以下に修正して曲がる
     * 変なところで止まったりするか？
     * 
     * 位相差の取り方がわからない
     * Quaternion？
     * https://w3e.kanazawa-it.ac.jp/math/category/vector/henkan-tex.cgi?target=/math/category/vector/naiseki-wo-fukumu-kihonsiki.html&pcview=0
     * 普通にベクトル間の内積から出るやつやん
     * ifで参戦していく、てかvector同士の掛け算をunityはカバーしているのか
     * もしcosθの値が小さい（鋭角だが大きく開いている場合である、90度超えるとcosマイナスになる？)
     * 
     * 
     * https://nekojara.city/unity-vector-dot
     * ベクトル内積について
     * 
     * https://nekojara.city/unity-vector-angle
     * ベクトル間角度について
     * 
     * 最終的にQuaternion使ってeulerで代入前ベクトルにかけて曲がり角度制限を付けたい
     * angleが出て、仮に70度以上を制限するとしたら、例えば
     * if(angle >= 70)
     * {
     * まって、70度以上を制限すると言っても、2f目には140度方向に向けるじゃん
     * 1,2度あたり、は低くても低めがいいのかも
     * 
     * Quaternion調査
     * 
     */
    void Update()
    {
        if (starter.updateGenesis)
        {
            var rawDirection = cursor.transform.position - transform.position;// もしかしたら逆かも、逆じゃなかった
            var oneDirection = rawDirection / rawDirection.magnitude;
            var velo = oneDirection * speed; //一瞬いらないかと思ったけど-1<angle<1間の挙動に必要だわ
            var rb = GetComponent<Rigidbody>();
            var angle = Vector3.SignedAngle(rb.velocity, velo, Vector3.up); // 返り値は+-0~180[度]、+-はy軸の回転方向。左ねじ+、右ねじ-。playerの周りを右回りすると向いてる方向から行きたい方向は常に右側なので左ねじ+。
            if (angle >= 1)
            {
                velo = Quaternion.Euler(0, 1, 0) * rb.velocity; // 上記のveloはoneD * speedで、通常通りだが、今回はrb.velo * eulerで角度を制限してspeedをかけているがspeedはいらない、rbveloにすでに入っているため。
            }
            if (angle <= -1) //まじでよく気づいた。angle >= -5となっていた。数直線で管理してれば起こらなかったかも。常に想像せよ。
            {
                velo = Quaternion.Euler(0, -1, 0) * rb.velocity;
            }
            rb.velocity = velo;
        }
        
    }
    public void Starter()
    {
        var rawDirection = cursor.transform.position - transform.position;// もしかしたら逆かも、逆じゃなかった
        var oneDirection = rawDirection / rawDirection.magnitude;
        var velo = oneDirection * speed;
        var rb = GetComponent<Rigidbody>();
        rb.velocity = velo;

    }
}
