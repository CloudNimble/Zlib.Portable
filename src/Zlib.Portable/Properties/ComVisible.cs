using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ionic.Zlib.Properties
{
    // Zusammenfassung:
    //     Steuert den Zugriff eines einzelnen verwalteten Typs bzw. Members oder aller
    //     Typen in einer Assembly auf COM.
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false)]
    [ComVisible(true)]
    public sealed class ComVisibleAttribute : Attribute
    {
        // Zusammenfassung:
        //     Initialisiert eine neue Instanz der ComVisibleAttribute-Klasse.
        //
        // Parameter:
        //   visibility:
        //     true, um anzugeben, dass der Typ für COM sichtbar ist, andernfalls false.Der
        //     Standardwert ist true.
        public ComVisibleAttribute(bool visibility)
        {
            this.Value = visibility;
        }

        // Zusammenfassung:
        //     Ruft einen Wert ab, der angibt, ob der COM-Typ sichtbar ist.
        //
        // Rückgabewerte:
        //     true, wenn der Typ sichtbar ist, andernfalls false.Der Standardwert ist true.
        public bool Value
        {
            get;
            private set;
        }
    }
}