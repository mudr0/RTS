using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlinePresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    private OutlineView[] _outline;
    private ISelectable _currentSelectable;

    private void Start()
    {
        _selectable.OnSelected += OnSelected;
        OnSelected(_selectable.CurrentValue);
    }

    private void OnSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
            return;

        _currentSelectable = selectable;
        SetSelected(_outline, false);
        _outline = null;
    
        if (selectable != null)
        {
            _outline = (selectable as Component).GetComponentsInParent<OutlineView>();
            SetSelected(_outline, true);
        }

        static void SetSelected(OutlineView[] selectors, bool value)
        {
            if (selectors != null)
            {
                for (int i = 0; i < selectors.Length; i++)
                {
                    selectors[i].GetComponent<OutlineView>().enabled = value;
                }
            }
        }
    }

}
