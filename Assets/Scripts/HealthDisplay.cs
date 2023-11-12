using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    Player player;
    TextMeshProUGUI healthText;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        healthText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        healthText.text = player.GetHealth().ToString();
    }
}
