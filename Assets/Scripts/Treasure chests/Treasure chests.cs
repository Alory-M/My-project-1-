using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Treasurechests : MonoBehaviour
{


    public float speed;//��ʼ�ٶ�
    public float damage;//Ұ���ʼ������
    public float health;//����
    public float maxHealth;//�������
    public float criticalStrikeRate;//��ʼ������
    public float missRate;//��ʼ������
    public float shield;//����
    public float damageMulti = 1;//�˺�����
    public float hurtMulti = 1;//���˱���


    public string nextname;

    public Button buttons;


    private struct Buffs
    {
        public string sometext;
        public string name;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
