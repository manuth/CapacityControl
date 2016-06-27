using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapacityPicker
{
    /// <summary>
    /// A class which represents information about a capacity-unit
    /// </summary>
    public sealed class CapacityUnitInfo
    {
        /// <summary>
        /// The unit
        /// </summary>
        private CapacityUnits unit = CapacityUnits.None;

        /// <summary>
        /// The name of the unit
        /// </summary>
        private string name = null;

        /// <summary>
        /// The multiplier of the unit
        /// </summary>
        private ulong multiplier = 0;

        /// <summary>
        /// Returns or sets the unit
        /// </summary>
        public CapacityUnits Unit
        {
            get
            {
                return unit;
            }
            set
            {
                unit = value;
            }
        }

        /// <summary>
        /// Returns or sets the name of the unit
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Returns or sets the multiplier of the unit
        /// </summary>
        public ulong Multiplier
        {
            get
            {
                return multiplier;
            }
            set
            {
                multiplier = value;
            }
        }

        /// <summary>
        /// Initializes a class which represents information about a capacity-unit
        /// </summary>
        public CapacityUnitInfo()
        { }

        /// <summary>
        /// Initializes a class which represents information about a capacity-unit
        /// </summary>
        /// <param name="name">Defines the name of the unit</param>
        /// <param name="multiplier">Defines the multiplier of the unit</param>
        public CapacityUnitInfo(CapacityUnits unit, string name, ulong multiplier)
        {
            this.unit = unit;
            this.name = name;
            this.multiplier = multiplier;
        }

        /// <summary>
        /// Returns a string which represents the object
        /// </summary>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Converts a value from one dataunit to another
        /// </summary>
        /// <param name="unit">The unit to convert to</param>
        /// <param name="value">The value to convert</param>
        /// <returns>Returns the converted value</returns>
        public decimal ConvertTo(CapacityUnitInfo unit, decimal value)
        {
            return Convert(this, unit, value);
        }

        /// <summary>
        /// Converts a value from one dataunit to another
        /// </summary>
        /// <param name="source">The unit to convert from</param>
        /// <param name="dest">The unit to convert to</param>
        /// <param name="value">The value to convert</param>
        /// <returns>Returns the converted value</returns>
        public static decimal Convert(CapacityUnitInfo source, CapacityUnitInfo dest, decimal value)
        {
            if (source.Multiplier > 0 && dest.Multiplier > 0)
                return (value * source.Multiplier) / dest.Multiplier;
            else
                return 0;
        }

        /// <summary>
        /// Returns information about each capacityunit
        /// </summary>
        public static CapacityUnitInfo[] GetCapacityUnitInfos()
        {
            return new CapacityUnitInfo[]
            {
                new CapacityUnitInfo(CapacityUnits.None, "", 0),
                new CapacityUnitInfo(CapacityUnits.Byte, "Bytes", 1L),
                new CapacityUnitInfo(CapacityUnits.KB, "KB", 1L * 1024),
                new CapacityUnitInfo(CapacityUnits.MB, "MB", 1L * 1024 * 1024),
                new CapacityUnitInfo(CapacityUnits.GB, "GB", 1L * 1024 * 1024 * 1024),
                new CapacityUnitInfo(CapacityUnits.TB, "TB", 1L * 1024 * 1024 * 1024 * 1024),
                new CapacityUnitInfo(CapacityUnits.PB, "PB", 1L * 1024 * 1024 * 1024 * 1024 * 1024)
            };
        }

        /// <summary>
        /// Returns information about each capacityunit
        /// </summary>
        public static Dictionary<CapacityUnits, CapacityUnitInfo> CapacityUnitInfos
        {
            get
            {
                Dictionary<CapacityUnits, CapacityUnitInfo> capacityUnitInfos = new Dictionary<CapacityUnits, CapacityUnitInfo>();
                foreach (CapacityUnitInfo unitInfo in GetCapacityUnitInfos())
                    capacityUnitInfos.Add(unitInfo.Unit, unitInfo);
                return capacityUnitInfos;
            }
        }
    }
}
