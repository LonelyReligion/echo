#include "pch.h"
#include "ECHOc.h"

int GenerujEcho(unsigned char* wartosci_rgb, int dlugosc_tablicy, int index, unsigned char* wartosci_rgb_cpy, int ostatnia_kolumna, int stride) {
	int wiersz = index / stride;
	int kolumna = index % stride;
	
	int index_wzgledny = index;

	const int przesunicie = 24;

	unsigned char* wskaznik = wartosci_rgb + index;
	unsigned char* wskaznik_cpy = index_wzgledny + wartosci_rgb_cpy;

	while(wskaznik < dlugosc_tablicy + index + wartosci_rgb) { //zrobione w asm
		if (kolumna != ostatnia_kolumna) { //zrobione w asm
			//zeby krawedzie sie nie zmienialy
			kolumna++;
			if ((wskaznik - przesunicie) > (wartosci_rgb + wiersz * stride) && (wskaznik + przesunicie) < (wartosci_rgb + wiersz * stride + ostatnia_kolumna)) { //zrobione w asm
				*wskaznik = *(wskaznik_cpy - przesunicie) * 0.2; //zrobione w asm
				if ((wskaznik_cpy - przesunicie * 4) > (wartosci_rgb_cpy + wiersz * stride) && (wskaznik_cpy + przesunicie * 4) < (wartosci_rgb_cpy + wiersz * stride + ostatnia_kolumna)) {//zrobione w asm
					;// *wskaznik += *(wskaznik_cpy - przesunicie * 4) * 0.1; //zrobione w asm
					;// *wskaznik += *(wskaznik_cpy + przesunicie) * 0.7; //zrobione w asm
				}
				else
					;// *wskaznik += *(wskaznik_cpy + przesunicie) * 0.8;
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