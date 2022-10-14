using UnityEngine;

public class CubeVisibilityHandler : MonoBehaviour
{
    private CubeMover _cubeMover;

    private void Awake() => _cubeMover = GetComponent<CubeMover>();

    private void OnEnable() => _cubeMover.OnCubeStopped += Hide;

    private void OnDisable() => _cubeMover.OnCubeStopped -= Hide;

    private void Hide() => PoolManager.ReleaseObject(gameObject);
}
