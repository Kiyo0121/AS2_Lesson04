using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Spawner
{
    private GameObject[] _prefab;

    public bool IsLoaded = false;

    public async void LoadAsync(string label)
    {
        var handle = Addressables.LoadAssetsAsync<GameObject>(label);
        IList<GameObject> result = await handle. ToUniTask();

        _prefab = result.ToArray();
        IsLoaded = true;
    }

    public void Spawn(int index)
    {
        if (IsLoaded)
        {
            GameObject.Instantiate(_prefab[index]);
        }
        else
        {
            Debug.Log("[Spawner.cs] Now loading...");
        }
    }

    public void Spawn(string AssetName)
    {
        if(IsLoaded)
        {
            for(int index = 0; index < _prefab.Length; index++)
            {
                Debug.Log($"検索中 ...読み組アセット名 : {_prefab[index].name}");

                if(_prefab[index].name == AssetName)
                {
                    GameObject.Instantiate(_prefab[index]);
                    break;
                }
            }
        }
    }
}