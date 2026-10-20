using UnityEngine;
using UnityEngine.UI;

public sealed class SelectedUnitActionsUI : MonoBehaviour
{
    [SerializeField] private Button _moveButton;
    [SerializeField] private Button _attackButton;
    [SerializeField] private Button _defendButton;
    [SerializeField] private Button _collectButton;

    private void OnEnable()
    {
        MessageQueueManager.Instance.Subscribe<UpdateActionsMessage>(OnActionsUpdated);
    }

    private void OnDisable()
    {
        if (MessageQueueManager.Instance != null)
            MessageQueueManager.Instance.Unsubscribe<UpdateActionsMessage>(OnActionsUpdated);
    }

    private void OnActionsUpdated(UpdateActionsMessage message)
    {
        SetActionVisible(_moveButton, (message.Actions & ActionType.Move) != 0);
        SetActionVisible(_attackButton, (message.Actions & ActionType.Attack) != 0);
        SetActionVisible(_defendButton, (message.Actions & ActionType.Defend) != 0);
        SetActionVisible(_collectButton, (message.Actions & ActionType.Collect) != 0);
    }

    private static void SetActionVisible(Button button, bool visible)
    {
        button.gameObject.SetActive(visible);
    }
}
