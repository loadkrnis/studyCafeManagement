using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;

using System.Drawing.Imaging;
using System.Globalization;

namespace StudyCafeManagement
{
    class PrinterHelper
    {
        public static void Print(DataAccess DB)
        {
            CultureInfo cultures = CultureInfo.CreateSpecificCulture("ko-KR");
            string date = DateTime.Now.ToString(string.Format("yyyy년 MM월 dd일 ddd요일", cultures));
            string time;
            if (DB.SelectTime == "day") time = "24시간";
            else time = DB.SelectTime + "시간";
            string charge = String.Format("{0:#,0}", Convert.ToInt32(DB.SelectCharge));
            string supply = String.Format("{0:#,0}", (Convert.ToInt32(DB.SelectCharge)*0.1));
            string vat = String.Format("{0:#,0}", (Convert.ToInt32(DB.SelectCharge) * 0.9));

            string szString = "SAM4S(C)" + "\n\n";
            szString += "777-77-77777  BONG\n";
            szString +=  DB.BrachAddress + "\n";
            szString += "Tel : 010-4261-4444\n";
            szString +=  date + "  No."+ DB.BranchId + DateTime.Now.ToString(string.Format("yyyyMMdd", cultures))+"\n\n";
            szString += "신문화를 창조하는 Book & Cup \n";
            szString += "항상 최고로 모시겠습니다.\n\n";
            szString += "------------------------------------------\n";
            szString += "상  품                             금 액\n";
            szString += "------------------------------------------\n";
            szString += "독서실 이용("+time+")               "+charge+"원\n";
            szString += "면세 공급가                            0원\n";
            szString += "과세 공급가                        "+supply+"원\n";
            szString += "부가 가치세                       "+vat+"원\n\n";
            szString += "------------------------------------------\n";
            szString += "SAM4S 보너스 카드\n\n";
            szString += "3개월                             "+charge+"원\n";
            szString += "카드:3333-55**-*666-111            ****/**\n";
            szString += "승인:55994411      청구금액:      "+charge+"원\n";
            szString += "승인 시간: 170411063003\n\n";
            szString += "총 품목수 : 1              총 구매수량 : 1\n\n";
            szString += "본 영수증은 스터디카페 입장시 필요합니다.\n";
            szString += "잘 보관하시기 바랍니다. 감사합니다.";
            szString += "                                                                                                                  \n";
            szString += "                                                                                                                  \n";
            string szPrinterName = Program.printerName;
            string code = DB.PhoneNumber;
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);





            string testStr = code;
            byte[] tempByte = Encoding.Default.GetBytes(testStr);

            Byte[] bytes = new Byte[tempByte.Length + 7];
            bool bSuccess = false;

            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = bytes.Length;

            // Set Barcode Height
            bytes[0] = 29;
            bytes[1] = 104;
            bytes[2] = 90;

            // Print Barcode
            bytes[3] = 29;
            bytes[4] = 107;
            // Barcode Type : Code128
            bytes[5] = 73;
            bytes[6] = (byte)tempByte.Length;

            for (int i = 0; i < tempByte.Length; i++)
            {
                bytes[7 + i] = tempByte[i];
            }

            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(Program.printerName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            
        }

        public static void RePrint(DataAccess DB)
        {
            CultureInfo cultures = CultureInfo.CreateSpecificCulture("ko-KR");
            string date = DateTime.Now.ToString(string.Format("yyyy년 MM월 dd일 ddd요일", cultures));
            string time;
            if (DB.SelectTime == "day") time = "24시간";
            else time = DB.SelectTime + "시간";
            string charge = String.Format("{0:#,0}", Convert.ToInt32(DB.SelectCharge));
            string supply = String.Format("{0:#,0}", (Convert.ToInt32(DB.SelectCharge) * 0.1));
            string vat = String.Format("{0:#,0}", (Convert.ToInt32(DB.SelectCharge) * 0.9));

            string szString = "SAM4S(C)" + "\n\n";
            szString += "777-77-77777  BONG\n";
            szString += DB.BrachAddress + "\n";
            szString += "Tel : 010-4261-4444\n";
            szString += date + "  No." + DB.BranchId + DateTime.Now.ToString(string.Format("yyyyMMdd", cultures)) + "\n\n";
            szString += "신문화를 창조하는 Book & Cup \n";
            szString += "항상 최고로 모시겠습니다.\n\n";
            szString += "본 바코드는 스터디카페 입장시 필요합니다.\n";
            szString += "잘 보관하시기 바랍니다. 감사합니다.\n";
            szString += "------------------------------------------\n";
            szString += "             바 코 드 재 발 급          \n";
            szString += "------------------------------------------";
            szString += "                                                                                                                  ";
            szString += "                                                                                                                  ";
            string szPrinterName = Program.printerName;
            string code = DB.PhoneNumber;
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);





