#pragma once

#ifdef ECHO_DLL_C_EXPORTS
#define ECHO_DLL_C_API __declspec(dllexport)
#else
#define ECHO_DLL_C_API __declspec(dllimport)
#endif

//extern "C" __declspec(dllexport) int multiplication(int a, int b);
extern "C" ECHO_DLL_C_API int multiplication(int a, int b);
