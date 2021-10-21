using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface IEnemyFactory
{
    Enemy Create(Health hp);
}