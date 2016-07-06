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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

namespace CapacityPicker
{
    /// <summary>
    /// A class which contains controls to pick an amount of data
    /// </summary>
    [
        DefaultProperty("Value"),
        DefaultBindingProperty("Value"),
        DefaultEvent("ValueChanged")
    ]
    public partial class CapacityPicker : UserControl
    {
        /// <summary>
        /// The value
        /// </summary>
        private decimal? value = null;

        /// <summary>
        /// The amount of decimal places to show
        /// </summary>
        private int decimalPlaces = 2;

        /// <summary>
        /// The dafault unit to use
        /// </summary>
        private CapacityUnitInfo defaultUnit = CapacityUnitInfo.CapacityUnitInfos[CapacityUnits.GB];

        /// <summary>
        /// The unit of the value
        /// </summary>
        private CapacityUnitInfo baseUnit = CapacityUnitInfo.CapacityUnitInfos[CapacityUnits.Byte];

        /// <summary>
        /// The unit to display the value
        /// </summary>
        private CapacityUnitInfo unit = CapacityUnitInfo.CapacityUnitInfos[CapacityUnits.None];

        /// <summary>
        /// Returns the default number of decimal places to show
        /// </summary>
        protected virtual int DefaultDecimalPlaces
        {
            get
            {
                return 2;
            }
        }

        /// <summary>
        /// Returns the default unit to use
        /// </summary>
        protected virtual CapacityUnits DefaultDefaultUnit
        {
            get
            {
                return CapacityUnits.GB;
            }
        }

        /// <summary>
        /// Returns the default unit of the value to use
        /// </summary>
        protected virtual CapacityUnits DefaultBaseUnit
        {
            get
            {
                return CapacityUnits.Byte;
            }
        }

        /// <summary>
        /// Returns or sets the value
        /// </summary>
        [
            Bindable(true, BindingDirection.TwoWay),
            Category(Constants.CategoryName),
            Description("Der aktuelle Wert des CapacityPickers")
        ]
        public decimal? Value
        {
            get
            {
                if (value == 0)
                    return null;
                else
                    return value;
            }
            set
            {
                Unit = GetPreferredUnit(value.GetValueOrDefault(0));
                valueUpDown.Value = baseUnit.ConvertTo(unit, value.GetValueOrDefault(0));
            }
        }

        /// <summary>
        /// Returns or sets the number of decimal places to show
        /// </summary>
        [
            Category(Constants.CategoryName)
            Description("Die Anzahl der Stellen nach dem Komma, die angezeigt werden sollen"),
            RefreshProperties(RefreshProperties.All)
        ]
        public int DecimalPlaces
        {
            get
            {
                return decimalPlaces;
            }
            set
            {
                decimalPlaces = value;
                valueUpDown.DecimalPlaces = value;
            }
        }

        /// <summary>
        /// Returns or sets the default unit to use
        /// </summary>
        [
            Category(Constants.CategoryName),
            Description("Die Masseinheit, in der der Wert standardmässig angezeigt werden soll")
        ]
        public CapacityUnits DefaultUnit
        {
            get
            {
                return defaultUnit.Unit;
            }
            set
            {
                defaultUnit = CapacityUnitInfo.CapacityUnitInfos[value];
            }
        }

        /// <summary>
        /// Returns or sets the unit of the value
        /// </summary>
        [
            Category(Constants.CategoryName),
            Description("Die Masseinheit, in der der Wert gespeichert werden soll")
        ]
        public CapacityUnits BaseUnit
        {
            get
            {
                return baseUnit.Unit;
            }
            set
            {
                Value = baseUnit.ConvertTo(CapacityUnitInfo.CapacityUnitInfos[value], Value.GetValueOrDefault(0));
                baseUnit = CapacityUnitInfo.CapacityUnitInfos[value];
            }
        }

