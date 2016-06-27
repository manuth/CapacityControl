using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapacityPickerTest
{
    public partial class CapacityPickerForm : Form
    {
        public CapacityPickerForm()
        {
            InitializeComponent();
        }
        
        private void capacityPicker_ValueChanged(object sender, EventArgs e)
        {
            valueLabel.Text = "The current value is: " + (sender as CapacityPicker.CapacityPicker).Value + " " + CapacityPicker.CapacityUnitInfo.CapacityUnitInfos[(sender as CapacityPicker.CapacityPicker).BaseUnit].Name;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            ValidateChildren();
        }
    }
}
