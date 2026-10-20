using TMPro;
using UnityEngine;

namespace RTSPrototype.Progression
{
    public sealed class GameOutcomeController : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPopup;
        [SerializeField] private TMP_Text gameOverText;

        private bool objectivesComplete;
        private bool defenseAlive = true;
        private bool resolved;

        public void SetObjectivesComplete(bool value) => objectivesComplete = value;
        public void SetDefenseAlive(bool value) => defenseAlive = value;

        public void CommitState()
        {
            if (resolved) return;
            if (!defenseAlive) { Resolve(false); return; }
            if (objectivesComplete) Resolve(true);
        }

        public void Reset()
        {
            resolved = false;
            objectivesComplete = false;
            defenseAlive = true;
            gameOverPopup.SetActive(false);
            Time.timeScale = 1f;
        }

        private void Resolve(bool playerWin)
        {
            resolved = true;
            gameOverText.text = playerWin ? "Victory" : "Defeat";
            gameOverPopup.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
