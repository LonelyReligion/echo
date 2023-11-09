#include "pch.h"
#include "ECHOc.h"

int GenerujEcho(unsigned char* wartosci_rgb, int dlugosc_tablicy, int index, int stride, int width, int len, unsigned char* wartosci_rgb_cpy) {
	int wiersz = index / stride;
	int kolumna = index % stride;
	
	int index_wzgledny = index;

	const int ostatnia_kolumna = width * 3;
	const int przesunicie = 8;

	unsigned char* wskaznik = wartosci_rgb + index;
	unsigned char* wskaznik_cpy = index_wzgledny + wartosci_rgb_cpy;

	while(wskaznik < dlugosc_tablicy + index + wartosci_rgb /* && wskaznik_cpy < wartosci_rgb_cpy + index + dlugosc_tablicy && wskaznik_cpy > wartosci_rgb_cpy*/) {
		if (kolumna != ostatnia_kolumna) {
			//zeby krawedzie sie nie zmienialy
			if ((wskaznik - 3 * przesunicie) > (wartosci_rgb + wiersz * stride) && (wskaznik+ 3 * przesunicie) < (wartosci_rgb + wiersz * stride + ostatnia_kolumna)) {
				*wskaznik = *(index_wzgledny + wartosci_rgb_cpy - 3 * przesunicie) * 0.2; //!
				if ((wskaznik_cpy - 3 * przesunicie * 4) > (wartosci_rgb_cpy + wiersz * stride) && (wskaznik_cpy + 3 * przesunicie * 4) < (wartosci_rgb_cpy + wiersz * stride + ostatnia_kolumna)) {
					*wskaznik += *(wskaznik_cpy - 3 * przesunicie * 4) * 0.1;
					*wskaznik += *(wskaznik_cpy + 3 * przesunicie) * 0.7;
				}
				else
					*wskaznik += *(wskaznik_cpy + 3 * przesunicie) * 0.8;
			}
			kolumna++;
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