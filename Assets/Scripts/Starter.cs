using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    // Start is called before the first frame update
    [System.NonSerialized] public bool updateGenesis = false;
    public Canvas button;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
     * ���߂��鋓��
     * update�n�������Ŏ~�߂Ă���A���̊֐��������Ƒ���update�n���N���ł���
     * �J�[�\���ɉ����ē����n�߂�
     * �����ۂ������n�߂�
     * �����ۂ��ǂ��n�߂�
     */
    public void OnClick()
    {
        updateGenesis = true;
        button.gameObject.SetActive(false);
    }
}
