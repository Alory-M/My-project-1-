using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squirrelAttack : MonoBehaviour
{

    Collider2D playerCol;
    Collider2D squirrelCol;
    Collider2D edge;
    PlayerManager playerManager;





    public float Hp;




    public GameObject BulletPrefab;
    private bool isRight = true;
    private bool isUp = false;
    public Transform target; // Ŀ�������Transform���
    public float horizontalDifference; //�ж�����ҵ�ˮƽλ�ò�
    public float verticalDifference; //�ж�����ҵ�ˮƽλ�ò�
    public float interval = 4f; // �������
    public float Attime;//����ʱ��

    public Vector2 direction;


    private void Awake()
    {


        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        squirrelCol = GetComponent<Collider2D>();//������ײ��
        playerCol = GameObject.Find("Player").GetComponent<Collider2D>();
        edge = GameObject.Find("Edge").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(squirrelCol, playerCol, true);
        Physics2D.IgnoreCollision(squirrelCol, edge, true);






        target = GameObject.Find("Player").transform; //��ȡ���λ�ã�ע���Сд
    }

    // Update is called once per frame
    void Update()
    {
        if (playerManager.hasAttackTime <= 0 )
        {
            Physics2D.IgnoreCollision(squirrelCol, playerCol, true);
            //Physics2D.IgnoreCollision(dogColClone, playerCol, true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Physics2D.IgnoreCollision(squirrelCol, playerCol, false);
        }




        if(Hp<=0)Destroy(gameObject);


        //ִ�з���
        Shoot();
    }
    void Shoot()
    {
        // ��ȴʱ��������й���
        if ((Time.time - Attime) >= interval)
        {
            //�����ӵ�Ԥ����
            GameObject bulletObj = Instantiate(BulletPrefab);
            bulletObj.transform.position = transform.position;
            Attime = Time.time;
            //�����ӵ����򣬻�ȡ��ҷ�λ
            Bullet bullet = bulletObj.GetComponent<Bullet>();
            //CheckRelativePosition();
            //if (horizontalDifference* horizontalDifference < verticalDifference* verticalDifference)
            //{
            //    if (isUp)
            //        bullet.SetDirection(Vector2.down);
            //    else bullet.SetDirection(Vector2.up);
            //}
            //else
            //{
            //    if (isRight)
            //        bullet.SetDirection(Vector2.left);
            //    else bullet.SetDirection(Vector2.right);
            //}
            direction=target.position-gameObject.transform.position;
            bullet.SetDirection(direction);


        }
    }





    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="player") 
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
        else
        {
            Hp -= playerManager.damage * playerManager.damageMulti * 2;
        }
        if (Random.Range(0, 100)>playerManager.getMoneyRate)
        {
            playerManager.money++;
        }


    }




    //void CheckRelativePosition()
    //{
    //    // ��ȡ�������������λ��
    //    Vector3 thisPosition = transform.position;
    //    Vector3 targetPosition = target.position;

    //    // ������������֮������λ��
    //    horizontalDifference = thisPosition.x - targetPosition.x;
    //    verticalDifference = thisPosition.y - targetPosition.y;

    //    // �������λ�ø���isRight��isUp��ֵ
    //    isRight = horizontalDifference > 0;
    //    isUp = verticalDifference > 0;
    //}
}
