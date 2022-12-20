using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class BottomLeftPresenter : MonoBehaviour
{
    [SerializeField] private Image _selectedImage;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Image _sliderBackGround;
    [SerializeField] private Image _sliderFillArea;
    [SerializeField] private SelectableValue _selectableValue;

    private void Start()
    {
        _selectableValue.OnSelected += OnSelected;
        OnSelected(_selectableValue.CurrentValue);
    }

    private void OnSelected(ISelectable selected)
    {
        _selectedImage.enabled = selected != null;
        _healthSlider.gameObject.SetActive(selected != null);
        _text.enabled = selected != null;

        if(selected != null)
        {
            _selectedImage.sprite = selected.Icon;
            _text.text = $"{selected.Health}/{selected.MaxHealth}";
            _healthSlider.minValue = 0;
            _healthSlider.maxValue = selected.MaxHealth;
            _healthSlider.value = selected.Health;
            var color = Color.Lerp(Color.red, Color.green, selected.Health / (float)selected.MaxHealth);
            _sliderBackGround.color = color * 0.5f;
            _sliderFillArea.color = color;
        }
    }


}
