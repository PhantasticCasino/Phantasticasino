using UnityEngine;

namespace PhantasticCasino.UI
{
    public class SpinYourSoulBettingUI : MonoBehaviour
    {
        public BalancePanel BalancePanel;
        public BettingButtonUI[] ButtonUIs;

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
        }

        public void ReceiveBet(float amount, int index)
        {
            _singleBets[index] += amount;
        }

        public void ApplySpinResult(int targetIndex)
        {
            BalancePanel.IncreaseBalance(_singleBets[targetIndex] + (_singleBets[targetIndex] * ButtonUIs[targetIndex].BetValue));
        }
    }
}
