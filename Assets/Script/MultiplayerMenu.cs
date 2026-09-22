using UnityEngine;
using Unity.Netcode;
using TMPro;
using Unity.Netcode.Transports.UTP;

public class MultiplayerMenu : NetworkBehaviour
{
    [SerializeField] private GameObject menuUI;
    [SerializeField] private TMP_InputField joinCodeText;
    [SerializeField] private TMP_Text statusTXT;

    private const string WEBGLConnectionType = "wss";

    public void StartHost()
    {
        //NetworkManager.Singleton.StartHost();
        
        UnityTransport transport = NetworkManager.GetComponent<UnityTransport>();
        transport.UseWebSockets = true;
        NetworkManager.Singleton.StartHost();

        HideUI();
    }

    public void StartClient()
    {
        UnityTransport transport = NetworkManager.GetComponent<UnityTransport>();
        transport.UseWebSockets = true;
        NetworkManager.Singleton.StartClient();

        HideUI();
    }

    public void StartServer()
    {
        UnityTransport transport = NetworkManager.GetComponent<UnityTransport>();
        transport.UseWebSockets = true;
        NetworkManager.Singleton.StartServer();

        HideUI();
    }

    private void ShowUI()
    {
        menuUI.SetActive(true);
    }

    private void HideUI()
    {
        menuUI.SetActive(false);
    }
}
