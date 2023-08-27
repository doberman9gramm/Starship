using UnityEngine;

public class LevelSpeed : MonoBehaviour
{
    private static float _speed = 250f;

    public static float GetSpeed => _speed;

    private void Awake()
    {
        CheckValue();
    }

    private void CheckValue()
    {
        if (_speed < 0)
            throw new System.Exception("Error! Speed value < 0 ");
    }
}