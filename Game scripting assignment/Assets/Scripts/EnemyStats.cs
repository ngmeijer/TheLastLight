using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    #region Variables

    [SerializeField] public int maxViewDistance = 1;
    [SerializeField] public float rotateSpeed = 25f;
    [SerializeField] public LayerMask playerLayer;
    [SerializeField] public LayerMask groundLayer;

    [SerializeField] public Vector3 rayOffset = new Vector3(1, 0, 0);

    [SerializeField] public int walkRadius = 10;

    #endregion
}
