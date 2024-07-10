using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAttack1 : MonoBehaviour
{
    public Transform player; // ��ҵ�Transform���
    public float attackRange = 5.0f; // ������Χ
    public float chargeTime = 0.5f; // ����ʱ��
    public float attackSpeed = 5.0f; // ����ٶ�
    public float attackDuration = 1.0f; // ��̳���ʱ��
    public float cooldownTime = 5.0f; // ������ȴʱ��
    private float nextAttackTime; // �´ο��Թ�����ʱ��
    private float attackStartTime;
    private Vector3 direction;
    public float MoveSpeed;  //��������ʱ��ֹ�ƶ�
    private bool isCharging = false; // �Ƿ���������
    private bool isAttacking = false; // �Ƿ����ڹ���
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }
    void Update()
    {
        // ����Ƿ��˿����ٴ�ʹ�ü��ܵ�ʱ��
        if (Time.time >= nextAttackTime)
        {
            // �������Ƿ��ڹ�����Χ��
            if (Vector3.Distance(transform.position, player.position) <= attackRange &&
                !isCharging &&
                !isAttacking)
            {
                StartCharging();
            }
        }

        // ��������Ƿ���ɲ���ʼ����
        if (isCharging && (Time.time - attackStartTime) >= chargeTime)
        {
            PerformAttack();
        }

        // ������ڹ�������鹥���Ƿ����
        if (isAttacking && (Time.time - nextAttackTime) >= attackDuration)
        {
            EndAttack();
        }
    }

    void StartCharging()
    {
        if (Time.time >= nextAttackTime) // ȷ�����ܲ�����ȴ��
        {
            
            isCharging = true;
            nextAttackTime = Time.time + cooldownTime; // ���ü�����ȴʱ��
            attackStartTime = Time.time;
            // ������������������Ķ�������Ч
            Debug.Log("������������"); 
            enemyMovement scriptB = GetComponent<enemyMovement>();
            MoveSpeed = scriptB.speed;
            scriptB.speed = 0;
        }
    }

    void PerformAttack()
    {
        isCharging = false;
        isAttacking = true;
        // ����ҷ�����
        Vector3 direction = (player.position - transform.position).normalized;
        // ������������ӳ�̵Ķ�������Ч
        // �����������ƶ��߼������磺
        StartCoroutine(MoveTowardsPlayer(direction)); 
        Debug.Log("�����ڹ�����"); 
        enemyMovement scriptB = GetComponent<enemyMovement>();
        scriptB.speed = MoveSpeed;

    }

    IEnumerator MoveTowardsPlayer(Vector3 direction)
    {
        float travelTime = 0;
        while (travelTime < attackDuration)
        {
            transform.position += direction * attackSpeed * Time.deltaTime;
            travelTime += Time.deltaTime;
            yield return null;
        }
    }

    void EndAttack()
    {
        isAttacking = false;
        // ������������ӹ��������Ķ�������Ч
    }

    void OnCollisionEnter(Collision collision)
    {
        // ����Ƿ��������ڼ��ܵ���ײ
        if (isCharging)
        {
            Die();
        }
    }

    void Die()
    {
        // ɱ��������߼������粥������������Ȼ������
        Debug.Log("���������ڼ��ܵ���ײ��������");
        // �������������������������Ч
        Destroy(gameObject);
    }
}
