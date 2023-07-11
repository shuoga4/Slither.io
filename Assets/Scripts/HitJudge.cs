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
            // ���X�N���v�g�̓��_���Z����(�Ԃɓ��_)
            if (other.CompareTag("Red"))
            {
                if (tailChaser.tailnum == 1f) ;
                else
                    score.BlueScoreOneUp();
            }
            // �����i�ɓ��_)
        }
        if (CompareTag("BlueTail"))
        {
            if (other.CompareTag("Red")) score.BlueScoreOneUp();
            // �ɓ��_
            if (other.CompareTag("Blue"))
            {
                if (tailChaser.tailnum == 1f) ;
                else
                    score.RedScoreOneUp(); 
                // �G�l�~�[�̃t�@�[�X�g�e�C���������ɃC���|�[�g���Ĕ�����K�v����
            }
            // �����i�Ԃɓ��_�j
        }
    }
}
