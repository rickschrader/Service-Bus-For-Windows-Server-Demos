using System.ServiceModel;

namespace PublisherService
{
    [ServiceContract]
    public interface IPublisherService
    {
        [OperationContract(IsOneWay = true)]
        void PublishString(string data);
    }
}
