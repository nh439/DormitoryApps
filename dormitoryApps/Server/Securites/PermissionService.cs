namespace dormitoryApps.Server.Securites
{
    public class PermissionService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public PermissionService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public bool PermissionCheck(string sessionId)
        {
            string serverSession = _contextAccessor.HttpContext.Session.GetString("Id");
            if (sessionId.Equals(serverSession))
            {
                return true;
            }
            return false;
        }
    }
}
