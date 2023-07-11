using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitJudge : MonoBehaviour
{
    public Score score;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        var tailChaser = GetComponent<TailChaser>();
        if (CompareTag("RedTail"))
        {
            if (other.CompareTag("Blue")) score.RedScoreOneUp();
            // 他スクリプトの得点加算処理(赤に得点)
            if (other.CompareTag("Red"))
            {
                if (tailChaser.tailnum == 1f) ;
                else
                    score.BlueScoreOneUp();
            }
            // 自爆（青に得点)
        }
        if (CompareTag("BlueTail"))
        {
            if (other.CompareTag("Red")) score.BlueScoreOneUp();
            // 青に得点
            if (other.CompareTag("Blue"))
            {
                if (tailChaser.tailnum == 1f) ;
                else
                    score.RedScoreOneUp(); 
                // エネミーのファーストテイルもここにインポートして避ける必要あり
            }
            // 自爆（赤に得点）
        }
    }
}
