using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image coverImage;  
    public Sprite coveringSprite;  
    public Sprite uncoveredSprite;  
    public TextMeshProUGUI healthText;
    public Player player;

    void Start()
    {
        if (player != null)
        {
            player.onCoverChanged += OnCoverChanged;
        }
        UpdateHealthUI();
    }
    void OnDestroy()
    {
        if (player != null)
        {
            player.onCoverChanged -= OnCoverChanged;
        }
    }
    void Update()
    {
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (player != null)
        {
            healthText.text = "Health: " + player.health.ToString();
        }
    }
    void OnCoverChanged(bool isCovering)
    {
        if (isCovering)
        {
            coverImage.sprite = coveringSprite; 
        }
        else
        {
            coverImage.sprite = uncoveredSprite;  
        }
    }
}

