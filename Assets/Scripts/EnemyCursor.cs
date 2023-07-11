using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCursor : MonoBehaviour
{
    // Start is called before the first frame update
    //�͈͓��ŉ��b���Ɉ�񃉃��_����tp����䕨��
    /*
     * int���Q�����range��random���āAcoroutine�ł��̊֐������b�Ɉ�񂷂邩���߂�
     * �͈͖͂ʔ����l������2�{���炢�傫�����Ă����������A����}�^�[���̂ق��������낢���狷�����邩�Ǝv�����������ʓ��Ƀs�������ĉ��n�߂��玩�ł�
     * 
     */
    public int minX = -100;
    public int maxX = 100;
    public int minZ = -50;
    public int maxZ = 50;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.frameCount % 200 == 0)
        {
            var x = Random.Range(minX, maxX);
            var z = Random.Range(minZ, maxZ);
            transform.position = new Vector3(x, transform.position.y, z);
        }
    }
}
