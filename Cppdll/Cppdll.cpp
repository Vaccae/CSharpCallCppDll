// Cppdll.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "Cppdll.h"
#include <cmath>

int Cppdll_API AddCount(int a, int b)
{
	return a + b;
}

int Cppdll_API call_func(cb callback, int a, int b)
{
	int c = AddCount(a, b);
	int d = abs(a - b);
	return callback(c, d);
}
