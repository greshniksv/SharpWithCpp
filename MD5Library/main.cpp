#include<stdio.h>
#include<windows.h>
#include <cstdio>
#include <iostream>
#include "md5.h"

using namespace std;

extern "C" __declspec(dllexport) char* GetMd5(char* data, int count);

char* GetMd5(char* data, int count){
	if(count>1){
		for(int i=0;i<count;i++){
			strdup(md5(data).c_str());
		}
	}
	return strdup(md5(data).c_str());
}