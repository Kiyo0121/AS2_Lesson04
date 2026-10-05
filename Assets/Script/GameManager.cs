using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Spawner _spawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spawner = new Spawner();
        _spawner.LoadAsync("Prefabs");
    }

    // Update is called once per frame
    void Update()
    {
        _spawner.Spawn("Item");   
    }
}
