using TMPro;
using UnityEngine;

namespace RTSPrototype
{
    public class UnitSelectorUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _commandLabel;

        public void SetCommandState(string state)
        {
            if (_commandLabel != null)
            {
                _commandLabel.text = state;
            }
        }
    }
}
