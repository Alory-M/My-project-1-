using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngrySquirrelAttack1 : MonoBehaviour
{
    public GameObject BulletPrefab;
    private bool isRight = true;
    private bool isUp = false;
    public Transform target; // Ŀ�������Transform���
    public float horizontalDifference; //�ж�����ҵ�ˮƽλ�ò�
    public float verticalDifference; //�ж�����ҵ�ˮƽλ�ò�
    public float interval = 4f; // �������
    public float Attime;//����ʱ��
    public Vector2 bulletDir;
    private int actionCount = 0;// �������ִ�еĴ���
    private int totalActions = 3;// �ܹ���Ҫִ�еĴ�����������ö�ɹ���
    public float emitInterval = 1f;// ����ʱ����
    private void Awake()
    {
        target = GameObject.Find("Player").transform; //��ȡ���λ�ã�ע���Сд
    }

    // Update is called once per frame
    void Update()
    {
        //ִ�з���
        Shoot3();
    }
    void Shoot3()
    {
        // ��ȴʱ�����ִ�з���
        if ((Time.time - Attime) >= interval)
        {
            Attime = Time.time;
            // ��ʼִ��Coroutine��������
            StartCoroutine(PerformAction());
            actionCount = 0;
        }
    }
    //ʱ������ѭ����ÿ�����뷢��һ��
    IEnumerator PerformAction()
    {
        // ������λ�ã������ɹ��������ҷ���
        CheckRelativePosition();
        if (horizontalDifference * horizontalDifference < verticalDifference * verticalDifference)
        {
            if (isUp)
                bulletDir = Vector2.down;
            else bulletDir = Vector2.up;
        }
        else
        {
            if (isRight)
                bulletDir = Vector2.left;
            else bulletDir = Vector2.right;
        }
        // �ڹ������������½��м��ʱ�乥��
        while (actionCount < totalActions)
        {
            
            GameObject bulletObj = Instantiate(BulletPrefab);
            bulletObj.transform.position = transform.position;
            Bullet bullet = bulletObj.GetComponent<Bullet>();
            bullet.SetDirection(bulletDir);

            // �ȴ�1��
            yield return new WaitForSeconds(emitInterval);

            // ������һ����ʾ������ִ��һ��
            actionCount++;
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
