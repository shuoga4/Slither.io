using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [System.NonSerialized] public int redScore = 0;
    [System.NonSerialized] public int blueScore = 0;
    public Canvas button;
    public Starter starter;
    public TailMaker ptailMaker;
    public TailMaker etailMaker;
    public TailChaser ptailChaser;
    public TailChaser etailChaser;
    public GameObject player;
    public GameObject enemy;
    // ているの位置も読んどいて、新たに追加されたのだけ配列に入れて消せばいいんでね？
    public GameObject redTail;
    public GameObject blueTail;
    public GameObject textobj;
    private Vector3 ptrans;
    private Vector3 etrans;
    private Vector3 rtrans;
    private Vector3 btrans;

    // Start is called before the first frame update
    void Start()
    {
        ptrans = player.transform.position;
        etrans = enemy.transform.position;
        rtrans = redTail.transform.position;
        btrans = blueTail.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Text text = textobj.GetComponent<Text>();
        text.text = "red:" + redScore + "  blue:" + blueScore;
    }
    public void RedScoreOneUp()
    {
        redScore++;
        Restart();
    }
    public void BlueScoreOneUp()
    {
        blueScore++;
        Restart();
    }
    /*
     * 求められる挙動
     * redとblueの位置のリセット
     * 尻尾をリセット（一つだけ残して？もしくは残さなくてもいいが、裏でupdateが進み続けているのでまずcounterのリセットが必要
     * 始まる前になにかスイッチをおいておく？
     * そのほうが良さそう
     * 
     * 各スクリプトにリセット処理書いてそれらの実行をここで行う？
     */
    void Restart()
    {
        Debug.Log("reset");
        starter.updateGenesis = false;
        ptailMaker.counter = 1;
        etailMaker.counter = 1;
        ptailMaker.DeleteTail();
        etailMaker.DeleteTail();
        var rigid = player.GetComponent<Rigidbody>();
        rigid.velocity = Vector3.zero;
        var rb = enemy.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        ptailChaser.StopChase(); // これもエネミー用に必要か
        etailChaser.StopChase(); // これもエネミー用に必要か
        player.transform.position = ptrans;
        enemy.transform.position = etrans;
        redTail.transform.position = rtrans;
        blueTail.transform.position = btrans;
        button.gameObject.SetActive(true);
    }
}
