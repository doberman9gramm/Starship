using UnityEngine;

public class PositionGroup : MonoBehaviour
{
    private Transform[] _transforms;

    private void Awake()
    {
        _transforms = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            _transforms[i] = transform.GetChild(i).GetComponent<Transform>();
    }

    public Transform[] Transforms => _transforms;
}