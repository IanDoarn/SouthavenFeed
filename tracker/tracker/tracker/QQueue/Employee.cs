using System.Text;

namespace tracker.QQueue
{
    public sealed class Employee
    {
        public string EMPLOYEE { get; set; }
        public int KIT_INBOUND_TRANSFER { get; set; }
        public int PIECE_INBOUND_TRANSFER { get; set; }
        public int INSTRUMENT_INBOUND_TRANSFER { get; set; }
        public int PUTAWAY_TRANSFER { get; set; }
        public int KIT_BUILD_TRANSFER { get; set; }
        public int OUTBOUND_TRANSFER { get; set; }
        public int OTHER_TRANSFER { get; set; }
        public double TOTAL_PRODUCTIVITY { get; set; }

        public Employee(
            string EMPLOYEE,
            int KIT_INBOUND_TRANSFER, int PIECE_INBOUND_TRANSFER,
            int INSTRUMENT_INBOUND_TRANSFER, int PUTAWAY_TRANSFER,
            int KIT_BUILD_TRANSFER, int OUTBOUND_TRANSFER,
            int OTHER_TRANSFER, double TOTAL_PRODUCTIVITY
            )
        {
            this.EMPLOYEE = EMPLOYEE;
            this.KIT_INBOUND_TRANSFER = KIT_INBOUND_TRANSFER;
            this.PIECE_INBOUND_TRANSFER = PIECE_INBOUND_TRANSFER;
            this.INSTRUMENT_INBOUND_TRANSFER = INSTRUMENT_INBOUND_TRANSFER;
            this.PUTAWAY_TRANSFER = PUTAWAY_TRANSFER;
            this.KIT_BUILD_TRANSFER = KIT_BUILD_TRANSFER;
            this.OUTBOUND_TRANSFER = OUTBOUND_TRANSFER;
            this.OTHER_TRANSFER = OTHER_TRANSFER;
            this.TOTAL_PRODUCTIVITY = TOTAL_PRODUCTIVITY;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"EMPLOYEE: {0} KIT_INBOUND_TRANSFER: {1} PIECE_INBOUND_TRANSFER: {2} INSTRUMENT_INBOUND_TRANSFER: {3} PUTAWAY_TRANSFER: {4} KIT_BUILD_TRANSFER: {5} OUTBOUND_TRANSFER: {6} OTHER_TRANSFER: {7} TOTAL_PRODUCTIVITY: {8}",
                    this.EMPLOYEE,
                    this.KIT_INBOUND_TRANSFER,
                    this.PIECE_INBOUND_TRANSFER,
                    this.INSTRUMENT_INBOUND_TRANSFER,
                    this.PUTAWAY_TRANSFER,
                    this.KIT_BUILD_TRANSFER,
                    this.OUTBOUND_TRANSFER,
                    this.OTHER_TRANSFER,
                    this.TOTAL_PRODUCTIVITY);
            return sb.ToString();
        }
    }

}
