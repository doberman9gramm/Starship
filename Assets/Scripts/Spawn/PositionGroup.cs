using UnityEngine;

public class PositionGroup : MonoBehaviour
{
    private Transform[] _transforms;

    private void Awake()
    {
        Position[] positions = GetComponentsInChildren<Position>();// IDK why I cannot take all the transforms at once and install them (-_-)
        _transforms = new Transform[positions.Length];

        for (int i = 0; i < positions.Length; i++)
            _transforms[i] = positions[i].transform;
    }

    public Transform[] GetTransforms => _transforms;
}