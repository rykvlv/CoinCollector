using UnityEngine;
using System.IO;

public static class StateManager<T> where T : IState
{
    public static void SaveState(T state, string name)
    {
        string json = JsonUtility.ToJson(state);
        File.WriteAllText(name + ".json", json);
    }

    public static T LoadState(string name)
    {
        T state;
        try
        {
            state = JsonUtility.FromJson<T>(File.ReadAllText(name + ".json"));
        }
        catch
        {
            state = default;
        }
        return state;
    }
}
