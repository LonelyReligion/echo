#include "pch.h"
#include "ECHOc.h"

int GenerujEcho(unsigned char* wartosci_rgb, int dlugosc_tablicy, int index, int stride, int width) {
	//it = rz¹d * stride + kolumna
	int wiersz = index / stride;
	int kolumna = index % stride;
	
	int index_wzgledny = index;

	int ostatnia_kolumna = width*3;

	int przesunicie = 6;

	unsigned char* wartosci_rgb_cpy = new unsigned char[dlugosc_tablicy];
	memcpy(wartosci_rgb_cpy, wartosci_rgb, dlugosc_tablicy);

	unsigned char* wskaznik;
	unsigned char* wskaznik_cpy;

	wskaznik = index_wzgledny + wartosci_rgb;
	wskaznik_cpy = index_wzgledny + wartosci_rgb_cpy;

	while(index_wzgledny + wartosci_rgb < dlugosc_tablicy + index + wartosci_rgb) {

		//*wskaznik += 5;
		
		if (kolumna != ostatnia_kolumna) {
			//zeby krawedzie sie nie zmienialy
			if ((wskaznik_cpy - 3 * przesunicie) > (wartosci_rgb_cpy + wiersz * stride) && (wskaznik_cpy + 3 * przesunicie) < (wartosci_rgb_cpy + wiersz * stride + ostatnia_kolumna)) {
				//*wskaznik = 0;
				*wskaznik = *(wskaznik_cpy - 3 * przesunicie) * 0.2; //!
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