using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompReactiveTarget : MonoBehaviour
{

    private int health;

    private void Start()
    {
        health = 10;
    }

    public void ReactToHit()
    {//метод, вызванный сценарием стрельбы
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {//проверяем, есть ли сценарий WanderingAI
            if(health > 0)
            {
                health = health - 1;
                Debug.Log("Health -1!");
            }
            
        }
        if (health == 0)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {//Опрокидываем врага, ждем 1,5 секунды и уничтожаем его
        this.transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);//объект может уничтожить сам себя
    }
}
