using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 10f;  // �ӵ����ƶ��ٶ�
    public float livetime = 5;
    private Vector2 direction; // �ӵ��ķ��з���
    private float haslivetime=0;

    void Update()
    {
        haslivetime += Time.deltaTime;
        if (haslivetime > livetime)
        {
            Destroy(gameObject);
        }
        else
        {
            // �ӵ������趨�ķ��з����ƶ�
            transform.Translate(direction * speed * Time.deltaTime);
        }
        
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized; // �����µķ��з��򣬲�ȷ���ǵ�λ����
    }

}
