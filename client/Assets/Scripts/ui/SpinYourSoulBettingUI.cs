using UnityEngine;
using UnityEngine.UI;

namespace PhantasticCasino.UI
{
    public class SpinYourSoulBettingUI : MonoBehaviour
    {
        private static string WON_LAST_ROUND_TEXT = "Won last round: ";

        public BalancePanel BalancePanel;
        public Text WonLastRoundText;
        public BettingButtonUI[] ButtonUIs;
        public Button SpinButton;

        private float[] _singleBets;

        public float SumBets { get
            {
                float sum = 0;
                foreach (float f in _singleBets)
                {
                    sum += f;
                }
                return sum;
            }
        }

        private void Awake()
        {
            _singleBets = new float[ButtonUIs.Length];
            for (int i = 0; i < ButtonUIs.Length; i++)
            {
                ButtonUIs[i].Index = i;
            }
        }

        public void ResetAllBets()
        {
            for (int i = 0; i < ButtonUIs.Length; i++)
            {
                ButtonUIs[i].ResetBet();
                _singleBets[i] = 0f;
            }
            SpinButton.interactable = false;
        }

        public void ReceiveBet(float amount, int index)
        {
            _singleBets[index] += amount;
            SpinButton.interactable = true;
        }

        public void ApplySpinResult(int targetIndex)
        {
            float result = _singleBets[targetIndex] + (_singleBets[targetIndex] * ButtonUIs[targetIndex].BetValue);

            BalancePanel.IncreaseBalance(result);
            WonLastRoundText.text = WON_LAST_ROUND_TEXT + result.ToString();
            ResetAllBets();
        }
    }
}
