using UnityEngine;

public sealed class SelectedUnitDetailsUI : MonoBehaviour
{
    [SerializeField] private SelectedUnitView[] _unitViews;
    [SerializeField] private UnitPortraitView _portrait;

    private void OnEnable()
    {
        MessageQueueManager.Instance.Subscribe<UpdateDetailsMessage>(OnDetailsUpdated);
    }

    private void OnDisable()
    {
        if (MessageQueueManager.Instance != null)
            MessageQueueManager.Instance.Unsubscribe<UpdateDetailsMessage>(OnDetailsUpdated);
    }

    private void OnDetailsUpdated(UpdateDetailsMessage message)
    {
        foreach (SelectedUnitView view in _unitViews)
            view.gameObject.SetActive(false);

        for (int i = 0; i < message.Units.Count && i < _unitViews.Length; i++)
        {
            _unitViews[i].Bind(message.Units[i]);
            _unitViews[i].gameObject.SetActive(true);
        }

        _portrait.SetModel(message.Model);
    }
}
