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
    // �Ă���̈ʒu���ǂ�ǂ��āA�V���ɒǉ����ꂽ�̂����z��ɓ���ď����΂�����łˁH
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
     * ���߂��鋓��
     * red��blue�̈ʒu�̃��Z�b�g
     * �K�������Z�b�g�i������c���āH�������͎c���Ȃ��Ă��������A����update���i�ݑ����Ă���̂ł܂�counter�̃��Z�b�g���K�v
     * �n�܂�O�ɂȂɂ��X�C�b�`�������Ă����H
     * ���̂ق����ǂ�����
     * 
     * �e�X�N���v�g�Ƀ��Z�b�g���������Ă����̎��s�������ōs���H
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
        ptailChaser.StopChase(); // ������G�l�~�[�p�ɕK�v��
        etailChaser.StopChase(); // ������G�l�~�[�p�ɕK�v��
        player.transform.position = ptrans;
        enemy.transform.position = etrans;
        redTail.transform.position = rtrans;
        blueTail.transform.position = btrans;
        button.gameObject.SetActive(true);
    }
}
