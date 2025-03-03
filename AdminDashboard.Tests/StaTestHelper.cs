using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace AdminDashboard.Tests.Helpers
{
    public static class StaTestHelper
    {
        public static void Run(Action action)
        {
            Exception exception = null;
            Thread thread = new Thread(() =>
            {
                try
                {
                 
                    if (Application.Current == null)
                    {
                        new Application();
                    }

                   
                    action();

                   
                    Dispatcher.CurrentDispatcher.InvokeShutdown();
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            if (exception != null)
                throw exception;
        }
    }
}
