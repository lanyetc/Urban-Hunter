using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PocketDroidsSceneManager : MonoBehaviour
{
    public abstract void PlayerTapped(GameObject player);
    public abstract void MonsterTapped(GameObject monster);
    public abstract void CollectatbleTapped(GameObject collectable);
}
