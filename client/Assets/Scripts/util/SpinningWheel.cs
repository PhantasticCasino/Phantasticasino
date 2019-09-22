using PhantasticCasino.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhantasticCasino.Util
{
    [RequireComponent(typeof(RectTransform))]
    public class SpinningWheel : MonoBehaviour
    {
        public SpinYourSoulBettingUI BettingUI;
        public BalancePanel BalancePanel;

        public List<AnimationCurve> animationCurves;
        public List<int> prize;

        private RectTransform _rt;
        private float _anglePerItem;

        private int _fullRotations;
        private int _winningIndex;

        public bool IsSpinning { get; private set; } = false;

        private void Start()
        {
            _rt = GetComponent<RectTransform>();
            _anglePerItem = 360f / prize.Count;
        }

        public void Spin(float rotationPower)
        {
            if (!IsSpinning)
            {
                BalancePanel.DecreaseBalance(BettingUI.SumBets);

                _fullRotations = Random.Range(2, 4);
                Debug.Log("Full rotations: " + _fullRotations);

                _winningIndex = Random.Range(0, prize.Count);
                Debug.Log("Item number: " + _winningIndex);
                Debug.Log("Target prize: " + BettingUI.ButtonUIs[prize[_winningIndex]].BetValue);

                float maxAngle = (360 * _fullRotations) + (_winningIndex * _anglePerItem) + (_anglePerItem / 2);
                Debug.Log("Max angle: " + maxAngle);

                StartCoroutine(SpinTheWheel(5 * _fullRotations, maxAngle));
            }
        }

        private IEnumerator SpinTheWheel(float time, float maxAngle)
        {
            IsSpinning = true;

            float timer = 0.0f;
            float startAngle = transform.eulerAngles.z;
            maxAngle = maxAngle - startAngle;

            int animationCurveNumber = Random.Range(0, animationCurves.Count);
            Debug.Log("Animation Curve No. : " + animationCurveNumber);

            while (timer < time)
            {
                //to calculate rotation
                float angle = maxAngle * animationCurves[animationCurveNumber].Evaluate(timer / time);
                _rt.eulerAngles = new Vector3(0.0f, 0.0f, angle + startAngle);
                timer += Time.deltaTime;
                yield return 0;
            }

            _rt.eulerAngles = new Vector3(0.0f, 0.0f, maxAngle + startAngle);
            IsSpinning = false;

            BettingUI.ApplySpinResult(prize[_winningIndex]);
        }
    }
}