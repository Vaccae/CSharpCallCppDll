#pragma once

typedef int(*cb)(int, int);

//����#define������Cppdll_API�ĺ����� 
//_declspec(dllexport)���������������ⲿ����
//_stdcall  Windows APIĬ�ϵĺ�������Э��
#define Cppdll_API  _declspec(dllexport) _stdcall	


//����������extern "C",������ӵĻ�C#����ʱ���Ҳ�����ڷ�����
//����һ��AddCount�ķ�����������int�Ĳ���������Ϊint��ֵ
extern "C" int Cppdll_API AddCount(int a, int b);

extern "C" int Cppdll_API call_func(cb callback, int a, int b);