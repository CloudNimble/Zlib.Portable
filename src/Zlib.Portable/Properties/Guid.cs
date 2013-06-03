using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ionic.Zlib.Properties
{
    // Zusammenfassung:
    //     Stellt eine explizite System.Guid bereit, wenn eine automatische GUID nicht
    //     erwünscht ist.
    [ComVisible(true)]
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false)]
    public sealed class GuidAttribute : Attribute
    {
        // Zusammenfassung:
        //     Initializes a new instance of the System.Runtime.InteropServices.GuidAttribute
        //     class with the specified GUID.
        //
        // Parameter:
        //   guid:
        //     Die zuzuweisende System.Guid.
        public GuidAttribute(string guid)
        {
            this.Value = guid;
        }

        // Zusammenfassung:
        //     Ruft die System.Guid der Klasse ab.
        //
        // Rückgabewerte:
        //     Der System.Guid der Klasse.
        public string Value
        {
            get;
            private set;
        }
    }
}