using UnityEngine;
using UnityEngine.UI;

public class PlayerTarget : MonoBehaviour
{

    public float playerHealth = 100f;
    public int playerHealtUI = 100;

    public Text playerHealthUI;

    public void PlayerTakeDamage(float amount)
    {
        playerHealth -= amount;
        if (playerHealth <= 0f)
        {
            PlayerDie();
        }
    }

    void PlayerDie()
    {
        Destroy(gameObject);
        UpdatePlayerHealthUI();
    }

    private void UpdatePlayerHealthUI()
    {
        playerHealthUI.text = playerHealthUI + "%";
    }
}