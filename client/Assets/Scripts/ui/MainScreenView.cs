using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhantasticCasino.UI
{
    public class MainScreenView : MonoBehaviour
    {
        public void VaultAction()
        {
            Debug.Log("Proceeding to Vault...");
            // go to Vault
        }

        public void CasinoAction()
        {
            Debug.Log("Proceeding to Casino");
            SceneManager.LoadScene((int) EScene.CASINO, LoadSceneMode.Single);
        }
    }
}