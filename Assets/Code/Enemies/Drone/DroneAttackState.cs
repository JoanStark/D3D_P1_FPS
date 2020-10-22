﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttackState : State<DroneMachine>
{
    public static DroneAttackState Instance { get; private set; }

    static DroneAttackState()
    {
        Instance = new DroneAttackState();
    }


    public override void Enter(DroneMachine entity)
    {
        entity.timer = 0.0f;
    }

    public override void Execute(DroneMachine entity)
    {
        //DamagePlayer

        if (entity.SeesPlayer())
        {
            if (!entity.IsInAttackDistance())
            {
                entity.pStateMachine.ChangeState(DroneChaseState.Instance);
            }
        }
        else
        {
            entity.pStateMachine.ChangeState(DronePatrolState.Instance);
        }
    }

    public override void Exit(DroneMachine entity)
    {

    }
}