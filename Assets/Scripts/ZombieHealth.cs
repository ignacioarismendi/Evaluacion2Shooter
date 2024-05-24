using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con UI

public class ZombieHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Animator animator;
    public Rigidbody rb;
    public float flyForce = 500f;
    public Text healthText; // Referencia al objeto de texto UI

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        UpdateHealthText(); // Actualizar el texto al inicio
    }

    void Update()
    {
        // Aquí puedes agregar cualquier lógica adicional que necesites
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Vida restante del zombie: " + currentHealth); // Imprimir vida en la consola
        UpdateHealthText(); // Actualizar el texto cuando el zombie recibe daño
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Desactivar el script de seguimiento o movimiento
        GetComponent<EnemyFollow>().enabled = false;
        
        // Activar la animación de muerte (si tienes una)
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        // Aplicar una fuerza hacia arriba para que "vuele"
        if (rb != null)
        {
            rb.AddForce(Vector3.up * flyForce);
        }

        // Opcional: Destruir el objeto después de un tiempo
        Destroy(gameObject, 2f);
    }

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Vida del Zombie: " + currentHealth;
        }
    }
}
