using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFSourceControllerApp.Model.Data
{
    class MessagePacketHeader
    {
        private ulong _Header;
        private int _Messagetype;
        private uint _MessageSize;

        public ulong Header
        {
            get
            {
                return _Header;
            }

            set
            {
                _Header = value;
            }
        }

        public int Messagetype
        {
            get
            {
                return _Messagetype;
            }

            set
            {
                _Messagetype = value;
            }
        }

        public uint MessageSize
        {
            get
            {
                return _MessageSize;
            }

            set
            {
                _MessageSize = value;
            }
        }

        public MessagePacketHeader()
        {
            MessageSize = 0;
            Header = 0;
            Messagetype = 0;
        }
        /// <summary>
        /// initialises the header, and message and instantiates an instance
        /// </summary>
        /// <param name="header"></param>
        /// <param name="messageType"></param>
        public MessagePacketHeader(ulong header, int messageType)
        {
            _Header = header;
            _Messagetype = messageType;

        }

    }
}
