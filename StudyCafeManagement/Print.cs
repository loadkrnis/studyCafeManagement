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

namespace StudyCafeManagement
{
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
            Program.applicationPath = Environment.CurrentDirectory;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // This receipt is written by Korean,
                // You can change as your own language

                string printStr = "SAM4S(C)" + "\n\n";
                printStr += "777-77-77777  BONG\n";
                printStr += "서울시 금천구 가산동 371-28\n";
                printStr += "Tel : 02-777-8888\n";
                printStr += "2011년 06월 16일 일요일  No.555555-7777\n\n";
                printStr += "신문화를 창조하는 SAM4S 플라자\n";
                printStr += "항상 최고로 모시겠습니다.\n\n";
                printStr += "------------------------------------------\n";
                printStr += "상  품                수량         금 액\n";
                printStr += "------------------------------------------\n";
                printStr += "001 켐코더(SPT-53MEF)        9,000,000 (*)\n";
                printStr += "2096790005033   8902    1    9,000,000 원\n\n";
                printStr += "면세 공급가                            0원\n";
                printStr += "과세 공급가                      7,500,000\n";
                printStr += "부가 가치세                      1,500,000\n\n";
                printStr += "매출액    9,000,000원\n";
                printStr += "받는돈    9,000,000원\n";
                printStr += "거스름돈             0원\n";
                printStr += "------------------------------------------\n";
                printStr += "SAM4S 보너스 카드\n\n";
                printStr += "3개월                          9,000,000원\n";
                printStr += "카드:3333-55**-*666-111            ****/**\n";
                printStr += "승인:55994411      청구금액:   9,000,000원\n";
                printStr += "승인 시간: 170411063003\n\n";
                printStr += "총 품목수 : 1              총 구매수량 : 1\n\n";
                printStr += "(*)표시는   과세  품목입니다.\n";
                printStr += "본 영수증은 교환 및 환불시 필요합니다.\n";
                printStr += "잘 보관하시기 바랍니다. 감사합니다.\n\n";
                printStr += "17시04분13초              담당자: 김하늘\n";

                // Blank String to Print out properly
                printStr += "                                                                                                                  \n";
                printStr += "                                                                                                                  \n";
                PrinterHelper.SendStringToPrinter(Program.printerName, printStr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Print Receipt");
            }

        }
    }
}
