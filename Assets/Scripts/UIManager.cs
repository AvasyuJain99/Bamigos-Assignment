using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI coinCollectedText;
    public Slider healthSlider;
    [SerializeField]
    private GameObject gameOverPanel;
    private void Awake()
    {
        Instance = this;
    }
    public void ActivateGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
}
