using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    GameObject _playerObj;
    PlayerHealth _pH;
    PlayerAction _pA;

    [SerializeField]
    Image _hpBarImage;
    [SerializeField]
    Image _uICTG;
    [SerializeField]
    Image _oHACTG;
    [SerializeField]
    Image _pBCTG;
    void Start()
    {
        _playerObj = GameObject.FindGameObjectWithTag("Player");
        _pH = _playerObj.GetComponent<PlayerHealth>();
        _pA = _playerObj.GetComponent<PlayerAction>();
    }

    void Update()
    {
        _hpBarImage.fillAmount = _pH._playerHealth / 100f;

        _oHACTG.fillAmount = _pA._oHAElapsedTime / _pA._overHeadAttackCT;
        _uICTG.fillAmount = _pA._uIElapsedTime / _pA._upperImpulseCT;
        _pBCTG.fillAmount = _pA._pBElapsedTime / _pA._playerBulletCT;
    }
}
