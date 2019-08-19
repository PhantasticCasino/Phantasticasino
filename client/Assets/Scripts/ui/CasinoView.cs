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
            // Go to Spin your Soul
        }
    }
}