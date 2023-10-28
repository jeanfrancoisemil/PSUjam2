using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeleportPlatform : MonoBehaviour
{
    [HideInInspector] public EnemyTeleport[] teleports;

    private void Start()
    {
        teleports = GetComponentsInChildren<EnemyTeleport>();
    }
}
