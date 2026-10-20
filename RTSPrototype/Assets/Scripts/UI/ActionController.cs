using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField] private PlaceholderGameState gameState;
    [SerializeField] private Button collectButton;
    [SerializeField] private int collectCost = 25;

    private void Awake()
    {
        collectButton.onClick.AddListener(Collect);
    }

    private void Collect()
    {
        gameState.SpendGold(collectCost);
    }

    private void OnDestroy()
    {
        collectButton.onClick.RemoveListener(Collect);
    }
}
