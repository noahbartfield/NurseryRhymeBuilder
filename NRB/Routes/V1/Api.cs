using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Routes.V1
{
    public static class Api
    {
        internal const string Root = "api";
        internal const string Version = "v1";
        internal const string Base = Root + "/" + Version;

        public static class Values
        {
            public const string GetAll = Base + "/Values";
            public const string Get = Base + "/Values/{id}";
        }

        public static class Words
        {
            public const string GetAll = Base + "/Words";
            public const string Get = Base + "/Words/{id}";
        }
        public static class NurseryRhymes
        {
            public const string GetAll = Base + "/NerseryRhymes";
            public const string Get = Base + "/NerseryRhymes/{id}";
        }
        public static class User
        {
            public const string Login = Base + "/Auth/Login";
            public const string Register = Base + "/Auth/Register";
            public const string Refresh = Base + "/Auth/Refresh";
        }
    }
}
