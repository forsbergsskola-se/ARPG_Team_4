using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PatrolThreat : MonoBehaviour {
    public Transform[] targetLocationArray;
    private NavMeshAgent _myAgent;

    private Vector3 _targetPosition;
    private int _index = 0;
    void Start()
    {
        _myAgent = GetComponent<NavMeshAgent>();
        // find current target position
        _targetPosition = targetLocationArray[_index].position;
    }
    
    void Update() {

        
        // if there is no next position,
            // begin from the start
            // reverse (go backwards)
            MoveToPosition();
            
            
            
            // later think about go random position
    }

    private void MoveToPosition() {
        _myAgent.SetDestination(_targetPosition);
        
        // if current target position has been reached, get the next target.
        Vector3 currentPosition = this.transform.position;
        
        if (currentPosition.x == _targetPosition.x && currentPosition.y == _targetPosition.y) {
            //abs(currentPosition.x - _targetPosition.x) < 0.0001
            Debug.Log("Arrived at location");
            _index++; //update index position
            _targetPosition = targetLocationArray[_index].position;
        }
        else {
            Debug.Log("Not at location yet");
        }
    }
    /*
     *
     * foreach (var t in targetLocationArray) {
            Vector3 v = t.position;
            myAgent.SetDestination(v);
        }
     * */
     
}
