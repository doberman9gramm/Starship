using UnityEngine;

public class PositionGroup : MonoBehaviour
{
    private Transform[] _transforms;

    private void Awake()
    {
        _transforms = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            if (transform.GetChild(i).TryGetComponent<Position>(out Position position))
                _transforms[i] = position.transform;
            else
                throw new System.Exception("Position group иммет дочерние объекты не €вл€ющиес€ позицией");
    }

    public Transform[] GetTransforms => _transforms;
}