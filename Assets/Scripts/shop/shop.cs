using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class shop : MonoBehaviour
{


    public float speed;//��ʼ�ٶ�
    public float damage;//Ұ���ʼ������
    public float health;//����
    public float maxHealth;//�������
    public float criticalStrikeRate;//��ʼ������
    public float missRate;//��ʼ������
    public float shield;//����
    public float damageMulti;//�˺�����
    public float hurtMulti;//���˱���
    //�������¼�����
    public float getMoneyRate;//��ҵ�����
    public float intShield;//��ɢ����Ҽ���
    public float inthurt;//��ɢ�͹����˺��ӳ�
    public float monsterHealth;//����Ѫ���ӳ�
    public float monsterMissRate;//����������
    public float intMonsterShield;//��ɢ�͹������


    public string nextname;
    public int money;
    public float counttime;
    public GameObject lockmoney;

    // Start is called before the first frame update
    void Start()
    {
        getdata();
        counttime = 0;
        money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(lockmoney.activeSelf == true)
        {
            counttime += Time.deltaTime;
            if(counttime > 1f )
            {
                lockmoney.SetActive(false);
                counttime = 0f;
            }
        }
    }


    public void whenbutton1()
    {
        if (money > 2)
        {

            money -= 2;
            loaddate();
            SceneManager.LoadScene(nextname);
        }
        else
        {
            lockmoney.SetActive(true);

        }
    }
    public void whenbutton2()
    {

        if (money > 5)
        {

            money -= 5;
            loaddate();
            SceneManager.LoadScene(nextname);
        }
        else
        {
            lockmoney.SetActive(true);

        }
    }
   public void whenbutton3()
    {
        if (money > 7)
        {

            money -= 7;
            loaddate();
            SceneManager.LoadScene(nextname);
        }
        else
        {
            lockmoney.SetActive(true);

        }
    }


    void getdata()
    {
        speed = PlayerPrefs.GetFloat("1", 2f);
        damage = PlayerPrefs.GetFloat("2", 1f);
        health = PlayerPrefs.GetFloat("3", 3f);
        maxHealth = PlayerPrefs.GetFloat("4", 5f);
        criticalStrikeRate = PlayerPrefs.GetFloat("5", 5f);
        missRate = PlayerPrefs.GetFloat("6", 5f);
        shield = PlayerPrefs.GetFloat("7", 0f);
        damageMulti = PlayerPrefs.GetFloat("8", 1f);
        hurtMulti = PlayerPrefs.GetFloat("9", 1f);
        //��������
        getMoneyRate = PlayerPrefs.GetFloat("10", 60f);
        intShield = PlayerPrefs.GetFloat("11", 0f);
        inthurt = PlayerPrefs.GetFloat("12", 0f);
        monsterHealth = PlayerPrefs.GetFloat("13", 1f);
        monsterMissRate = PlayerPrefs.GetFloat("14", 0f);
        intMonsterShield = PlayerPrefs.GetFloat("15", 0f);

    }


    public void loaddate()
    {
        PlayerPrefs.SetFloat("1", speed);
        PlayerPrefs.SetFloat("2", damage);
        PlayerPrefs.SetFloat("3", health);
        PlayerPrefs.SetFloat("4", maxHealth);
        PlayerPrefs.SetFloat("5", criticalStrikeRate);
        PlayerPrefs.SetFloat("6", missRate);
        PlayerPrefs.SetFloat("7", shield);
        PlayerPrefs.SetFloat("8", damageMulti);
        PlayerPrefs.SetFloat("9", hurtMulti);
        //��������
        PlayerPrefs.SetFloat("10", getMoneyRate);
        PlayerPrefs.SetFloat("11", intShield);
        PlayerPrefs.SetFloat("12", inthurt);
        PlayerPrefs.SetFloat("13", monsterHealth);
        PlayerPrefs.SetFloat("14", monsterMissRate);
        PlayerPrefs.SetFloat("15", intMonsterShield);


    }



}
