#include<stdio.h>
#include<windows.h>
#include <cstdio>
#include <iostream>
#include "md5.h"

using namespace std;

//extern "C" __declspec(dllexport) int MultiplyByTen(int numberToMultiply);
extern "C" __declspec(dllexport) char* GetMd5(char* data, int count);

char* GetMd5(char* data, int count){
	return strdup(md5(data).c_str());
}