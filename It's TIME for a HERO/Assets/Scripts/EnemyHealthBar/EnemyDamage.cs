using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public int EnemyMaxHealth = 100;
    public int EnemycurrentHealth;

    public HealthBar Enemyhealthbar;

    public void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Player") || (col.collider.CompareTag("Bullet")))
        {
            EnemyTakeDamage(10);
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
        EnemycurrentHealth = EnemyMaxHealth;
        Enemyhealthbar.SetMaxHealth(EnemyMaxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == ("Enemy"))
                {
                    EnemyTakeDamage(10);
                }
            }
        }


    }
}
