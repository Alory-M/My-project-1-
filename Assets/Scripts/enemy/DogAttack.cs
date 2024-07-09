using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAttack : MonoBehaviour
{
    Collider2D playerCol;
    Collider2D dogCol;
    


    PlayerManager playerManager;


    public Transform target; // ��ҵ�Transform���
    public float attackRange = 5.0f; // ���˵Ĺ�����Χ

    public float attackCooldown = 2.0f; // ������ȴʱ��
    private float nextAttackTime = 0.0f; // �´ο��Թ�����ʱ��

    public float Hp;

    private void Awake()
    {
        target = GameObject.Find("Player").transform;


        playerManager=GameObject.Find("Player").GetComponent<PlayerManager>();


        dogCol = GetComponent<Collider2D>();//������ײ��
        playerCol = GameObject.Find("Player").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(dogCol, playerCol, true);


    }
    private void Update()
    {
        if(Hp<=0)Destroy(gameObject);
        if (playerManager.hasAttackTime <= 0)
        {
            Physics2D.IgnoreCollision(dogCol, playerCol, true);
            //Physics2D.IgnoreCollision(dogColClone, playerCol, true);
        }
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
        if (Input.GetMouseButtonDown(0)) 
        {
            Physics2D.IgnoreCollision(dogCol, playerCol, false);
        }
    }

    private void AttackPlayer()
    {
        // ����ʵ�ֹ����߼������磺
        // - ���ö���ϵͳ���Ź�������
        // - ���������˺�
        //Debug.Log("���˽�ս������ң�");
        playerManager.GetDamaged(1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            GetDamaged();
        }
    }

    private void GetDamaged()
    {
        if (Random.Range(0, 100) > playerManager.criticalStrikeRate)
        {
            Hp -= playerManager.damage * playerManager.damageMulti;
        }
        else {
            Hp -= playerManager.damage * playerManager.damageMulti*2;
        }


    }
}