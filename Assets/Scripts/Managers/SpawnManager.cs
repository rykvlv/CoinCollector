using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject crystallPrefab;
    [SerializeField] private List<GameObject> items;

    private int _countOfCoins = 0;
    private int _countOfCrystalls = 0;

    private bool _isZeroCoins = false;
    private bool _isZeroCrystalls = false;

    private void Awake()
    {
        Subscribe();
    }

    private void Subscribe()
    {
        GlobalEventManager.instance.CoinChangedEvent += UpdateCountOfCoins;
        GlobalEventManager.instance.ExperienceChangedEvent += UpdateCountOfCrystalls;
    }

    private void UpdateCountOfCoins()
    {
        _countOfCoins--;
        CheckForReset();
    }

    private void UpdateCountOfCrystalls()
    {
        _countOfCrystalls--;
        CheckForReset();
    }

    private void CheckForReset()
    {
        if (_countOfCrystalls == 0)
        {
            _isZeroCrystalls = true;
        }
        if (_countOfCoins == 0)
        {
            _isZeroCoins = true;
        }
        if (_isZeroCoins && _isZeroCrystalls)
        {
            _isZeroCoins = false;
            _isZeroCrystalls = false;
            GlobalEventManager.instance.GameOverEvent.Invoke();
        }
    }

    public void SpawnItems(int maxCoins, int maxCrystalls, int platformWidth, int platformHeight)
    {

        for (int x = -(platformWidth / 2); x < platformWidth / 2; x++)
        {
            for (int z = -(platformHeight / 2); z < platformHeight / 2; z++)
            {
                bool shouldCreateCoin = Random.Range(0, 5) == 0;
                if (shouldCreateCoin && _countOfCoins < maxCoins)
                {
                    Instantiate(coinPrefab, new Vector3(x, 0.9f, z), Quaternion.identity);
                    _countOfCoins++;
                }
                else
                {
                    bool shouldCreateCrystall = Random.Range(0, 5) == 0;
                    if (shouldCreateCrystall && _countOfCrystalls < maxCrystalls)
                    {
                        Instantiate(crystallPrefab, new Vector3(x, 0.9f, z), Quaternion.Euler(15f, 15f, 60f));
                        _countOfCrystalls++;
                    }
                }
            }
        }
    }
}