            string testStr = code;
            byte[] tempByte = Encoding.Default.GetBytes(testStr);

            Byte[] bytes = new Byte[tempByte.Length + 7];
            bool bSuccess = false;

            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = bytes.Length;

            // Set Barcode Height
            bytes[0] = 29;
            bytes[1] = 104;
            bytes[2] = 90;

            // Print Barcode
            bytes[3] = 29;
            bytes[4] = 107;
            // Barcode Type : Code128
            bytes[5] = 73;
            bytes[6] = (byte)tempByte.Length;

            for (int i = 0; i < tempByte.Length; i++)
            {
                bytes[7 + i] = tempByte[i];
            }

            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(Program.printerName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);

        }
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;  
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }

        #region DllImport to Control the Printer

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        #endregion

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "SAM4S PRINTER CONTROL EXAMPLE";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        /// <summary>
        /// Open Printer Cash Drawer
        /// </summary>
        /// <param name="drawNo">Drawer Number (1 or 2)</param>
        /// <param name="time">Open Time</param>
        /// <returns></returns>
        public static bool OpenCashDrawer(byte drawNo, byte time)
        {
            Byte[] bytes = new Byte[5];
            bool bSuccess = false;

            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = 5;

            // Drawer Control Command
            bytes[0] = 27;
            bytes[1] = 112;

            // Drawer Pin No
            if (drawNo == 1)
                // Drawer Connector Pin2
                bytes[2] = 48;
            else
                // Drawer Connector Pin5
                bytes[2] = 49;

            // On Time
            bytes[3] = time;

            // Off time
            bytes[4] = 0;

            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(Program.printerName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);

            return bSuccess;
        }

        /// <summary>
        /// Partial Cut Without Feed
        /// </summary>
        /// <returns></returns>
        public static bool PartialCut()
        {
            Byte[] bytes = new Byte[3];
            bool bSuccess = false;

            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = 3;

            // Cut Control Command
            bytes[0] = 29;
            bytes[1] = 86;
            bytes[2] = 49;

            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(Program.printerName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);

            return bSuccess;
        }

        /// <summary>
        /// Partial Cut
        /// </summary>
        /// <param name="feedLength"></param>
        /// <returns></returns>
        public static bool PartialCut(byte feedLength)
        {
            Byte[] bytes = new Byte[12];
            bool bSuccess = false;

            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = 12;

            // Feed and Cut Control Command
            bytes[0] = 29;
            bytes[1] = 86;
            bytes[2] = 66;
            bytes[3] = feedLength;

            bytes[4] = 29;
            bytes[5] = 86;
            bytes[6] = 66;
            bytes[7] = feedLength;

            bytes[8] = 29;
            bytes[9] = 86;
            bytes[10] = 66;
            bytes[11] = feedLength;

            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(Program.printerName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);

            return bSuccess;
        }

        /// <summary>
        /// Send String to Printer
        /// </summary>
        /// <param name="szPrinterName"></param>
        /// <param name="szString"></param>
        /// <returns></returns>
        public static bool SendStringToPrinter(string szPrinterName, string szString, string code)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);





            string testStr = code;
            byte[] tempByte = Encoding.Default.GetBytes(testStr);

            Byte[] bytes = new Byte[tempByte.Length + 7];
            bool bSuccess = false;

            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = bytes.Length;

            // Set Barcode Height
            bytes[0] = 29;
            bytes[1] = 104;
            bytes[2] = 90;

            // Print Barcode
            bytes[3] = 29;
            bytes[4] = 107;
            // Barcode Type : Code128
            bytes[5] = 73;
            bytes[6] = (byte)tempByte.Length;

            for (int i = 0; i < tempByte.Length; i++)
            {
                bytes[7 + i] = tempByte[i];
            }

            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(Program.printerName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);

            return true;
        }

        /// <summary>
        /// Send File to Printer
        /// </summary>
        /// <param name="szPrinterName"></param>
        /// <param name="szFileName"></param>
        /// <returns></returns>
        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            fs.Close();

            return bSuccess;
        }

        /// <summary>
        /// Print Barcode
        /// </summary>
        /// <returns></returns>
        public static bool PrintBarcode(string code)
        {
            // Barcode Data
            string testStr = code;
            byte[] tempByte = Encoding.Default.GetBytes(testStr);

            Byte[] bytes = new Byte[tempByte.Length + 7];
            bool bSuccess = false;

            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = bytes.Length;

            // Set Barcode Height
            bytes[0] = 29;
            bytes[1] = 104;
            bytes[2] = 90;

            // Print Barcode
            bytes[3] = 29;
            bytes[4] = 107;
            // Barcode Type : Code128
            bytes[5] = 73;
            bytes[6] = (byte)tempByte.Length;

            for (int i = 0; i < tempByte.Length; i++)
            {
                bytes[7 + i] = tempByte[i];
            }

            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(Program.printerName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);

            return bSuccess;
        }
    }
}
