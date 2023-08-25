using System.Collections.Generic;
using UnityEngine;

public class DisablePoolAdder : MonoBehaviour
{
    private List<DisablePoolAdder> _disablePool;
    private bool _isInit = false;

    public void Init(List<DisablePoolAdder> disablePool)
    {
        if (_isInit == false)
        {
            _disablePool = disablePool;
            _isInit = true;
            return;
        }
        throw new System.Exception("Класс уже был проинициализирован!");
    }

    private void OnDisable()
    {
        if (this != null)
            _disablePool.Add(this);
    }
}
