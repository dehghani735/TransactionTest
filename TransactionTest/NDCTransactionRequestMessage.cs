using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTest
{
    public abstract class NDCTransactionRequestMessage
    {
        private string _header = "11" + "\u001C" + "000" + "\u001C" + "\u001C" + "\u001C";
        private string _topOfReceiptTransactionFlag = "1";
        private string _messageCoordinationNumber = "8";
        private string _track2Data;
        private string _track3Data;
        private string _operationCodeData;
        private string _amountEntryField;
        private string _pinBufferA;
        private string _generalPurposeBufferB;
        private string _generalPurposeBufferC;
        private string _track1Identifier;
        private string _track1Data;
        private string _transactionStatusDataIdentifier;
        private string _lastTransactionStatusData;

        private StringBuilder _requestMessage;

        public string RequestMessage
        {
            get { return _requestMessage.ToString(); }
            set { _requestMessage.Append(value); }
        }

        public string Header
        {
            get { return _header; }
        }

        public string TopOfReceiptTransactionFlag
        {
            get { return _topOfReceiptTransactionFlag; }
            set { _topOfReceiptTransactionFlag = value; }
        }

        public string MessageCoordinationNumber
        {
            get { return _messageCoordinationNumber; }
            set { _messageCoordinationNumber = value; }
        }

        public string Track2Data
        {
            get { return _track2Data; }
            set { _track2Data = value; }
        }

        public string Track3Data
        {
            get { return _track3Data; }
            set { _track3Data = value; }
        }

        public string OperationCodeData
        {
            get { return _operationCodeData; }
            set { _operationCodeData = value; }
        }

        public string AmountEntryField
        {
            get { return _amountEntryField; }
            set { _amountEntryField = value; }
        }

        public string PinBufferA
        {
            get { return _pinBufferA; }
            set { _pinBufferA = value; }
        }

        public string GeneralPurposeBufferB
        {
            get { return _generalPurposeBufferB; }
            set { _generalPurposeBufferB = value; }
        }

        public string GeneralPurposeBufferC
        {
            get { return _generalPurposeBufferC; }
            set { _generalPurposeBufferC = value; }
        }

        public string Track1Identifier
        {
            get { return _track1Identifier; }
            set { _track1Identifier = value; }
        }

        public string Track1Data
        {
            get { return _track1Data; }
            set { _track1Data = value; }
        }

        public string TransactionStatusDataIdentifier
        {
            get { return _transactionStatusDataIdentifier; }
            set { _transactionStatusDataIdentifier = value; }
        }

        public string LastTransactionStatusData
        {
            get { return _lastTransactionStatusData; }
            set { _lastTransactionStatusData = value; }
        }

        public NDCTransactionRequestMessage()
        {
            _requestMessage = new StringBuilder();
            Track2Data = ";5894631511409724=99105061710399300020?";
            Track3Data = "";
            PinBufferA = "&gt;106&lt;?1&gt;82&lt;7&gt;9=2";
            TransactionStatusDataIdentifier = "20000100000000000000000000";
            LastTransactionStatusData = "";
        }

        //public abstract void ali();


        public virtual string getNDCTransactionRequestMessage()
        {
            _requestMessage.Append(_header);
            _requestMessage.Append(_topOfReceiptTransactionFlag);
            _requestMessage.Append(_messageCoordinationNumber);
            _requestMessage.Append("\u001C");
            _requestMessage.Append(_track2Data);
            _requestMessage.Append("\u001C");
            _requestMessage.Append(_track3Data);
            _requestMessage.Append("\u001C");
            _requestMessage.Append(_operationCodeData);
            _requestMessage.Append("\u001C");
            _requestMessage.Append(_amountEntryField);
            _requestMessage.Append("\u001C");
            _requestMessage.Append(_pinBufferA);
            _requestMessage.Append("\u001C");
            _requestMessage.Append("\u001C");
            _requestMessage.Append("\u001C");
            _requestMessage.Append("\u001C");
            _requestMessage.Append(_transactionStatusDataIdentifier);
            _requestMessage.Append(_lastTransactionStatusData);

            return _requestMessage.ToString()
                .Replace("&#28;", "\u001C")
                .Replace("&gt;", "\u003E")
                .Replace("&lt;", "\u003C");
        }

        static void Main()
        {
            // NDCTransactionRequestMessage transactionRequestMessage = new NDCTransactionRequestMessage();
            //Console.WriteLine(transactionRequestMessage.getNDCTransactionRequestMessage());
        }
    }
}