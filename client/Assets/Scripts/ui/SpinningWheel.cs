using UnityEngine;

namespace PhantasticCasino.UI
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SpinningWheel : MonoBehaviour
    {
        public float AccelerationSteps = 0.5f;
        public float CurrentRotationPower = 0;
        public float MaxRotationPower = 5f;
        public int SpinFrames = 600;

        private Rigidbody2D _rb2d;

        private int _passedFrames = 0;

        private bool _spinning = false;
        private bool _braking = false;
        // Start is called before the first frame update
        void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        public void Spin(float rotationPower)
        {
            MaxRotationPower = Random.value * rotationPower * 2;
            _spinning = true;
        }

        private void FixedUpdate()
        {
            if (_spinning && _passedFrames < SpinFrames)
            {
                if (CurrentRotationPower + AccelerationSteps > MaxRotationPower)
                {
                    _rb2d.AddTorque((MaxRotationPower - CurrentRotationPower) * -1);
                }
                else
                {
                    _rb2d.AddTorque(AccelerationSteps * -1);
                }
                _passedFrames++;
            }
            else if (_passedFrames == SpinFrames)
            {
                StopSpin();
            }

            if (_braking)
            {
                _rb2d.angularDrag += 0.001f;
            }

            if (_rb2d.angularVelocity == 0f)
            {
                _rb2d.angularDrag = 0.5f;
            }
        }

        private void StopSpin()
        {
            _spinning = false;
            _braking = true;
            _passedFrames = 0;
        }
    }
}