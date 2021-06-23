using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MainPlayerSettings
{
    private GameObject Player;
    public NavMeshAgent NavMeshAgent;
    public Animator EnemyAnimator;
    public BodyPart[] AllBodyParts;
    [Space]

    public float EnemySpeed;
    //public EnemyCreator EnemyCreator;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        NavMeshAgent.SetDestination(Player.transform.position);

        if (Vector3.Distance(gameObject.transform.position, Player.transform.position) > 2.65F)
        {
            EnemyAnimator.SetBool("Attack", false);
            NavMeshAgent.speed = EnemySpeed;
        }
        else
        {
            EnemyAnimator.SetBool("Attack", true);
            NavMeshAgent.speed = 0;
        }
    }

    public void TakeDamage()
    {
        conf.Health -= 1;

        EnemyAnimator.SetTrigger("Hit");

        if (conf.Health <= 0)
        {
            NavMeshAgent.enabled = false;
            EnemyAnimator.enabled = false;
            this.enabled = false;

            foreach (var item in AllBodyParts)
            {
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.GetComponent<Rigidbody>().AddForce(0, 2000, 0);
                item.GetComponent<Rigidbody>().AddForce(-transform.forward * 500);
            }

            Destroy(gameObject, 5F);
        }
    }
}
