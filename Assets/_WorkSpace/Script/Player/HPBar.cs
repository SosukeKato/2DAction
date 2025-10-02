using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    GameObject _playerObj;
    PlayerHealth _pH;

    [SerializeField]
    Image _hpBarImage;
    void Start()
    {
        _playerObj = GameObject.FindGameObjectWithTag("Player");
        _pH = _playerObj.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        _hpBarImage.fillAmount = _pH._playerHealth / 100f;
        Debug.Log($"{_pH._playerHealth / 100}");
    }
}
