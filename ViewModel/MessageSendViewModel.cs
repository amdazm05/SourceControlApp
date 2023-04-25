using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFSourceControllerApp.ViewModel;
using RFSourceControllerApp.Model.Data;
using RFSourceControllerApp.Model.EventArg;
using RFSourceControllerApp.Model.Util;


namespace RFSourceControllerApp.ViewModel
{
    class MessageSendViewModel : TcpClientViewModel
    {
        private RFSourceControlViewModel _SourceControlViewModel;
        private TcpClientViewModel _NetworkClientViewModel;
        private MessagePacketHeader _TranmissionHeader;
        private MessagePacketHeader _RecievedHeader;
        private byte[] _MessageContentTrasmitBuffer;
        private byte[] _MessageContentRecieveBuffer;
        private bool validDelimFound;
        public MessageSendViewModel( RFSourceControlViewModel SourceControlViewModel, TcpClientViewModel NetworkClientViewModel)
        {
            _TranmissionHeader = new MessagePacketHeader(0xDEADBEEFBEEFFEED,1);
            _RecievedHeader = new MessagePacketHeader();
            _MessageContentTrasmitBuffer = new byte[8192];
            _MessageContentRecieveBuffer = new byte[8192];
            _SourceControlViewModel = SourceControlViewModel;
            _NetworkClientViewModel = NetworkClientViewModel;
            _SourceControlViewModel.SendData += CastTransmissionDataToMesageDataAndSend;
            _NetworkClientViewModel._tcpClient.Received += CastRecievedBytesToSourceMessage;
            //_NetworkClientViewModel._tcpClient.Received += _SourceControlViewModel.ParseJSONDataToSourceModel;
        }

        public void CastTransmissionDataToMesageDataAndSend(byte[] data)
        {
            //Sets the length of byte byte buffer to send 
            _TranmissionHeader.MessageSize = (uint)data.Length;
            byte[] TransmissionHeder = StructUtils.RawSerialize(_TranmissionHeader);
            TransmissionHeder.CopyTo(_MessageContentTrasmitBuffer, 0);
            data.CopyTo(_MessageContentTrasmitBuffer, 16);
            _NetworkClientViewModel.OnSend(_MessageContentTrasmitBuffer);
        }

        public void CastRecievedBytesToSourceMessage(object obj, RecievedDataByteBuffer arg)
        {
            byte[] Header = new byte[16];
            Buffer.BlockCopy(arg.Message, 0, Header, 0, 16);
            _RecievedHeader = StructUtils.RawDeserialize<MessagePacketHeader>(Header, 0);
            if(_RecievedHeader.Header == 0xDEADBEEFBEEFFEED)
            {
                arg.Message.CopyTo(_MessageContentRecieveBuffer, 0);
                Buffer.BlockCopy(arg.Message, 16, _MessageContentRecieveBuffer,0, arg.Message.Length -16);
                _SourceControlViewModel.ParseJSONDataToSourceModel(_MessageContentRecieveBuffer);
            }
        }


    }
}
