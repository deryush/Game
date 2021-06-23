using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MainPlayerSettings
{
    public GameObject Finish;
    public Text LifesCount;

    public PlayerMove PlayerMove;

    private void Start()
    {
        LifesCount.text ="Lifes: " + conf.Health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyFoot") && conf.Health > 0)
        {
            TakeDamagePlayer();
        }
    }

    private void Update()
    {
        LifesCount.text = "Lifes: " + conf.Health.ToString();
    }

    public void TakeDamagePlayer()
    {
        conf.Health -= 1;
        if (conf.Health <= 0)
        {
            PlayerMove.enabled = false;
            Finish.SetActive(true);
        }
    }
}
