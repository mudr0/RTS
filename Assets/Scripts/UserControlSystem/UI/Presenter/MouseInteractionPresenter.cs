using UnityEngine;
using System.Linq;

public class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;

    private void Update()
    {
        if (!Input.GetMouseButtonUp(0))
            return;

        var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));

        if (hits.Length == 0)
            return;

        var selectable = hits
            .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
            .Where(c => c != null)
            .FirstOrDefault();

        _selectedObject.SetValue(selectable);
    }
}
