using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class Main : MonoBehaviour
{
    private UIDocument _document;
    private VisualElement _rootElement;
    private Label _label;
    private Label _label2;
    
    private readonly string _labelText = "Hello There  <sprite name=\"{ICON}\">";
    private readonly string _labelText2 ="<sprite name=\"{ICON2}\"> says hi";
    string _bindingDisplayName;
    
    [Header("Input")]
    [SerializeField] private InputActionReference inputActionReference;
    
    [Header("Panel Settings")]
    [SerializeField] private PanelSettings keyBoardPanelSettings;
    [SerializeField] private PanelSettings gamePadPanelSettings;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();
        _rootElement = _document.rootVisualElement;
        _label = _rootElement.Q<Label>("label");
        _label2 = _rootElement.Q<Label>("label2");

        if (Gamepad.all.Count > 0)
        {
            _document.panelSettings = gamePadPanelSettings;

            _bindingDisplayName = inputActionReference.action.GetBindingDisplayString(1);
        }
        else
        {
            _document.panelSettings = keyBoardPanelSettings;

            _bindingDisplayName = inputActionReference.action.GetBindingDisplayString(0);
        }

        _label.text = _labelText.Replace("{ICON}", _bindingDisplayName);
        _label2.text = _labelText2.Replace("{ICON2}", "b");
    }
}
