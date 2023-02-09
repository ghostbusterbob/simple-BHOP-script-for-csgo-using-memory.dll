using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Memory;
using System.Runtime.InteropServices;





namespace BHOP
{
	public partial class Form1 : Form
	{
		[DllImport("user32.dll")]

		

		static extern short GetAsyncKeyState(Keys vkey);
		Mem m = new Mem();
		int flag;
		string client = "client.dll";
		string allentity = "0x4DFFEF4";
		string mteamNumber = "0xF4"; 
		string ForceJump = "client.dll+0x52BBC7C";
		string localandflag = "client.dll+0xDEA964,0x104";
		string hp = "0x100";
		string spotted = "0x93D";
		int i = 0;



		struct offets
		{
			public static int  allentity = 0x4DFFEF4;
			public static int TeamNumb = 0xF4;
			
		}
		
		

		

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			

			int PID = m.GetProcIdFromName("csgo");
			if(PID > 0)
			{
				m.OpenProcess(PID);
				label1.Text = "Detected";
				Thread bh = new Thread(hop){ IsBackground = true };
				Thread tb = new Thread(TriggerBot) { IsBackground = true };
				
				bh.Start();
				tb.Start();
				
			}else if (PID == 0)
			{
				label1.Text = "CSGO is not Detected, please launch your CSGO";
			}
		}

		void hop()
		{
			while (true)
			{
				if (checkBox1.Checked)
				{
					if (GetAsyncKeyState(Keys.Space) < 0)
					{
						flag = m.ReadInt(localandflag);
						if (flag == 257)
						{
							m.WriteMemory(ForceJump, "int", "6");
							Thread.Sleep(20);
						}
					}
				}
				Thread.Sleep(1);
			}
		}

		void TriggerBot()
		{
			
			
		}

		void Read()
		{
			
			
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void label1_Click_1(object sender, EventArgs e)
		{

		}
	}
}
