#include "pch.h"
#include "ECHOc.h"

int GenerujEcho(unsigned char* wartosci_rgb, int dlugosc_tablicy, int index, int stride, int width) {
	//it = rz¹d * stride + kolumna
	int wiersz = index / stride;
	int kolumna = index % stride;
	int index_wzgledny = index;
	
	int ostatnia_kolumna = width*3;

	while(index_wzgledny + wartosci_rgb < dlugosc_tablicy + index + wartosci_rgb) {
		
		*(index_wzgledny + wartosci_rgb) += 5;

		if(kolumna != ostatnia_kolumna)
			kolumna += 1;
		else {
			wiersz++;
			kolumna = 0;
		}

		index_wzgledny = wiersz * stride + kolumna;
	};

	return 0;
}