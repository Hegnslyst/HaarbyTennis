
using System;
using System.Runtime.Serialization;
namespace HaarbyTennis.Utilities
{
    

    public class ServiceException : Exception, ISerializable
    {
        public ServiceException()
            : base()
        {
        }

        public ServiceException(string message)
            : base(message)
        {
        }

        public ServiceException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ServiceException(string id, string message)
            : base(string.Format("ID: {0}, Message: {1}", id, message))
        {
        }
        
        public ServiceException(string paramName, string id, string message)
            : base(string.Format("ParamName: {0}, ID: {1}, Message: {2}", paramName, id, message))
        {
        }

        /*public ServiceException(short fejlKode, int sqlKode, string fejlbesked)
            : base(string.Format("Fejl kode: {0}, SQL kode: {1}, Fejlbesked: {2}", fejlKode, sqlKode, fejlbesked))
        {
        }*/
    }
}