        /// <summary>
        /// Returns or sets the currently selected unit
        /// </summary>
        [
            Category(Constants.CategoryName),
            Description("Die aktuell gewählte Masseinheit in der der Wert ausgegeben werden soll"),
            Browsable(false),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
            DefaultValue(CapacityUnits.None)
        ]
        public CapacityUnits Unit
        {
            get
            {
                return (unitComboBox.SelectedItem as CapacityUnitInfo).Unit;
            }
            set
            {
                if (unit.Unit != value)
                {
                    unit = CapacityUnitInfo.CapacityUnitInfos[value];
                    unitComboBox.SelectedItem = unitComboBox.Items.OfType<CapacityUnitInfo>().First(unitInfo => unitInfo.Unit == value);
                    valueUpDown.Value = baseUnit.ConvertTo(CapacityUnitInfo.CapacityUnitInfos[value], this.value.GetValueOrDefault(0));
                }
                OnUnitChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Hits when the user changes the value
        /// </summary>
        [
            Category(Constants.CategoryName)
            Description("Tritt ein, wenn der aktuelle Wert sich geändert hat.")
        ]
        public event EventHandler ValueChanged;

        /// <summary>
        /// Hits when the current unit changed
        /// </summary>
        [
            Category(Constants.CategoryName)
            Description("Tritt ein, wenn die aktuelle Masseinheit sich geändert hat.")
        ]
        public event EventHandler UnitChanged;

        /// <summary>
        /// Initializes a class which contains controls to pick an amount of data
        /// </summary>
        public CapacityPicker()
        {
            InitializeComponent();
            capacityUnitSource.DataSource = CapacityUnitInfo.CapacityUnitInfos.Values;
        }

        /// <summary>
        /// Resets the number of decimal places to show
        /// </summary>
        public virtual void ResetDecimalPlaces()
        {
            DecimalPlaces = DefaultDecimalPlaces;
        }

        /// <summary>
        /// Resets the unit to use
        /// </summary>
        public virtual void ResetDefaultUnit()
        {
            DefaultUnit = DefaultDefaultUnit;
        }

        /// <summary>
        /// Resets the unit of the value to use
        /// </summary>
        public virtual void ResetBaseUnit()
        {
            BaseUnit = DefaultBaseUnit;
        }

        /// <summary>
        /// Returns true if the number of decimal places to show should be persisted in code gen.
        /// </summary>
        protected virtual bool ShouldSerializeDecimalPlaces()
        {
            return DecimalPlaces != DefaultDecimalPlaces;
        }

        /// <summary>
        /// Returns true if the unit to use should be presisted in code gen.
        /// </summary>
        protected virtual bool ShouldSerializeDefaultUnit()
        {
            return DefaultUnit != DefaultDefaultUnit;
        }

        /// <summary>
        /// Returns true if the unit of the value to use should be presisted in code gen.
        /// </summary>
        protected virtual bool ShouldSerializeBaseUnit()
        {
            return BaseUnit != DefaultBaseUnit;
        }

        /// <summary>
        /// Raises the <see cref="ValueChanged"/>-Event
        /// </summary>
        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="UnitChanged"/>-Event
        /// </summary>
        protected virtual void OnUnitChanged(EventArgs e)
        {
            UnitChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Validates the values of the control
        /// </summary>
        protected override void OnValidating(CancelEventArgs e)
        {
            // Calling NumericUpDown.Value.get in order to parse the user-input
            decimal value = valueUpDown.Value;
            base.OnValidated(e);
        }

        protected virtual CapacityUnits GetPreferredUnit()
        {
            return GetPreferredUnit(Value.GetValueOrDefault(0));
        }

        /// <summary>
        /// Returns the best matching unit
        /// </summary>
        protected virtual CapacityUnits GetPreferredUnit(decimal value)
        {
            if (value > 0)
            {
                CapacityUnitInfo[] nonZeroUnits = CapacityUnitInfo.GetCapacityUnitInfos().OrderByDescending(unit => unit.Multiplier).Where(unit => unit.Multiplier > 0).ToArray();

                int i;
                for (i = 0; i < nonZeroUnits.Length && GetDecimalPlaceCount(value, nonZeroUnits[i].Unit) > decimalPlaces; i++) { }

                return nonZeroUnits[i].Unit;
            }
            else
                return CapacityUnitInfo.GetCapacityUnitInfos().First(unit => unit.Multiplier == 0).Unit;
        }

        /// <summary>
        /// Returns the best matching unit
        /// </summary>
        public static CapacityUnits GetPreferredUnit(decimal value, int decimalPlaces, CapacityUnits baseUnit)
        {
            if (value > 0)
            {
                CapacityUnitInfo[] nonZeroUnits = CapacityUnitInfo.GetCapacityUnitInfos().OrderByDescending(unit => unit.Multiplier).Where(unit => unit.Multiplier > 0).ToArray();

                int i;
                for (i = 0; i < nonZeroUnits.Length && GetDecimalPlaceCount(value, baseUnit, nonZeroUnits[i].Unit, false, decimalPlaces) > decimalPlaces; i++) { }

                return nonZeroUnits[i].Unit;
            }
            else
                return CapacityUnitInfo.GetCapacityUnitInfos().First(unit => unit.Multiplier == 0).Unit;
        }

        /// <summary>
        /// Returns the best matching count of decimal places
        /// </summary>
        /// <param name="value">Defines the value whose best matching number of decimal places should be calculated</param>
        /// <param name="unit">Defines the dataunit whose best matching count of decimal places should be calculated</param>
        /// <returns>Returns the best matching count of decimal places</returns>
        protected virtual int GetDecimalPlaceCount(decimal value, CapacityUnits unit)
        {
            return GetDecimalPlaceCount(value, unit, false);
        }

        /// <summary>
        /// Returns the best matching count of decimal places
        /// </summary>
        /// <param name="value">Defines the value whose best matching number of decimal places should be calculated</param>
        /// <param name="unit">Defines the dataunit whose best matching count of decimal places should be calculated</param>
        /// <param name="minCount">Defines whether the minimal or the maximal count of decimal places should be returned</param>
        /// <returns>Returns the best matching count of decimal places</returns>
        protected virtual int GetDecimalPlaceCount(decimal value, CapacityUnits unit, bool minCount)
        {
            return GetDecimalPlaceCount(value, baseUnit.Unit, unit, minCount, decimalPlaces);
        }

        /// <summary>
        /// Returns the best matching count of decimal places
        /// </summary>
        /// <param name="value">Defines the value whose best matching number of decimal places should be calculated</param>
        /// <param name="baseUnit">Defines the unit of the specified value</param>
        /// <param name="unit">Defines the dataunit whose best matching count of decimal places should be calculated</param>
        /// <param name="minCount">Defines whether the minimal or the maximal count of decimal places should be returned</param>
        /// <param name="decimalPlaces">Defines the preferred count of decimal places</param>
        /// <returns>Returns the best matching count of decimal places</returns>
        protected static int GetDecimalPlaceCount(decimal value, CapacityUnits baseUnit, CapacityUnits unit, bool minCount, int decimalPlaces)
        {
            CapacityUnitInfo unitInfo = CapacityUnitInfo.CapacityUnitInfos[unit];
            int i = 0;
            if (value > 0 && unitInfo.Multiplier > 0)
            {
                value = CapacityUnitInfo.CapacityUnitInfos[baseUnit].ConvertTo(unitInfo, value);
                try
                {
                    if (minCount)
                        for (i = 0; value != (ulong)value && Math.Round(value, i) - (ulong)value == 0; i++) { }
                    else
                        i = BitConverter.GetBytes(decimal.GetBits(value)[3])[2];
                }
                catch { }
            }
            if (i < decimalPlaces)
                i = decimalPlaces;
            return i;
        }

        /// <summary>
        /// Hits when the user changes the current value
        /// </summary>
        private void valueUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;
            if (numericUpDown.Value > 0 && unit.Multiplier <= 0)
            {
                value = defaultUnit.ConvertTo(baseUnit, numericUpDown.Value);
                Unit = DefaultUnit;
                OnValueChanged(e);
            }
            if (baseUnit.ConvertTo(unit, value.GetValueOrDefault(0)) != numericUpDown.Value || (unit.Multiplier == 0 && value > 0))
            {
                value = unit.ConvertTo(baseUnit, numericUpDown.Value);
                OnValueChanged(e);
            }
            if (unit.Multiplier == 1)
                valueUpDown.DecimalPlaces = 0;
            else
                valueUpDown.DecimalPlaces = GetDecimalPlaceCount(value.GetValueOrDefault(0), Unit, true);
        }
        
        /// <summary>
        /// Hits when the user thanges the current unit
        /// </summary>
        private void unitComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedItem != null)
            {
                Unit = ((sender as ComboBox).SelectedItem as CapacityUnitInfo).Unit;
                if (unit.Multiplier == 0)
                    valueUpDown.Value = 0;
            }
        }

        /// <summary>
        /// A set of constant values
        /// </summary>
        private static class Constants
        {
            /// <summary>
            /// The name of the categorys of the custom members
            /// </summary>
            public const string CategoryName = "CapacityPicker";
        }
    }
}
