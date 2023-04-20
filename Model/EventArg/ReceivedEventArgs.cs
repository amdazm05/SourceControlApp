using System;
using RFSourceControllerApp.Model.Data;

namespace RFSourceControllerApp.Model.EventArg
{
    public class ReceivedEventArgs : EventArgs
    {

        public Transmission Message { get; private set; }

        public ReceivedEventArgs(Transmission message)
        {
            Message = message;   
        }

    }

    public class RecievedDataByteBuffer : EventArgs
    {

        public byte[] Message { get; set; }

        public RecievedDataByteBuffer(byte[] message)
        {
            Message = message;
        }

    }
}
