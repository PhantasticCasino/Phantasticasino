using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PhantasticCasino.UI
{
    /// <summary>
    /// Handler class for the login view
    /// </summary>
    [RequireComponent(typeof(Canvas))]
    public class LoginView : MonoBehaviour
    {
        public InputField _walletField;
        public InputField _passwdField;

        void Awake()
        {
            GameObject WalletFieldObj = GameObject.Find("Wallet");
            GameObject PasswordFieldObj = GameObject.Find("Password");

            if (WalletFieldObj == null || PasswordFieldObj == null)
                throw new MissingReferenceException("GameObjects missing!");

            _walletField = WalletFieldObj.GetComponent<InputField>();
            _passwdField = PasswordFieldObj.GetComponent<InputField>();
            if (_walletField == null || _passwdField == null)
                throw new MissingComponentException("GameObjects have missing InputField components!");
        }

        public void CreateWallet()
        {
            Debug.Log("Creating new account with wallet...");
            // Proceed to Registration screen
        }

        public void Login()
        {
            // TODO: Perform Login request to server
            string wallet = _walletField.text;
            string password = _passwdField.text;
            // bool success = LoginAction(wallet, password);

            Debug.Log("Logging in...");
            bool success = true;
            if (success)
            {
                Debug.Log("Login successful!");
                SceneManager.LoadScene((int) EScene.MAIN, LoadSceneMode.Single);
            }
        }
    }
}