using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightUIPlayer : MonoBehaviour
{
    [SerializeField] private Text healthTextPlayer;
    [SerializeField] private Text ironTextPlayer;
    [SerializeField] private Text dmgTextPlayer;
    
    public void UpdateUIPlayer(float health, float iron, int damage)
    {
        healthTextPlayer.text = health.ToString();
        ironTextPlayer.text = iron.ToString();
        dmgTextPlayer.text = damage.ToString();
    }
}
