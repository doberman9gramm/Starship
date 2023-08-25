using UnityEngine;

public class ActiveSelfInvertor : MonoBehaviour
{
    [SerializeField] private KeyCode[] _keys;
    [SerializeField] private GameObject[] _gameObjects;
    
    private void Update()
    {
        InvertActiveSelfByKeyCode();
    }

    private void InvertActiveSelfByKeyCode()
    {
        foreach (var key in _keys)
            if (Input.GetKeyDown(key))
                Invert();
    }

    public void Invert()
    {
        foreach (var gameObject in _gameObjects)
            gameObject.SetActive( !gameObject.activeSelf);
    }
}