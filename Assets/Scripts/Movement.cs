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
     * ��������������
     * ���̑��x�ŃJ�[�\���I�u�W�F�N�g�����ɒǏ]����u���b�N
     * �Ȃ���p�x������������
     */

    /*
     * �Ǐ]�ɂ���
     * �J�[�\�����C���|�[�g���āA���̕����Ɍ������Đi�ݑ�����
     * ���x�͈��Aspeed�ϐ�
     * �͂���������velocity���瑬�x��萔�œ����̂������̂��H
     * rigidbody�̕K�v��
     * 
     * velocity��vector3�^������magnitude
     * �i�ޕ��p�̒P�ʃx�N�g�����ق���
     * �J�[�\���̏ꏊ-������ꏊ=�i�ޕ���
     * �i�ޕ���/magnitude = �P�ʃx�N�g��
     * �P�ʃx�N�g�� �~�@�萔speed = player��velocity
     */

    /*
     * �Ȃ���p�x�����ɂ���
     * euler�Ŋp�x���o����H
     * ���i��ł�����Ɛi�݂��������̈ʑ��������
     * ���̊p�x�����l�ȏ�=���l�ȉ��ɏC�����ċȂ���
     * �ςȂƂ���Ŏ~�܂����肷�邩�H
     * 
     * �ʑ����̎������킩��Ȃ�
     * Quaternion�H
     * https://w3e.kanazawa-it.ac.jp/math/category/vector/henkan-tex.cgi?target=/math/category/vector/naiseki-wo-fukumu-kihonsiki.html&pcview=0
     * ���ʂɃx�N�g���Ԃ̓��ς���o�����
     * if�ŎQ�킵�Ă����A�Ă�vector���m�̊|���Z��unity�̓J�o�[���Ă���̂�
     * ����cos�Ƃ̒l���������i�s�p�����傫���J���Ă���ꍇ�ł���A90�x�������cos�}�C�i�X�ɂȂ�H)
     * 
     * 
     * https://nekojara.city/unity-vector-dot
     * �x�N�g�����ςɂ���
     * 
     * https://nekojara.city/unity-vector-angle
     * �x�N�g���Ԋp�x�ɂ���
     * 
     * �ŏI�I��Quaternion�g����euler�ő���O�x�N�g���ɂ����ċȂ���p�x������t������
     * angle���o�āA����70�x�ȏ�𐧌�����Ƃ�����A�Ⴆ��
     * if(angle >= 70)
     * {
     * �܂��āA70�x�ȏ�𐧌�����ƌ����Ă��A2f�ڂɂ�140�x�����Ɍ����邶���
     * 1,2�x������A�͒Ⴍ�Ă���߂������̂���
     * 
     * Quaternion����
     * 
     */
    void Update()
    {
        if (starter.updateGenesis)
        {
            var rawDirection = cursor.transform.position - transform.position;// ������������t�����A�t����Ȃ�����
            var oneDirection = rawDirection / rawDirection.magnitude;
            var velo = oneDirection * speed; //��u����Ȃ����Ǝv��������-1<angle<1�Ԃ̋����ɕK�v����
            var rb = GetComponent<Rigidbody>();
            var angle = Vector3.SignedAngle(rb.velocity, velo, Vector3.up); // �Ԃ�l��+-0~180[�x]�A+-��y���̉�]�����B���˂�+�A�E�˂�-�Bplayer�̎�����E��肷��ƌ����Ă��������s�����������͏�ɉE���Ȃ̂ō��˂�+�B
            if (angle >= 1)
            {
                velo = Quaternion.Euler(0, 1, 0) * rb.velocity; // ��L��velo��oneD * speed�ŁA�ʏ�ʂ肾���A�����rb.velo * euler�Ŋp�x�𐧌�����speed�������Ă��邪speed�͂���Ȃ��Arbvelo�ɂ��łɓ����Ă��邽�߁B
            }
            if (angle <= -1) //�܂��ł悭�C�Â����Bangle >= -5�ƂȂ��Ă����B�������ŊǗ����Ă�΋N����Ȃ����������B��ɑz������B
            {
                velo = Quaternion.Euler(0, -1, 0) * rb.velocity;
            }
            rb.velocity = velo;
        }
        
    }
    public void Starter()
    {
        var rawDirection = cursor.transform.position - transform.position;// ������������t�����A�t����Ȃ�����
        var oneDirection = rawDirection / rawDirection.magnitude;
        var velo = oneDirection * speed;
        var rb = GetComponent<Rigidbody>();
        rb.velocity = velo;

    }
}
