using System.Net;

namespace SntpClient.Protocol
{
    /// <summary>
    /// A class that holds information to connect to a remote NTP/SNTP Server
    /// </summary>
    public class SntpServer
    {
#region Fields
        
        private string _HostNameOrIpAddress;
        private int _Port;

        /// <summary>
        /// A remote NTP/SNTP server configured with the default values.
        /// </summary>
        public static readonly SntpServer Default = new SntpServer();

        public const string DefaultHostName = "time.nist.gov";

        public const int DefaultPort = 123;

#endregion Fields

#region Constructors

        /// <summary>
        /// Creates a new instance of a remote NTP/SNTP server.
        /// </summary>
        /// <param name="hostNameOrAddress">The host name or address of the server.</param>
        /// <param name="port">The port to use (normally 123).</param>
        public SntpServer(string hostNameOrAddress, int port)
        {
            this._HostNameOrIpAddress = hostNameOrAddress;
            this._Port = port;
        }

        /// <summary>
        /// Creates a new instance of a remote NTP/SNTP server.
        /// </summary>
        /// <param name="hostNameOrAddress">The host name or address of the server.</param>
        public SntpServer(string hostNameOrAddress)
            : this(hostNameOrAddress, DefaultPort)
        { }

        /// <summary>
        /// Creates a new instance of a remote NTP/SNTP server, using "time.nist.gov" server.
        /// </summary>
        public SntpServer()
            : this(DefaultHostName, DefaultPort)
        { }

#endregion Constructors

#region Properties

        /// <summary>
        /// Gets or sets the host name or address of the server.
        /// </summary>
        public string HostNameOrAddress
        {
            get { return _HostNameOrIpAddress; }
            set
            {
                value = value.Trim();
                if (string.IsNullOrEmpty(value))
                    value = DefaultHostName;
                this._HostNameOrIpAddress = value;
            }
        }

        /// <summary>
        /// Gets or sets the port number that this server uses.
        /// </summary>
        public int Port
        {
            get { return _Port; }
            set
            {
                if (value >= 0 && value <= 65535)
                    this._Port = value;
                else
                    this._Port = DefaultPort;
            }
        }


#endregion Properties

#region Methods

        /// <summary>
        /// Attempts to get the System.Net.IEPEndPoint of this server.
        /// </summary>
        /// <returns>The System.Net.IEPEndPoint of this server.</returns>
        public IPEndPoint GetIPEndPoint()
        {
            return new IPEndPoint(Dns.GetHostAddresses(HostNameOrAddress)[0], Port);
        }

        /// <summary>
        /// Returns the host name, IP address and port number of this server.
        /// </summary>
        /// <returns>The host name, IP address and port number of this server.</returns>
        public override string ToString()
        {
            return string.Format("{0}:{1}",
                HostNameOrAddress, Port);
        }

#endregion Methods 
    }
}
