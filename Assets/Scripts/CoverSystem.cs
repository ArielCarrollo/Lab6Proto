using UnityEngine;

public class CoverSystem : MonoBehaviour
{
    [SerializeField] private Player player;

    void Start()
    {
        player.onTakeDamage += OnPlayerTakeDamage;
    }

    void OnDestroy()
    {
        player.onTakeDamage -= OnPlayerTakeDamage;
    }

    void OnPlayerTakeDamage(float damage)
    {
        if (player.isCovering)
        {
            damage = 0f; 
            Debug.Log("Damage reduced due to cover.");
        }
        player.health -= damage;
    }
}

