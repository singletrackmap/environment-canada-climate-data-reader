using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HAWKLORRY
{
    /// <summary>
    /// The format of result data file
    /// </summary>
    enum FormatType
    {
        /// <summary>
        /// Contain date and any selected data field.
        /// </summary>
        SIMPLE_TEXT,
        /// <summary>
        /// has header
        /// </summary>
        SIMPLE_CSV,
        /// <summary>
        /// Text file which could be imported by ArcSWAT
        /// </summary>
        ARCSWAT_TEXT,
        /// <summary>
        /// Dbf file which could be imported by ArcSWAT
        /// </summary>
        ARCSWAT_DBF,
        /// <summary>
        /// Text file which is used in SWAT model.
        /// </summary>
        SWAT_TEXT
    }
}
