using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightUIEnemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer imageEnemy;
    [SerializeField] private Text healthTextEnemy;
    [SerializeField] private Text damageTextEnemy;

    public void UpdateUI(Sprite image, int health, int damage)
    {
        imageEnemy.sprite = image;
        healthTextEnemy.text = health.ToString();
        damageTextEnemy.text = damage.ToString();
    }
}
