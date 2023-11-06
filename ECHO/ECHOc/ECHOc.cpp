#include "pch.h"
#include "ECHOc.h"

int GenerujEcho(unsigned char* wartosci_rgb, int dlugosc_tablicy, int index, int stride, int width, int height) {
	//it = rz¹d * stride + kolumna
	int wiersz = index / stride;
	int kolumna = index % stride;
	int index_wzgledny = 0;
	
	while(index_wzgledny + wartosci_rgb < dlugosc_tablicy + wartosci_rgb) {
		*(index_wzgledny + wartosci_rgb) += 5;

		wiersz++;
		kolumna += 3;

		index_wzgledny = wiersz * stride + kolumna;
	};

	return 0;
}