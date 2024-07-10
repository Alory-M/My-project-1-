using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squirrelAttack : MonoBehaviour
{
    public GameObject BulletPrefab;
    private bool isRight = true;
    private bool isUp = false;
    public Transform target; // Ŀ�������Transform���
    public float horizontalDifference; //�ж�����ҵ�ˮƽλ�ò�
    public float verticalDifference; //�ж�����ҵ�ˮƽλ�ò�
    public float interval = 4f; // �������
    public float Attime;//����ʱ��

    private void Awake()
    {
        target = GameObject.Find("Player").transform; //��ȡ���λ�ã�ע���Сд
    }

    // Update is called once per frame
    void Update()
    {
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
            CheckRelativePosition();
            if (horizontalDifference* horizontalDifference < verticalDifference* verticalDifference)
            {
                if (isUp)
                    bullet.SetDirection(Vector2.down);
                else bullet.SetDirection(Vector2.up);
            }
            else
            {
                if (isRight)
                    bullet.SetDirection(Vector2.left);
                else bullet.SetDirection(Vector2.right);
            }

        }
    }
    void CheckRelativePosition()
    {
        // ��ȡ�������������λ��
        Vector3 thisPosition = transform.position;
        Vector3 targetPosition = target.position;

        // ������������֮������λ��
        horizontalDifference = thisPosition.x - targetPosition.x;
        verticalDifference = thisPosition.y - targetPosition.y;

        // �������λ�ø���isRight��isUp��ֵ
        isRight = horizontalDifference > 0;
        isUp = verticalDifference > 0;
    }
}
