using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int _health;
    private int maxHealth;

    void Start()
    {
        _health = 50;//инициализация переменной
        maxHealth = 50; //инициализация максимального здоровья
    }

    public void Hurt(int damage)
    {
        _health -= damage;//уменьшение здоровья игрока
        if (_health < 0)
        {
            _health = 0;
            Debug.Log("Health: " + _health + "  GAME OVER!");
        }
        else {
            Debug.Log("Health: " + _health);

        }
        ChangeHealth(0);
    }

    public void ChangeHealth(int value)
    { // Дргие сценарии не могут напрямую задавать переменную health,но могут вызвать эту функцию
        _health += value;
        if (_health > maxHealth)
        {
            _health = maxHealth;//не даем жизни подняться выше максимума
            Debug.Log("health: " + _health + "/" + maxHealth);
        }
        else if (_health < 0)
        {
            _health = 0;//не даем уменьшать жизнь в минус
            Debug.Log("Game Over!");
        }
    }

    private void Update()
    {
        PlayerCharacter player = GetComponent<PlayerCharacter>();
        player.ChangeHealth(0);
    }
}

