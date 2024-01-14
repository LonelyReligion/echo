#include "pch.h"
#include "ECHOc.h"

int GenerujEcho(unsigned char* wartosci_rgb, int dlugosc_tablicy, int index, unsigned char* wartosci_rgb_cpy, int ostatnia_kolumna, int stride) {
	int wiersz = index / stride;
	int kolumna = index % stride;
	
	int index_wzgledny = index;

	const int przesunicie = 24;

	unsigned char* wskaznik = wartosci_rgb + index;
	unsigned char* wskaznik_cpy = index + wartosci_rgb_cpy;

	while(wskaznik < dlugosc_tablicy + index + wartosci_rgb) { 
		if (kolumna != ostatnia_kolumna) { 
			//zeby krawedzie sie nie zmienialy
			kolumna++;
			if ((wskaznik - przesunicie) > (wartosci_rgb + wiersz * stride) && (wskaznik + przesunicie) < (wartosci_rgb + wiersz * stride + ostatnia_kolumna)) { 
				*wskaznik = *(wskaznik_cpy - przesunicie) * 3 / 16;
				if ((wskaznik_cpy - przesunicie * 4) > (wartosci_rgb_cpy + wiersz * stride) && (wskaznik_cpy + przesunicie * 4) < (wartosci_rgb_cpy + wiersz * stride + ostatnia_kolumna)) {//te warunki to problem
					*wskaznik += *(wskaznik_cpy - przesunicie * 4) / 16;
					*wskaznik += *(wskaznik_cpy + przesunicie) * 6 / 8;
				}
				else
					*wskaznik += *(wskaznik_cpy + przesunicie) * 13 / 16; //i to
			}
		}
		else {
			wiersz++;
			kolumna = 0;
		}
		index_wzgledny = wiersz * stride + kolumna;
		wskaznik = index_wzgledny + wartosci_rgb;
		wskaznik_cpy = index_wzgledny + wartosci_rgb_cpy;
	};

	return 0;
}