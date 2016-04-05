using System;
using System.ServiceModel;

namespace NullService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Single)]
    public class NullService : INullService
    {
        public void Null()
        { }
    }
}
