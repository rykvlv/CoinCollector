using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private CameraFollow cameraFollow;

    public PlayerManager currentPlayer;

    private LevelState _levelState;
    private float widthOfField = 0f;
    private float lengthOfField = 0f;
    private int maxCountOfCoins = 0;
    private int maxCountOfCrystalls = 0;

    private void Awake()
    {
        if (!TryLoadLevelState())
        {
            CreateNewLevelState();
        }
        widthOfField = _levelState.widthOfField;
        lengthOfField = _levelState.lengthOfField;
        maxCountOfCoins = _levelState.maxCounOfCoins;
        maxCountOfCrystalls = _levelState.maxCountOfCrystalls;
        Subscribe();
    }

    private void Start()
    {
        Debug.Log("Start");
        PlatformManager.instance.InitLevel(widthOfField, lengthOfField);
        SpawnManager.instance.SpawnItems(maxCountOfCoins, maxCountOfCrystalls, (int)(widthOfField-1), (int)(lengthOfField-1));

        GameObject newPlayer = Instantiate(playerPrefab, new Vector3(0f, 1f, 0f), Quaternion.identity);
        currentPlayer = newPlayer.GetComponent<PlayerManager>();
    }

    private void Update()
    {
        cameraFollow.cameraTarget = currentPlayer.cameraFollowTarget;
    }

    private void Subscribe()
    {
        GlobalEventManager.instance.GameOverEvent += Reset;
    }

    private void Reset()
    {
        SpawnManager.instance.SpawnItems(maxCountOfCoins, maxCountOfCrystalls, (int)(widthOfField - 1), (int)(lengthOfField - 1));
    }

    private bool TryLoadLevelState()
    {
        _levelState = StateManager<LevelState>.LoadState("LevelState");
        if (_levelState != null) return true;

        return false;
    }

    private void CreateNewLevelState()
    {
        _levelState = new LevelState();
        SaveLevelState();

    }

    private void SaveLevelState()
    {
        StateManager<LevelState>.SaveState(_levelState, "LevelState");
    }
}
