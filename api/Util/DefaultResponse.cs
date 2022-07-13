namespace api.Util
{
    public class DefaultResponse
    {
        public int Code {get; private set;}
        public string Message {get; private set;}

        public DefaultResponse(string sMessage, int iCode = 200)
        {
            this.Code = iCode;
            this.Message = sMessage;
        }
    }
}