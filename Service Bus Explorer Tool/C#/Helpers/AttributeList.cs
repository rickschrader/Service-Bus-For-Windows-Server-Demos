#region Using Directives
using System;
using System.Collections.Generic;
using System.ComponentModel; 
#endregion

namespace Microsoft.WindowsAzure.CAT.ServiceBusExplorer
{
    internal class AttributeList : List<Attribute>
    {
        #region Public Conctructors
        public AttributeList()
        {

        }

        public AttributeList(AttributeCollection ac)
        {
            foreach (Attribute attr in ac)
            {
                Add(attr);
            }
        } 
        #endregion
    }
}