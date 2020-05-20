using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public int EnemyMaxHealth = 100;
    public int EnemycurrentHealth;
    float _timer = 0;

    public HealthBar Enemyhealthbar;
    Renderer rend;

    public void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Player") || (col.collider.CompareTag("Bullet")))
        {
            EnemyTakeDamage(20);
            Destroy(col.gameObject);
        }
    }



    void EnemyTakeDamage(int damage)
    {
        EnemycurrentHealth -= damage;
        Enemyhealthbar.SetHealth(EnemycurrentHealth);
    }

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

        EnemycurrentHealth = EnemyMaxHealth;
        Enemyhealthbar.SetMaxHealth(EnemyMaxHealth);

    }

    private void Update()
    {
        if (EnemycurrentHealth <= 0)
        {   
            //Disslove the enemy away by affecting the shader applied to the enemy
            _timer += Time.deltaTime/2  ;
            Debug.Log(_timer);
            float dissolveAmount = _timer;
            //Set value to renderer to control dissolve amount
            rend.material.SetFloat("_Amount", dissolveAmount);
            if (_timer > 1)
            {
                //Once the enemy has dissolved, destroy the gameobject
                Destroy(this.gameObject);
            }
        }
    }

}
