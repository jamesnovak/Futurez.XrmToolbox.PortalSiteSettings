using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Futurez.XrmToolBox
{
    public class UpDownValueEditor : UITypeEditor
    {
        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService editorService = null;
            if (provider != null)
            {
                editorService = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            }

            if (editorService != null)
            {
                NumericUpDown udControl = new NumericUpDown();
                udControl.DecimalPlaces = 0;
                udControl.Minimum = 0;
                udControl.Maximum = 10000000000;
                udControl.Value = (uint)value;
                editorService.DropDownControl(udControl);
                value = (uint)udControl.Value;
            }

            return value;
        }
    }
}
