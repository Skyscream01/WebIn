using log4net;
using log4net.Config;

namespace ProductX.Framework
{
    public class BaseEntity
    {
        protected static ILog Log;

        protected BaseEntity()
        {
            XmlConfigurator.Configure();
            Log = LogManager.GetLogger(typeof (BaseEntity));
        }

// Just logs current step number and name.
        public void LogStep(int step, string message)
        {
            Log.Info(string.Format("----------[ Step {0} ]: {1}", step, message));
        }

// Logs Test Case name.
        public void LogCase(string message)
        {
            Log.Info(string.Format("              "));
            Log.Info(string.Format(message));
            Log.Info(string.Format("              "));
        }
    }
}
