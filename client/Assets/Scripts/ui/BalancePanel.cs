using UnityEngine;
using UnityEngine.UI;

namespace PhantasticCasino.UI
{
    [RequireComponent(typeof(Text))]
    public class BalancePanel : MonoBehaviour
    {
        private Text _text;

        public float Balance = 200f;

        private void Awake()
        {
            _text = GetComponent<Text>();
            UpdateBalanceText();
        }

        public void IncreaseBalance(float amount)
        {
            Balance += amount;
            UpdateBalanceText();
        }

        public void DecreaseBalance(float amount)
        {
            Balance -= amount;
            UpdateBalanceText();
        }

        private void UpdateBalanceText()
        {
            _text.text = Balance.ToString();
        }
    }
}