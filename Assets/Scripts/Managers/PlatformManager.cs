using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : Singleton<PlatformManager>
{
    [SerializeField] private GameObject cubePrefab;
    private GameObject _platform;

    private void Start()
    {
        _platform = Instantiate(cubePrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }

    public void InitLevel(float widthOfField, float lengthOfField)
    {
        _platform.transform.localScale = new Vector3(widthOfField, 1f, lengthOfField);
    }
}
