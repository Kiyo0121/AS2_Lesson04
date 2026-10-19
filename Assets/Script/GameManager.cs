using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Spawner _spawner;

    private ISceneState _currentScreenState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spawner = new Spawner();
        _spawner.LoadAsync("Prefabs");

        _currentScreenState = new TitleSceneState();
        _currentScreenState.EnterState();
        
    }

    // Update is called once per frame
    void Update()
    {
        _currentScreenState.ExecuteState();

        if (_spawner.IsLoaded)
        {
            _spawner.Spawn(1);
            _spawner.Spawn("Item");
        }
          
    }

    public void ChangeSceneState(ISceneState nextScene)
    {
        _currentScreenState.ExitState();

        _currentScreenState = nextScene;

        _currentScreenState.EnterState();
    }
}
