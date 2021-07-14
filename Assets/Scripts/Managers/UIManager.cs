using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Text coinsText;
    [SerializeField] private Text experienceText;
    [SerializeField] private GameObject takeButton;

    private void Awake()
    {
        Subscribe();
    }

    private void Start()
    {
        SetCoinText();
        SetExperienceText();
    }

    public void Subscribe()
    {
        GlobalEventManager.instance.CoinChangedEvent += SetCoinText;
        GlobalEventManager.instance.ExperienceChangedEvent += SetExperienceText;
        GlobalEventManager.instance.ItemTriggeredEvent += ToggleTakeButton;
    }

    public void MainMenuButtonPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void SetCoinText()
    {
        coinsText.text = "Coins: " + GameManager.instance.currentPlayer.GetCoinValue();
    }

    public void SetExperienceText()
    {
        experienceText.text = "Experience: " + GameManager.instance.currentPlayer.GetExperienceValue();
    }

    private void ToggleTakeButton(bool isTriggered)
    {
        takeButton.SetActive(isTriggered);
    }
}
