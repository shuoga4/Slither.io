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


        Vector3 target = Camera.main.ScreenToWorldPoint(mouse); // x��y�̉�ʂɂ�������W+�����Ă�����������ƂɌ����ɍ���Ă���
        cursor.transform.position = target;

    }
}
/*
 * �w�񂾂���
 * �Ȃɂ��������킩��Ȃ����̂ւ̃A�v���[�`�́A�܂����ꂽ�ϐ���log�Ŋm���߂邱�Ƃ��L��
 * ����������\��������
 * 
 * 
 * 
 * solved:
 * ScreenToWorldPoint�ɂ���
 * �K�v�Ȓl:(x,y)��������ʍ��W
 * �Ԃ��l�F(x,y,z)������z���w�肷��K�v����A�J��������z���ꂽ�ʒu��x,y��u���i�������W)
 * z�̑傫���ɉ�����x��y�̒l���ς��B�J��������߂�������x,y�̕ω��ʂ����Ȃ�
 * �J�������牓��������x,y�̕ω��ʂ͑傫��
 * �����z���̕����������Ă���Ƃ��̋����ł���
 * 
 * ���ꂪy���������Ă���Ƃ��̋������l�@����
 * mouse.z = mouse.y�̂Ƃ�����ԋ߂�����
 * �������J��������̋������قȂ�̂ŉ��ɍs���΍s���قǎ�O�ɁA���̕�z�̕ω��ʂ����Ȃ��Ȃ�
 * ��ɍs���΍s���قǏ������Ȃ�z�̕ω��ʂ͑傫���Ȃ�
 * 
 * ��������mouse�̂Ƃ��͈�v���Ă���y��z��ScreenToWorldPoint��͈���Ă���
 * y��z�̋������l�@����
 * �J�[�\����z����ǉ���y�ƈ�v������@���@y���傫����z���傫���Ȃ�
 * y���傫���@���@��ɃJ�[�\��������
 * z���傫���@���@���ɃJ�[�\��������
 * x�͂��܂�x�Ƃ��ĕϊ�����Ă���
 * �Ⴆ�΃J���������ɂ���Ă�x��y�������ɓ�������邱�Ƃ�����
 * 
 * ScreenToWorldPoint�ɓ���O��vector3�ɂ��čl�@����
 * 
 * target�ȍ~�̕ϐ��ύX�̓J�[�\�������܂��Ǐ]���Ȃ��\��������
 * 
 * 
 * 
 * 
 * �O���[���h�|�C���g�擾�O���s����
 * �Ⴆ��mouse��(10,10)�������Ƃ���
 * mouse = (10,10,0)
 * ��������̂܂�transform��position�ɑ�������
 * �J�[�\���������ɂ���Ƃ��ɉ�ʂ̒�����player�������
 * ����ȊO��z���̓������������߉�ʊO�ɔ��ł���
 * ���l�ω�����������x��y���Ԃ����
 * 
 * ���̂܂܃J������screentoworldpoint���g����
 * �J�������W��player���W����v���遁������
 * �����Ă�����K�v����
 * 
 * z���Ɏw�肵�ăJ���������𑪂点�āA�l���o���Ă���������Ƃɍ��W��؂�ւ���H
 * ����
 * 
 * 
 * 
 * z = y �̂Ƃ�
 * mouse = (10,10,10)
 * ��������
 * z = y �Ȃ̂ŏ�ɍs���قǏ������Ȃ�A���ɍs���قǑ傫���Ȃ�
 * ����m�F��
 * 
 * z = y ���� y = 0�@�̂Ƃ�
 * mouse = (10,0,10)
 * ��������
 * y = 0�@�Ȃ̂ŕ��̂͏�Ɉ��̑傫���A����Ɉʒu���ω�����
 * 
 * �O�擾��
 * target.z = targeet.y;
 * target.y = 0;
 * �����Ȃ�
 * 
 * �O����
 * mouse.z = mouse.y;
 * target.y = 0;
 * ��肽������͈�ԋ߂������x����������
 * �Ȃ񂩋�����������
 * 
 * mouse.z = 0
 * target.z = target.y;
 * target.y = 0
 * �����Ȃ�
 * 
 */