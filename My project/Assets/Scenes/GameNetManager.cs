using Unity.Netcode;
using UnityEngine;

public class GameNetManager : MonoBehaviour
{

    private NetworkManager m_NetworkManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        m_NetworkManager = GetComponent<NetworkManager>();
    }
}
