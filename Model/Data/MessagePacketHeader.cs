using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace RFSourceControllerApp.Model.Data
{
    [StructLayout(LayoutKind.Explicit, Size = 16, Pack = 1)]
    class MessagePacketHeader
    {
        [FieldOffset(0)]
        private UInt64 _Header;
        [FieldOffset(8)]
        private Int32 _Messagetype;
        [FieldOffset(12)]
        private UInt32 _MessageSize;

        public UInt64 Header
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

        public Int32 Messagetype
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

        public UInt32 MessageSize
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
        public MessagePacketHeader(UInt64 header, Int32 messageType)
        {
            _Header = header;
            _Messagetype = messageType;

        }

    }
}
