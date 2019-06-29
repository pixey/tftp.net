using System;

namespace Tftp.Net
{
    public interface ITftpClient
    {
        /// <summary>
        /// GET a file from the server.
        /// You have to call Start() on the returned ITftpTransfer to start the transfer.
        /// </summary>
        ITftpTransfer Download(String filename);

        /// <summary>
        /// PUT a file from the server.
        /// You have to call Start() on the returned ITftpTransfer to start the transfer.
        /// </summary>
        ITftpTransfer Upload(String filename);
    }
}