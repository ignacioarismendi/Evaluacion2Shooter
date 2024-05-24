using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    public Text healthText; // Asigna el componente de texto desde el Inspector
    public PlayerHealth playerHealth; // Asigna el componente PlayerHealth desde el Inspector

    void Update()
    {
        if (playerHealth != null && healthText != null)
        {
            healthText.text = "Vida: " + playerHealth.GetCurrentHealth().ToString();
        }
    }
}
