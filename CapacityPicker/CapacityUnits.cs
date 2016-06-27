using System.ComponentModel.DataAnnotations;

namespace CapacityPicker
{
    /// <summary>
    /// A set of capacity-units
    /// </summary>
    public enum CapacityUnits
    {
        /// <summary>
        /// No unit
        /// </summary>
        [Display(Name = "")]
        None,
        /// <summary>
        /// Bytes
        /// </summary>
        [Display(Name = "Bytes")]
        Byte,
        /// <summary>
        /// Kilobytes
        /// </summary>
        [Display(Name = "KB")]
        KB,
        /// <summary>
        /// Megabytes
        /// </summary>
        [Display(Name = "MB")]
        MB,
        /// <summary>
        /// Gigabytes
        /// </summary>
        [Display(Name = "GB")]
        GB,
        /// <summary>
        /// Terrabytes
        /// </summary>
        [Display(Name = "TB")]
        TB,
        /// <summary>
        /// Petabytes
        /// </summary>
        [Display(Name = "PB")]
        PB
    }
}