using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailChaser : MonoBehaviour
{
    /*
     * ���҂���鋓��
     * ���ɒǏ]����悤��sphere�𐶐�����
     * prefab�Ainstantiate�����肪�g������
     * �������ꂽ���̂̌��Ɏ���sphere�����������
     * 
     * ���̂܂��ɂ܂����̂������ۂ̂悤�ɂ��Ă������������
     * ���ʂɉ�f���O�̍��W���L�����Ă��������ŗǂ�����
     * 
     * tail�������instantiate���č���Ă݂�A��׈ꏏ�ɂ����������Ő��������W��ǂݎ��Ȃ�����
     * 
     * ���Ɏ��Ԃ�instantiate���鋓���ɂ���
     */

    /*
     * �����Ⴒ����ɂȂ��Ă������琮������
     * chaser�̃R���[�`���͍�����A������e�I�u�W�F�N�g�Ɏ����Ă��炤
     * ����ɑ��X�N���v�g�𓱓�����
     * �ق��X�N���v�g�ł͂��̃I�u�W�F�N�g�̐������s���Ă��炤
     * ���̒��ɂ��鐶�����̖ڂ��̏�񂪓������ϐ����������ɓǂݎ��i�ǂݎ����݂̂ɂ���j
     * ���̐������������ŕێ����Ēx���ʂ����肷��
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
    public IEnumerator Chaser() // tail�������update�œ��삷��̂͊m�F�ς݁A���Ԃ����O���Ǘ��ɂ��Ĕz�艮�������H���d���F���̖ڂ��m�F����O���[�o���ϐ�
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
