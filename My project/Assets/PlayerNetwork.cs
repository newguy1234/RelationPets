using UnityEngine;
using Unity.Netcode;
using TMPro;
using UnityEngine.UI;

public class PlayerNetwork : NetworkBehaviour
{
    [SerializeField] Button add1Btn;
    [SerializeField] private GameObject textObject;
    private TextMeshProUGUI syncedText;
    private NetworkVariable<int> totalNumber = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone);

    public override void OnNetworkSpawn()
    {
        totalNumber.OnValueChanged += (int previousValue, int newValue) =>
        {
            syncedText.text = "Number: " + totalNumber.Value.ToString();
        };
    }

    private void Awake()
    {
        add1Btn = GameObject.Find("Button").GetComponent<Button>();  
        add1Btn.onClick.AddListener(() =>
        {
            totalNumber.Value += 1;
        });
        textObject = GameObject.Find("Synced Number");
        syncedText = textObject.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (!IsOwner) return;

        Vector3 moveDir = new Vector3(0,0,0);

        if (Input.GetKey(KeyCode.W)) moveDir.y = +1f;
        if (Input.GetKey(KeyCode.S)) moveDir.y = -1f;
        if (Input.GetKey(KeyCode.A)) moveDir.x = -1f;
        if (Input.GetKey(KeyCode.D)) moveDir.x = +1f;

        float moveSpeed = 3f;

        transform.position += moveDir * moveSpeed * Time.deltaTime;


    }
}
