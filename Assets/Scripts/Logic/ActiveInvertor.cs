using UnityEngine;

public class ActiveInvertor : MonoBehaviour
{
    [SerializeField] private KeyCode[] _keys;
    [SerializeField] private GameObject[] _gameObjects;
    
    private void Update()
    {
        InvertActiveSelfByKeyCodes();
    }

    private void InvertActiveSelfByKeyCodes()
    {
        if (_keys == null)
            return;

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