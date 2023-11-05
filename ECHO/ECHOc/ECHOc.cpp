#include "pch.h"
#include "ECHOc.h"

int GenerujEcho(unsigned char * wartosci_rgb, int dlugosc_tablicy, int index, int stride, int width, int height) {
	//it = rz¹d * stride + kolumna
	//unsigned char* wartosci_rgb_cpy = new unsigned char[dlugosc_tablicy];
	//memcpy(wartosci_rgb_cpy, wartosci_rgb + index, dlugosc_tablicy);

	for (int i = 0; i < height; i++) { //dla kazdego wiersza
		for (int j = 0; j < width * 3; j++) { //dla kazdej kolumny
			int index_wzgledny = i * stride + j;
			int index_bezwzgledny = index + index_wzgledny;

			unsigned char* p = wartosci_rgb + index_bezwzgledny;
			//unsigned char* p_cpy = wartosci_rgb_cpy + index_wzgledny;

			if (p > wartosci_rgb + dlugosc_tablicy) {
				return 0;
			};

			*p += 5;
			//*p += (p_cpy - 1 > wartosci_rgb_cpy ? *(p_cpy - 1) : 0);
			//*p -= (p_cpy + 1 < wartosci_rgb_cpy + dlugosc_tablicy ? *(p_cpy + 1) : 0);
		};
	};
	return 0;
}