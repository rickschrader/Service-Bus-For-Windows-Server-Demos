using System.ServiceModel;

namespace NullService
{
    [ServiceContract]
    public interface INullService
    {
        [OperationContract]
        void Null();
    }
}
