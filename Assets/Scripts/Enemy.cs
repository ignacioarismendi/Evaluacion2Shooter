using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Enemy Health: " + currentHealth); // Muestra la vida actual del enemigo en la consola
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Lógica para reiniciar la salud y la posición
        currentHealth = maxHealth;
        transform.position = initialPosition;
    }
}
