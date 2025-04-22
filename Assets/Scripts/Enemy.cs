using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float damageAmount = 10f;
    [SerializeField] private Transform player;
    [SerializeField] private Transform alternateDirection; // Direcci�n alternativa a la que se mover� el enemigo si el jugador se cubre
    private bool isCovering = false;  // Estado de si el jugador est� cubri�ndose

    void Start()
    {
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.onCoverChanged += OnCoverChanged;
        }
    }

    void OnDestroy()
    {
        // Desuscribirse para evitar fugas de memoria
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.onCoverChanged -= OnCoverChanged;
        }
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                Debug.Log("Enemy collided with Player!");
                Attack(player);
            }
        }
    }

    public void Attack(Player target)
    {
        Debug.Log("Enemy attack!");
        target.TakeDamage(damageAmount);
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            if (isCovering)
            {
                // Si el jugador est� cubri�ndose, mover al enemigo en la direcci�n alternativa
                transform.position = Vector3.MoveTowards(transform.position, alternateDirection.position, speed * Time.deltaTime);
            }
            else
            {
                // Si no se est� cubriendo, mover al enemigo hacia el jugador
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }
    }

    // Este m�todo se llamar� cuando el estado de cobertura del jugador cambie
    void OnCoverChanged(bool isCovering)
    {
        this.isCovering = isCovering; // Actualiza el estado de cobertura
        Debug.Log("Enemy knows player is " + (isCovering ? "covering" : "not covering"));
    }
}

