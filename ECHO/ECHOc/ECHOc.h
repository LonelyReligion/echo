#pragma once
#ifdef HP2C_EXPORTS
#define HP2C_API __declspec(dllexport)
#else
#define HP2C_API __declspec(dllimport)
#endif

extern "C" HP2C_API int GenerujEcho(int a, int b);