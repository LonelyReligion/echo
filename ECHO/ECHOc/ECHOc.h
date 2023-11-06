#pragma once
#ifdef HP2C_EXPORTS
#define HP2C_API __declspec(dllexport)
#else
#define HP2C_API __declspec(dllimport)
#endif

extern "C" HP2C_API int GenerujEcho(unsigned char* wartosci_rgb, int dlugosc_tablicy, int index, int stride, int width, int len);