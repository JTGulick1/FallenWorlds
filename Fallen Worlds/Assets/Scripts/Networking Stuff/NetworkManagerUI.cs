using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button clientBtn;
    [SerializeField] private GameObject playersUI;

    private void Awake()
    {
        hostBtn.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
            //playersUI.SetActive(true);
            NetworkManager.Singleton.StartHost();
        });
        clientBtn.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
            //playersUI.SetActive(true);
            NetworkManager.Singleton.StartClient();
        });
    }

}
