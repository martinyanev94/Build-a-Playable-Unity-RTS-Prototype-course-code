using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private PlaceholderGameState gameState;
    [SerializeField] private TMP_Text goldText;
    [SerializeField] private TMP_Text woodText;
    [SerializeField] private TMP_Text foodText;
    [SerializeField] private TMP_Text detailsText;

    private void Update()
    {
        goldText.text = $"Gold: {gameState.Gold}";
        woodText.text = $"Wood: {gameState.Wood}";
        foodText.text = $"Food: {gameState.Food}";
        detailsText.text = $"{gameState.SelectedUnitName} HP: {gameState.SelectedUnitHealth}";
    }
}
