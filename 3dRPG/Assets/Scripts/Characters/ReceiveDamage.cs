using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiveDamage : MonoBehaviour
{
    public float Health;

    public float MaxHealth;

    public GameObject healthBar;

    public GameObject[] loot;

    public Slider healthBarSlider;

    void Start()
    {
        Health = MaxHealth;

        //  for (int i = 0; i < loot.Length; ++i)
        // {
        //      loot[i].GetComponent<CoinsTrigger>().cam = Camera.current;
        //  }

    }

    private void CheckDeath()
    {
        if (Health <= 0)
        {

            Destroy(gameObject);

            for (int i = 0; i < loot.Length; i++)
            {
                Vector2 death_pos = transform.position;

                //GameObject Loot = Instantiate(loot[i], death_pos, Quaternion.identity);

                //Loot.GetComponent<ItemTrigger>().item = Loot;
                //Loot.GetComponent<ItemTrigger>().death = true;
                //Loot.GetComponent<ItemTrigger>().start_pos = death_pos;

                //Loot.GetComponent<ItemTrigger>().start_pos = death_pos;

                Vector2 delta_pos = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
                Vector2 direction = (delta_pos).normalized;

                //Loot.GetComponent<ItemTrigger>().death_discarding = delta_pos.magnitude;

                //Loot.GetComponent<Rigidbody2D>().velocity = direction * 1.8f;
            }
        }
    }

    public void HealCharacter(float heal)
    {
        Health += heal;
        CheckOverHeal();
        healthBarSlider.value = CalculateHealthPercentage();
    }

    private void CheckOverHeal()
    {
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    public void DealDamage(float Damage)
    {
        healthBar.SetActive(true);
        //if (gameObject.GetComponent<AgentScript>())
        //{
       //     gameObject.GetComponent<AgentScript>().aggre = true;
        //    gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = false;
        //}

        Health -= Damage;
        CheckDeath();
        healthBarSlider.value = CalculateHealthPercentage();
    }

    private float CalculateHealthPercentage()
    {
        return (Health / MaxHealth);
    }
}
