using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Timers;

namespace PublisherService.Host
{
    public class ServiceBusHostFactory : ServiceHostFactoryBase
    {
        private Timer _timer; 

        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            //Task.Factory.StartNew(() =>
            //    {
            //        _timer = new Timer(10000);
            //        _timer.Elapsed += _timer_Elapsed;
            //        _timer.Start();
            //    });

            return new ServiceHost(typeof(PublisherService), baseAddresses);
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            using (var fs = new FileStream(@"C:\Test\test.txt", FileMode.Append, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.Write(DateTime.Now.ToString());
                    sw.Flush();
                }
            }            
        }
    }
}