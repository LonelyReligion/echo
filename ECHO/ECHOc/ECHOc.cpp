#include "pch.h"
#include "ECHOc.h"

int GenerujEcho(unsigned char * wartosci_rgb, int dlugosc_tablicy, int index) {
	for (auto it = wartosci_rgb + index; it < wartosci_rgb + index + dlugosc_tablicy; it++) {
		unsigned char* odbicie = it - 5;
		if(odbicie > wartosci_rgb && odbicie < wartosci_rgb + index + dlugosc_tablicy + 5)
			*it += *odbicie;
	};
	return 0;
}