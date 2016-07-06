/* ****************************************************************************
 *
 * Copyright (c) Manuel Thalmann
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the LICENSE file at the root of this distribution. If 
 * you cannot locate the Apache License, Version 2.0, please send an email to 
 * manu.th999@gmail.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

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
