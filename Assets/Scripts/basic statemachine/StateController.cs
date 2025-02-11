using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public ActivePlayerState activePlayerState;
    public BasePlayerState currentPlayerState;

    public float playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPlayerState?.OnUpdate(this);
    }

    public void OnStateEnter(BasePlayerState currentState)
    {
        currentState.OnStart(this);
    }

    public void OnStateExit(BasePlayerState currentState)
    {
        currentState.OnExit(this);
    }

    public void ChangeState(BasePlayerState newState)
    {
        OnStateExit(currentPlayerState);
        currentPlayerState = newState;
        OnStateEnter(currentPlayerState);
        StartCoroutine(tester());
    }

    /*random function
     
    {
     // doing a thing
    ChangeState(activePlayerState)

    
    }*/

    public IEnumerator tester()
    {
        //grab position
        //trigger A
        yield return new WaitForSeconds(1f);
        //trigger B
        yield return new WaitForSeconds(0.5f);
    }
}
