using System;

namespace ZooClassLibrary.UserException
{
    public class ExitException: Exception
    {
        public override string Message
        {
            get
            {
                return string.Format("Exit");
            }
        }
    }
}
