using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTLutils;

namespace Instrument
{
    public class MDFDispenMessage
    {
        public String Barcode;//条码号
        public String Stackcode;//堆码号
        public String Petricode;//培养皿号
		
        public MDFDispenMessage()
        {
            Barcode = Stackcode = Petricode = "";
        }
    }

    public class AutoDispenVirtualDevice : BaseVirtualDevice
    {
        /// <summary>
        /// MDF parameters
        /// </summary>
        public int MDF_NumsperStack = 0;
        public double MDF_VolsperDish = 0;
        public double MDF_Current1;
        public double MDF_Current2;
        public double MDF_Current3;
        public double MDF_Current4;
        public int MDF_RunningError;
        public int MDF_DispenTime;
        public int MDF_CurSamTime;
        public int MDF_WhichStack = 1;
        public int MDF_WhichDish = 1;
        public string MDF_BarCode;
        public string MDF_Cmd;


        public void sendOKResponse()
        {
            SendModBusMsg(ModbusMessage.MessageType.RESPONSE, "Result", "OK");
        }

        public override void decodeCmdMessage(ModbusMessage msg)
        {
            String cmd = (String)msg.Data["Cmd"];

            if ("Start".Equals(cmd))
            {
                this.MDF_Cmd = "Start";
            }
            if ("Reset".Equals(cmd))
            {
                MDF_WhichDish = 1;
                MDF_WhichStack = 1;
                this.MDF_Cmd = "Reset";
            }
            if ("Stop".Equals(cmd))
            {
                this.MDF_Cmd = "Stop";
            }
            if ("Auto".Equals(cmd))
            {
                this.MDF_Cmd = "Auto";
            }

            this.sendOKResponse();
        }

    }
}