using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private LevelState _levelState;

    public void StartGame(int level)
    {
        CreateNewState();
        float widthOfField = 0f;
        float lengthOfField = 0f;
        int maxCountOfCoins = 0;
        int maxCountOfCrystalls = 0;
        if (level == 1)
        {
            widthOfField = 5f;
            lengthOfField = 5f;
            maxCountOfCoins = 10;
            maxCountOfCrystalls = 10;
        } else if (level == 2)
        {
            widthOfField = 10f;
            lengthOfField = 10f;
            maxCountOfCoins = 30;
            maxCountOfCrystalls = 30;
        } else if (level == 3)
        {
            widthOfField = 20f;
            lengthOfField = 20f;
            maxCountOfCoins = 50;
            maxCountOfCrystalls = 50;
        }

        EditState(widthOfField, lengthOfField, maxCountOfCoins, maxCountOfCrystalls); ;

        SceneManager.LoadScene(1);
    }

    private void EditState(float widthOfField, float lengthOfField, int maxCountOfCoins, int maxCountOfCrystalls)
    {
        _levelState.widthOfField = widthOfField;
        _levelState.lengthOfField = lengthOfField;
        _levelState.maxCounOfCoins = maxCountOfCoins;
        _levelState.maxCountOfCrystalls = maxCountOfCrystalls;
        SaveState();
    }

    private void CreateNewState()
    {
        _levelState = new LevelState();
    }

    private void SaveState()
    {
        StateManager<LevelState>.SaveState(_levelState, "LevelState");
    }
}
