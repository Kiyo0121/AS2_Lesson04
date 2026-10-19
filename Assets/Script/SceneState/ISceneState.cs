using UnityEngine;

public interface ISceneState
{
    void EnterState();

    void ExecuteState();

    void ExitState();
}
