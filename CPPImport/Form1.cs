using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CPPImport
{
    public partial class Form1 : Form
    {
        //声明C++动态库的调用方法
        [DllImport("Cppdll", EntryPoint = "AddCount",
            CallingConvention = CallingConvention.StdCall)]
        public static extern int GetNewInt(int num1, int num2);

        //C++回调函数
        [DllImport("Cppdll", EntryPoint = "call_func",
            CallingConvention = CallingConvention.StdCall)]
        public static extern int CallFun(Dllcallback dcb, int num1, int num2);

        //声明回调函数
        //CallingConvention.Cdecl这个是要声明的，默认C++的指针都是这个样
        //如果这里不声明后调用时会默认_stdcall,就会报错
        //动态调用dll函数的时候，提示Run-Time Check Failure #0 -
        //The value of ESP was not properly saved across a function call.
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int Dllcallback(int num1, int num2);

        public int Call(int a, int b)
        {
            textBox1.AppendText("回调函数第一个参数为：" + a + "\r\n");
            textBox1.AppendText("回调函数第二个参数为：" + b + "\r\n");
            return a + b;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //清空textbox
            textBox1.Clear();

            //生成两个随机数
            Random rd = new Random();
            int num1 = rd.Next(0, 100); //取一个0-100的随机数
            textBox1.AppendText("第一个随机数为：" + num1 + "\r\n");

            int num2 = rd.Next(100, 200); //取一个100-200的随机数
            textBox1.AppendText("第二个随机数为：" + num2 + "\r\n\r\n");

            //调用C++动态库
            textBox1.AppendText("调用C++动态库AddCount函数\r\n");
            int num = GetNewInt(num1, num2);
            textBox1.AppendText("得到的两个数相加之和为：" + num + "\r\n\r\n");

            //调用C++回调函数
            textBox1.AppendText("调用C++动态库call_func回调函数\r\n");
            num = CallFun(Call, num1, num2);
            textBox1.AppendText("得到两个数相加：" + num + "\r\n");

        }
    }
}
