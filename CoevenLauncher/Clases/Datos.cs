using System;
using System.Collections.Generic;
using System.Text;

namespace CoevenLauncher
{
    public static class Datos
    {
        public static string apiPassword { get; set; }

        static bool _changelogOpen;
        public static bool changeLogOpen
        {
            get { return _changelogOpen; }
            set { _changelogOpen = value; }
        }
        static bool _laubusy;
        public static bool imBusy
        {
            get
            {
                return _laubusy;
            }
            set
            {
                _laubusy = value;
            }
        }
        static int _lauver;
        public static int LauncherVersion
        {
            get
            {
                return _lauver;
            }
            set
            {
                _lauver = value;
            }
        }
        static int _lauBuild;
        public static int LauncherBuild
        {
            get
            {
                return _lauBuild;
            }
            set
            {
                _lauBuild = value;
            }
        }
        static int _lauPatch;
        public static int LauncherPatch
        {
            get
            {
                return _lauPatch;
            }
            set
            {
                _lauPatch = value;
            }
        }
        static int _lauvers;
        public static int LauncherServerVersion
        {
            get
            {
                return _lauvers;
            }
            set
            {
                _lauvers = value;
            }
        }
        static int _lauServerBuild;
        public static int LauncherServerBuild
        {
            get
            {
                return _lauServerBuild;
            }
            set
            {
                _lauServerBuild = value;
            }
        }
        static int _lauServerPatch;
        public static int LauncherServerPatch
        {
            get
            {
                return _lauServerPatch;
            }
            set
            {
                _lauServerPatch = value;
            }
        }
        static string _lauCode;
        public static string LauncherServerCode
        {
            get
            {
                return _lauCode;
            }
            set
            {
                _lauCode = value;
            }
        }
        static string _lauDate;
        public static string LauncherServerDate
        {
            get
            {
                return _lauDate;
            }
            set
            {
                _lauDate = value;
            }
        }
        static bool _laupop;
        public static bool LauncherPopUp
        {
            get
            {
                return _laupop;
            }
            set
            {
                _laupop = value;
            }
        }
        static string _urlLOG;
        public static string LoginURL
        {
            get
            {
                return _urlLOG;
            }
            set
            {
                _urlLOG = value;
            }
        }

        static int _laupopMSG;
        public static int LauncherPopUpMSG
        {
            get
            {
                return _laupopMSG;
            }
            set
            {
                _laupopMSG = value;
            }
        }
        static int _conexion;
        public static int EstadoConexion
        {
            get
            {
                return _conexion;
            }
            set
            {
                _conexion = value;
            }
        }
        static int _errorLogin;
        public static int LoginStatus
        {
            get
            {
                return _errorLogin;
            }
            set
            {
                _errorLogin = value;
            }

        }
        static string _loginName;
        public static string LoginName
        {
            get
            {
                return _loginName;
            }
            set
            {
                _loginName = value;
            }
        }
        static int _apiHeartBeat;
        public static int apiHeartBeat
        {
            get
            {
                return _apiHeartBeat;
            }
            set
            {
                _apiHeartBeat = value;
            }
        }
        static string _datosAPI;
        public static string DatosAPI
        {
            get
            {
                return _datosAPI;
            }
            set
            {
                _datosAPI = value;
            }
        }
        static int _datosAPI1;
        public static int apiID
        {
            get
            {
                return _datosAPI1;
            }
            set
            {
                _datosAPI1 = value;
            }
        }

        static string _datosAPI2;
        public static string apiUser
        {
            get
            {
                return _datosAPI2;
            }
            set
            {
                _datosAPI2 = value;
            }
        }

        static string _datosAPI3;
        public static string apiEmail
        {
            get
            {
                return _datosAPI3;
            }
            set
            {
                _datosAPI3 = value;
            }
        }
        static int _datosAPI4;
        public static int apicPoints
        {
            get
            {
                return _datosAPI4;
            }
            set
            {
                _datosAPI4 = value;
            }
        }
        static int _datosAPI5;
        public static int apiAuth
        {
            get
            {
                return _datosAPI5;
            }
            set
            {
                _datosAPI5 = value;
            }
        }
        static int _datosAPI6;
        public static int apiVerified
        {
            get
            {
                return _datosAPI6;
            }
            set
            {
                _datosAPI6 = value;
            }
        }
        static string _datosAPI7;
        public static string apiToken
        {
            get
            {
                return _datosAPI7;
            }
            set
            {
                _datosAPI7 = value;
            }
        }
        static string _datosAPI8;
        public static string apiIP
        {
            get
            {
                return _datosAPI8;
            }
            set
            {
                _datosAPI8 = value;
            }
        }
        static string _datosAPI9;
        public static string apiFecha
        {
            get
            {
                return _datosAPI9;
            }
            set
            {
                _datosAPI9 = value;
            }
        }
        static string _datosAPI10;
        public static string apiPicture
        {
            get
            {
                return _datosAPI10;
            }
            set
            {
                _datosAPI10 = value;
            }
        }
        static int _cantNotificaciones;
        public static int cantNotificaciones
        {
            get
            {
                return _cantNotificaciones;
            }
            set
            {
                _cantNotificaciones = value;
            }
        }

    //fin
    }
}
