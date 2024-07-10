using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    PlayerManager playerManager;

    public float speed = 10f;  // �ӵ����ƶ��ٶ�
    public float livetime = 5;
    private Vector2 direction; // �ӵ��ķ��з���
    private float haslivetime=0;
    private void Start()
    {
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
    }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            playerManager.GetDamaged(1f + playerManager.inthurt);
            
        }
        //if (other.gameObject.CompareTag("Env"))
        //{
        //    Destroy(gameObject);
        //}
    }

}
