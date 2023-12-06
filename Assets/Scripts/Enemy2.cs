using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    public Transform Player;
    public float Speed;
    public float EnHealth = 0;
    public float Attack = 0;

    public ParticleSystem blood;

    void Start()
    {
        GetRefrence();
        EnHealth = 6;

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
        agent.SetDestination(Player.position);
        LookAtPlayer();

        if (EnHealth == 0)
        {
            Dead();
        }
    }

    private void LookAtPlayer()
    {
        transform.LookAt(Player);
        Vector3 direction = Player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }

    private void GetRefrence()
    {
        Player = PlayerMovement.Clone;
    }

    public void Dead()
    {
        Destroy(gameObject);
        Debug.Log("Die");
    }

    public void Damaged(float amount)
    {

        EnHealth -= amount;
        blood.Play();
        if (EnHealth <= 0f)
        {
            Dead();
        }
    }

}
