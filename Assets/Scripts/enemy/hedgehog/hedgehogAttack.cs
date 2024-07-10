using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hedgehogAttack : MonoBehaviour
{
    public float alertRange;
    public bool MoveOrNot;
    private bool isAlert; // �Ƿ��ڽ䱸״̬
    private bool isRelax; // �Ƿ��ڷ���״̬
    private float alertTimer; // �����ʱ��
    public float alertDuration; // ����״̬����ʱ��
    private float relaxTimer; // ���ɼ�ʱ��
    public float relaxDuration; // ����״̬����ʱ��
    Transform player;
    private void Awake()
    {
        relaxDuration = 3.0f;
        relaxTimer = 0;
        isAlert = false;
        isRelax = false;
        alertTimer = 0;
        alertDuration = 1.0f;
        alertRange = 3.0f; // ���䷶ΧΪ3
        MoveOrNot = true; // ���ñ�������ƶ�
        player = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        CheckPlayerProximity();
        HandleState();
}

    private void CheckPlayerProximity()
    {
        // �������Ƿ��ھ��䷶Χ�ڣ��κ���ײ�������Բ�غ϶��᷵��True
        if (Vector3.Distance(transform.position, player.position) <= alertRange)
        {
            // �������ڷ�Χ�ڣ����ý䱸״̬
            isAlert = true;
        }
        else
        {
            // �����Ҳ��ڷ�Χ�ڣ����÷���״̬
            isAlert = false;
        }
    }

    private void AlertState()
    {
        //���¼�ʱ3s
        alertTimer = 0;
        MoveOrNot = false; // �Ա���ʩ�ӽ�ֹ�ƶ�
        // ����䱸״̬
        // ���������������˺��ͷ�����ײ�˺����߼�
        Debug.Log("hedgehog is now alert!");
    }

    private void RelaxState()
    {
        MoveOrNot = true;// �Ա�������ֹ�ƶ�
        Debug.Log("hedgehog is now relax!");
        // ���������Ӻ�������ܵ��˺����߼������ܵ��˺���1
    }

    private void HandleState()
    {
        if (isAlert && !isRelax)
        {
            relaxTimer = 0;
            MoveOrNot = false;
            AlertState();// ���뾯��״̬

        }
        else
        {
            alertTimer += Time.deltaTime; //����״̬����ʱ��
            if (alertTimer >= alertDuration)
            {
                //����һ��ʱ�����ɣ�����һ��ʱ���ڲ��ᾯ��
                RelaxState();
                isRelax = true;
                relaxTimer += Time.deltaTime; //����״̬����ʱ��
                if (relaxTimer >= relaxDuration)
                {
                    isRelax = false;// ����ʱ���������ʱ���䣡
                }
            }
        }
    }

}
