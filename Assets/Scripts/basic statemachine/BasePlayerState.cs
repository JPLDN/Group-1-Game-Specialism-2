using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlayerState : MonoBehaviour
{
    public abstract void OnStart(StateController sC);

    public abstract void OnExit(StateController sC);

    public abstract void OnUpdate(StateController sC);

}
