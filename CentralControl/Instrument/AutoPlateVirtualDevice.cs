using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTLutils;

namespace Instrument
{
    public class MPFDispenMessage
    {
        public String Barcode;//条码号
        public String PlateNum;//孔板数

        public MPFDispenMessage()
        {
            Barcode = PlateNum = "";
        }

    }

    public class AutoPlateVirtualDevice : BaseVirtualDevice
    {
        /// <summary>
        /// MPF parameters
        /// </summary>
        public int MPF_PlateNum;
        public double MPF_Volsperwell;
        public int MPF_CurSamTime;
        public string MPF_Cmd;
        public int MPF_Whichplate = 1;
        public int MPF_RunningError;
        public int MPF_DispenTime;
        public double MPF_Current1;
        public double MPF_Current2;
        public double MPF_Current3;
        public double MPF_Current4;
        public string MPF_BarCode;

        public void sendOKResponse()
        {
            SendModBusMsg(ModbusMessage.MessageType.RESPONSE, "Result", "OK");
        }

        public override void decodeCmdMessage(ModbusMessage msg)
        {
            String cmd = (String)msg.Data["Cmd"];
            if ("Start".Equals(cmd))
            {
                this.MPF_Cmd = "Start";
            }
            if ("Reset".Equals(cmd))
            {
                this.MPF_Cmd = "Reset";
            }
            if ("Stop".Equals(cmd))
            {
                this.MPF_Cmd = "Stop";
            }
            if ("Auto".Equals(cmd))
            {
                this.MPF_Cmd = "Auto";
            }

            this.sendOKResponse();
        }

    }
}
