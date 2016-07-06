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