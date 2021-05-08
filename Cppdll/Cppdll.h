#pragma once

typedef int(*cb)(int, int);

//利用#define定义了Cppdll_API的宏命令 
//_declspec(dllexport)声明导出函数供外部调用
//_stdcall  Windows API默认的函数调用协议
#define Cppdll_API  _declspec(dllexport) _stdcall	


//这里必须加入extern "C",如果不加的话C#调用时会找不到入口方法名
//定义一个AddCount的方法名，两个int的参数，返回为int的值
extern "C" int Cppdll_API AddCount(int a, int b);

extern "C" int Cppdll_API call_func(cb callback, int a, int b);