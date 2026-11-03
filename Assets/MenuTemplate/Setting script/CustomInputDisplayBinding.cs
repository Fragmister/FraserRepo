using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


[UxmlObject]
public partial class CustomInputDisplayBinding : CustomBinding
{
    public enum Device
    {
        Keyboard,
        Gamepad
    }

    [UxmlAttribute]
    public Device device;

    public CustomInputDisplayBinding()
    {
        updateTrigger = BindingUpdateTrigger.OnSourceChanged;
    }

    protected override void OnDataSourceChanged(in DataSourceContextChanged context)
    {
        VisualElement element = context.targetElement;

        object data = element.dataSource;
        if(element.dataSource == null)
        {
            DataSourceContext parentContext = element.GetHierarchicalDataSourceContext();
            data = parentContext.dataSource;
        }
        if (data != null)
        {
            if (data is InputAction inputAction)
            {
                InputBinding binding = GetInputBindingForDevice(device, inputAction);
                string value = "";
                if (binding.isComposite)
                    {
                    value = binding.name;
                }
                else
                {
                    value = binding.ToDisplayString();
                }
                ConverterGroups.TrySetValueGlobal(ref element, context.bindingId, value, out var errorCode);
            }
        }
    }


    private InputBinding GetInputBindingForDevice(Device device, InputAction inputAction)
    {
        foreach(InputBinding binding in inputAction.bindings)
        {
            if (binding.isPartOfComposite) { continue; }
            if (device == Device.Keyboard && binding.isComposite && binding.path.Contains("Dpad"))
            {
                return binding;
            }
            if (device == Device.Keyboard && binding.groups.Contains("Keyboard"))
            {
                return binding;
            }
            if (device == Device.Gamepad && binding.groups.Contains("Gamepad"))
            {
                return binding;
            }
        }
        return new InputBinding();
    }

    

}
