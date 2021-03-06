﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DronePatrolState : State<DroneMachine>
{
    public static DronePatrolState Instance { get; private set; }

    static DronePatrolState()
    {
        Instance = new DronePatrolState();
    }

    public override void Enter(DroneMachine entity)
    {
        entity.timer = 0.0f;

        if(entity.waypoints.Count == 0)
        {
            entity.pStateMachine.ChangeState(DroneIdleState.Instance);
            return;
        }

        entity.pNavMeshAgent.isStopped = false;
        MoveToNextPatrolPosition(entity);

        entity.animator.SetInteger(entity.animationState, 1);
    }

    public override void Execute(DroneMachine entity)
    {
        if (!entity.pNavMeshAgent.hasPath && entity.pNavMeshAgent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            UpdateWaypointID(entity);
            MoveToNextPatrolPosition(entity);
        }

        //if(entity.recibedaño){
        //entity.machine.changestate(dronehitstate.instance);
        //}

        if (entity.HearsPlayer())
        {
            entity.pStateMachine.ChangeState(DroneAlertState.Instance);
        }

        if (entity.SeesPlayer())
        {
            if (entity.IsInAttackDistance())
                entity.pStateMachine.ChangeState(DroneAttackState.Instance);
            else
                entity.pStateMachine.ChangeState(DroneChaseState.Instance);
        }
    }

    public override void Exit(DroneMachine entity)
    {

    }

    private void MoveToNextPatrolPosition(DroneMachine entity)
    {
        entity.pNavMeshAgent.SetDestination(entity.waypoints[entity.currentWaypointID].position);
    }

    private void UpdateWaypointID(DroneMachine entity)
    {
        entity.currentWaypointID++;

        if (entity.currentWaypointID >= entity.waypoints.Count)
        {
            entity.currentWaypointID = 0;
        }
    }
}
