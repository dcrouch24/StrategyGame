using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    #region Singleton
    public static UnitController instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public List<GameObject> playerUnits = new List<GameObject>();
}
