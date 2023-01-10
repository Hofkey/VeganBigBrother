using System.Runtime.Serialization;

namespace VeganBigBrother.Core.Exceptions
{
    [Serializable]
    public class EntityDoesNotExistException : Exception
    {
        public EntityDoesNotExistException(Type entity, int id)
            : base(string.Format("{0} with id {1} does not exist!", entity.Name, id.ToString()))
        {
        }

        public EntityDoesNotExistException(Type entity, string code)
            : base(string.Format("{0} with code {1} does not exist!", entity.Name, code))
        {
        }

        protected EntityDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
