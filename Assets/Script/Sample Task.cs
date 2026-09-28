using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SampleTask : MonoBehaviour
{

    private async void Start()
    {
        await UniTask.WaitForSeconds(0.5f);
        for (int i = 0; i < 1000; i++)
        {
            Debug.Log("スタートの処理");
        }

        var handle = Addressables.LoadAssetAsync<GameObject>("PrefabName");
        GameObject Prefab = await handle.ToUniTask();

        Debug.Log($" 読み込み済み => {Prefab.name}");
        Instantiate(Prefab);

        var handles = Addressables.LoadAssetsAsync<GameObject>("Prefabs");
        IList<GameObject> prefabs = await handles.ToUniTask();

        for (int i = 0; i < prefabs.Count; i++)
        {
            Debug.Log($" 読み込み済み => {prefabs[i].name}");
            Instantiate(prefabs[i]);
        }
    }

    void Update()
    {
        Debug.Log("アップデートの処理");
    }
}
