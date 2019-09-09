using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhantasticCasino.UI
{
    public class SpinYouSoulView : MonoBehaviour
    {
        private SpinningWheel _spinningWheel;

        private void Start()
        {
            _spinningWheel = GameObject.Find("Wheel")?.GetComponent<SpinningWheel>();
        }

        public void BackAction()
        {
            Debug.Log("Back to Casino");
            SceneManager.LoadScene((int)EScene.CASINO, LoadSceneMode.Single);
        }

        public void SpinAction()
        {
            Debug.Log("Spin your Soul!");
            // TODO: Calculate random spin force with server
            _spinningWheel.Spin(Random.value);
        }
    }
}