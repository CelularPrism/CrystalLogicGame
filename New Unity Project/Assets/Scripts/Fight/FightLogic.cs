using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightLogic : MonoBehaviour
{
    public Card CheckCard(Card card)
    {
        if (card.dataCard.card != DataCard.classCard.Enemy)
        {
            DataCard[] dataCards = Resources.LoadAll<DataCard>("ScriptableObjects/Cards/Enemy");
            int num = Random.Range(0, dataCards.Length - 1);
            DataCard dataCard = dataCards[num];
            int damage = Random.Range(dataCard.minDamage, dataCard.maxDamage);
            int health = Random.Range(dataCard.minHealth, dataCard.maxHealth);

            card.dataCard = dataCard;
            card.Health = health;
            card.Damage = damage;
        }
        return card;
    }
}
