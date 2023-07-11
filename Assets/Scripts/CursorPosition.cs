using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPosition : MonoBehaviour
{
    public GameObject cursor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        // mouse.z = 0; no diff
        mouse.z = 47;


        Vector3 target = Camera.main.ScreenToWorldPoint(mouse); // xとyの画面における座標+向いている方向をもとに現実に作っている
        cursor.transform.position = target;

    }
}
/*
 * 学んだこと
 * なにか挙動がわからないものへのアプローチは、まず入れた変数をlogで確かめることが有効
 * 解が見つかる可能性が高い
 * 
 * 
 * 
 * solved:
 * ScreenToWorldPointについて
 * 必要な値:(x,y)ただし画面座標
 * 返す値：(x,y,z)ただしzを指定する必要あり、カメラからz離れた位置にx,yを置く（現実座標)
 * zの大きさに応じてxとyの値が変わる。カメラから近かったらx,yの変化量も少ない
 * カメラから遠かったらx,yの変化量は大きい
 * これはz軸の方向を向いているときの挙動である
 * 
 * これがy軸を向いているときの挙動を考察する
 * mouse.z = mouse.yのときが一番近かった
 * ただしカメラからの距離も異なるので下に行けば行くほど手前に、その分zの変化量が少なくなる
 * 上に行けば行くほど小さくなりzの変化量は大きくなる
 * 
 * そもそもmouseのときは一致していたyとzがScreenToWorldPoint後は違っている
 * yとzの挙動を考察する
 * カーソルにz軸を追加しyと一致させる　＝　yが大きいとzも大きくなる
 * yが大きい　＝　上にカーソルがある
 * zが大きい　＝　奥にカーソルがある
 * xはうまくxとして変換されている
 * 例えばカメラ方向によってはxがy軸方向に動かされることもある
 * 
 * ScreenToWorldPointに入る前のvector3について考察する
 * 
 * target以降の変数変更はカーソルをうまく追従しない可能性が高い
 * 
 * 
 * 
 * 
 * ＾ワールドポイント取得前試行錯誤
 * 例えばmouseが(10,10)だったとする
 * mouse = (10,10,0)
 * これをそのままtransformのpositionに代入すると
 * カーソルが左下にあるときに画面の中央にplayerが現れる
 * それ以外はz軸の動きが無いため画面外に飛んでいく
 * 数値変化も無いためxもyもぶっ飛ぶ
 * 
 * このままカメラのscreentoworldpointを使うと
 * カメラ座標とplayer座標が一致する＝くっつく
 * 離してあげる必要あり
 * 
 * zを先に指定してカメラ距離を測らせて、値を出してもらったあとに座標を切り替える？
 * だめ
 * 
 * 
 * 
 * z = y のとき
 * mouse = (10,10,10)
 * 代入すると
 * z = y なので上に行くほど小さくなり、下に行くほど大きくなる
 * 動作確認済
 * 
 * z = y かつ y = 0　のとき
 * mouse = (10,0,10)
 * 代入すると
 * y = 0　なので物体は常に一定の大きさ、さらに位置も変化する
 * 
 * ＾取得後
 * target.z = targeet.y;
 * target.y = 0;
 * 動かない
 * 
 * ＾混合
 * mouse.z = mouse.y;
 * target.y = 0;
 * やりたい動作は一番近いが感度が高すぎる
 * なんか挙動おかしい
 * 
 * mouse.z = 0
 * target.z = target.y;
 * target.y = 0
 * 動かない
 * 
 */