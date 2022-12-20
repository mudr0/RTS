using UnityEngine;

public class MainBuilding : MonoBehaviour, IUnitCreater, ISelectable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;

    [SerializeField] private Transform _unitParent;
    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private float _maxHealth;
    [SerializeField] private Sprite _icon;
    private float _health = 250;

    public void CreateUnit()
    {
        Instantiate(_unitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitParent);
    }
}
