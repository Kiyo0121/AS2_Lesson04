using UnityEngine;
using UnityEngine.InputSystem;

public class TitleSceneState : ISceneState
{
    private GameManager _gameManager;

    public void EnterState()
    {
        Debug.Log($"{GetType().Name}が始まります");

        _gameManager = GameObject.FindAnyObjectByType<GameManager>();
    }

    public void ExecuteState()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            _gameManager.ChangeSceneState(new GameSceneState());
        }
    }

    public void ExitState()
    {
        Debug.Log($"{GetType().Name}が終わります");
    }
}