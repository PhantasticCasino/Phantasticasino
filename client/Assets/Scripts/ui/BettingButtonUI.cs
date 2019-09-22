using UnityEngine;
using UnityEngine.UI;

namespace PhantasticCasino.UI
{
    public class BettingButtonUI : MonoBehaviour
    {
        public int Index { get; set; }

        public float Bet = 0;
        public float BetValue = 0;

        private SpinYourSoulBettingUI _bettingUI;
        private Button _btn;
        private Text _betText;

        private void Awake()
        {
            _bettingUI = GetComponentInParent<SpinYourSoulBettingUI>();
            _btn = GetComponentInChildren<Button>();
            _betText = this.GetClosestComponentInChildren<Text>(false, false);
            _btn.onClick.AddListener(() => AddBetValue());
        }

        public void ResetBet()
        {
            Bet = 0;
            UpdateBetText();
        }
        
        private void AddBetValue()
        {
            Bet += BetValue;
            UpdateBetText();
            _bettingUI.ReceiveBet(BetValue, Index);
        }

        private void UpdateBetText()
        {
            _betText.text = Bet == 0 ? "" : "Bet: " + Bet;
        }
    }
}
