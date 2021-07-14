using UnityEngine;

public class PlayerManager : MonoBehaviour, IResettable
{
    [SerializeField] private int addableCoins = 1;
    [SerializeField] private int addableExperience = 100;

    public Transform cameraFollowTarget;
    
    private PlayerState _playerState;

    private void Awake()
    { 
        if (!TryLoadState())
        {
            CreateNewState();
        }
        Subscribe();
        
    }

    private void Update()
    {
        transform.Translate(new Vector3(InputManager.instance.GetMoveInputs().Item1, 0, InputManager.instance.GetMoveInputs().Item2) * _playerState.MoveSpeed * Time.deltaTime);
    }

    private void Subscribe()
    {
        GlobalEventManager.instance.CoinChangedEvent += AddCoin;
        GlobalEventManager.instance.ExperienceChangedEvent += AddXP;
    }

    public void AddCoin()
    {
        _playerState.Coins += addableCoins;
        SaveState();
    }

    public void AddXP()
    {
        _playerState.Experience += addableExperience;
        SaveState();
    }

    public void SetSpeed(float speed)
    {
        _playerState.MoveSpeed = speed;
    }

    public int GetCoinValue()
    {
        return _playerState.Coins;
    }

    public int GetExperienceValue()
    {
        return _playerState.Experience;
    }

    public void Reset()
    {
        _playerState.Reset();
    }

    private bool TryLoadState()
    {
        _playerState = StateManager<PlayerState>.LoadState("playerManager");
        if (_playerState != null) return true;

        return false;
    }

    public void SaveState()
    {
        StateManager<PlayerState>.SaveState(_playerState, "playerManager");
    }

    private void CreateNewState()
    {
        _playerState = new PlayerState();
        SaveState();
    }

}
