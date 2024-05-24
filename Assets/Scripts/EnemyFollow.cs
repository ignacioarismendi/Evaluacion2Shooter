using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // El transform del jugador
    public float speed = 5f; // Velocidad de movimiento del enemigo
    public int damage = 10; // Cantidad de daño que causa el enemigo

    void Update()
    {
        // Obtener la dirección hacia el jugador en el plano XZ
        Vector3 direction = new Vector3(player.position.x, transform.position.y, player.position.z) - transform.position;
        direction.Normalize();

        // Mover el enemigo hacia el jugador en el plano XZ
        transform.position += direction * speed * Time.deltaTime;

        // Rotar el enemigo para que mire hacia el jugador
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
