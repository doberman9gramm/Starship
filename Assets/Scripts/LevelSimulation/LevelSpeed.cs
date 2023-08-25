using UnityEngine;

public class LevelSpeed : MonoBehaviour
{
    private static float _speed = 250f;

    public static float GetSpeed => _speed;

    private void Start()
    {
        if (_speed < 0)
            throw new System.Exception("Error! Speed value < 0 !!!");
        gameObject.SetActive(false);
    }
}