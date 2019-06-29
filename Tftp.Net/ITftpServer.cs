namespace Tftp.Net
{
    public interface ITftpServer
    {
        /// <summary>
        /// Fired when the server receives a new read request.
        /// </summary>
        event TftpServerEventHandler OnReadRequest;

        /// <summary>
        /// Fired when the server receives a new write request.
        /// </summary>
        event TftpServerEventHandler OnWriteRequest;

        /// <summary>
        /// Fired when the server encounters an error (for example, a non-parseable request)
        /// </summary>
        event TftpServerErrorHandler OnError;

        /// <summary>
        /// Start accepting incoming connections.
        /// </summary>
        void Start();

        void Dispose();
    }
}