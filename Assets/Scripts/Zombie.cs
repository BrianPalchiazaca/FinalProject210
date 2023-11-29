using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    public Transform Player;
    public float Speed;
    public float EnHealth = 0;
    public float Attack = 0;

    public PlayerMovement player;
    public ParticleSystem blood;


    //public ParticleSystem Blood;

    void Start()
    {
        GetRefrence();
        EnHealth = 3;

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
        //player.AddScore();
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
