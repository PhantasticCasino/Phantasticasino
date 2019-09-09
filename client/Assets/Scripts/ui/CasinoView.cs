using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhantasticCasino.UI
{
    public class CasinoView : MonoBehaviour
    {
        public void BackAction()
        {
            SceneManager.LoadScene((int) EScene.MAIN, LoadSceneMode.Single);
        }

        public void SpinYourSoulAction()
        {
            SceneManager.LoadScene((int)EScene.SPIN_YOUR_SOUL, LoadSceneMode.Single);
        }
    }
}