using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAttack : MonoBehaviour
{
    public Transform target; // ��ҵ�Transform���
    public float attackRange = 5.0f; // ���˵Ĺ�����Χ
    public float attackCooldown = 2.0f; // ������ȴʱ��
    private float nextAttackTime = 0.0f; // �´ο��Թ�����ʱ��
    private void Awake()
    {
        target = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        // �������Ƿ��ڹ�����Χ��
        if (Vector3.Distance(transform.position, target.position) <= attackRange)
        {
            // ����Ƿ��Ѿ�������ȴʱ��
            if (Time.time >= nextAttackTime)
            {
                AttackPlayer();
                // �����´ι���ʱ��
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    private void AttackPlayer()
    {
        // ����ʵ�ֹ����߼������磺
        // - ���ö���ϵͳ���Ź�������
        // - ���������˺�
        Debug.Log("���˽�ս������ң�");
    }
}