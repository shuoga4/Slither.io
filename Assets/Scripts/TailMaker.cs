using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailMaker : MonoBehaviour
{
    // Start is called before the first frame update
    //�^�C���f���^��instantiate�����x�点�Aupdate�ŃR���[�`�����点�A���������I�u�W�F�N�g�����݂͂�ȃR���[�`���������Ă��炤�A���Ԃ����炷
    public GameObject tail;
    [System.NonSerialized] public int counter = 1;
    public Starter starter;
    public GameObject[] deletetail = new GameObject[200];
    // Update is called once per frame
    void Update()
    {
        if (starter.updateGenesis)
        {
            if (Time.frameCount % 800 == 0) // �V�[�������[�h����Ă��炾����A�{�^�������������Ƃ̂����ۂ̐����n�ߕ��ɍ����ł���A�N���b�N�̎����H�^�C���A�^�b�N�Ƃ����ԕ\���Ɏg������
            {
                var top = Instantiate(tail, new Vector3(0, 100, 0), Quaternion.identity);
                top.transform.SetParent(transform);
                deletetail[counter] = top;
                counter++;
            }
        }
        
    }
    public void DeleteTail()
    {
        foreach(GameObject b in deletetail)
        {
            if (b == null)
                continue;
            Destroy(b);
        }
    }
}
