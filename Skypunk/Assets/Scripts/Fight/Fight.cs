using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Fight : MonoBehaviour
{
    public List<int> pointsPlayer = new List<int>() { 0, 0, 0 };

    public List<int> pointsEnemy = new List<int>() { 0, 0, 0 };

    public FightEffects fightEffects;
    public SceneController controller;
    public Card card;

    public int healthEnemy;

    public bool fight = true;

    private int ironDmg;
    private int healthDmg;

    void Start()
    {
        fight = true;
    }

    public void None()
    {
        StartCoroutine(Battle());
    }

    private IEnumerator Battle()
    {
        fight = false;

        for (var i = 0; i < pointsEnemy.Count; i++)
        {
            pointsEnemy[i] = Random.RandomRange(1, 5);
        }

        fightEffects = new FightEffects();
        fightEffects.panel = GameObject.FindGameObjectWithTag("PanelShield").transform.GetChild(pointsEnemy[0] - 1);

        AttackEnemy();

        yield return new WaitForSeconds(1.5f);

        fightEffects.Destroy();
        fightEffects.Damage(healthDmg, ironDmg);

        yield return new WaitForSeconds(1);

        if (pointsPlayer[0] > 0)
        {
            fightEffects.panel = GameObject.FindGameObjectWithTag("PanelAttack").transform.GetChild(pointsPlayer[0] - 1);

            AttackPlayer();

            yield return new WaitForSeconds(1.5f);

            fightEffects.Destroy();
            fightEffects.Damage(healthDmg, ironDmg);
        }

        yield return new WaitForSeconds(1);

        pointsPlayer = new List<int>() { 0, 0, 0 };

        healthEnemy = card.Health;

        fight = true;

        if (healthEnemy <= 0)
            transform.GetComponent<FightUIManager>().Win();
    }

    private void AttackPlayer()
    {
        ironDmg = 0;
        healthDmg = 0;

        if (pointsPlayer[0] != pointsEnemy[1] && pointsPlayer[0] != pointsEnemy[2] && pointsPlayer[0] != 0)
        {
            for (int i = 0; i < controller.damage; i++)
            {
                if (card.Health == 0)
                    break;

                if (card.Iron > 0)
                {
                    card.Iron--;
                    ironDmg++;
                }
                else
                {
                    card.Health--;
                    healthDmg++;
                }
            }
        }
        else
        {
            fightEffects.AimShield();
        }
    }

    private void AttackEnemy()
    {
        ironDmg = 0;
        healthDmg = 0;
        if (pointsEnemy[0] != pointsPlayer[1] && pointsEnemy[0] != pointsPlayer[2])
        {
            for (int i = 0; i < card.Damage; i++)
            {
                if (controller.health == 0)
                    break;

                if (controller.iron > 0)
                {
                    controller.iron--;
                    ironDmg++;
                }
                else
                {
                    controller.health--;
                    healthDmg++;
                }
            }
        }
        else
            fightEffects.AimShield();
    }
}
