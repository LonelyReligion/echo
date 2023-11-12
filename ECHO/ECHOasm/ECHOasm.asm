;rcx adres pierwszego elementu
;rdx liczba elementow
;r8 index
;r9 to adres kopii

.data
przesuniecie	dword		24
przesunieciex4	dword		96

stride			dword		0

ostatniakolumna dword		0	;width * 3
len				dword		0

kolumna			dword		0
wiersz			dword		0

.code
GenerujEcho proc
add RCX, R8 ;dodajemy index
add R9, R8

mov RAX, [rsp + 56] ;stride
mov stride, EAX

mov RAX, [rsp + 48] ;len
mov len, EAX

mov RAX, [rsp + 40] ;width
mov ostatniakolumna, EAX
add EAX, ostatniakolumna
add EAX, ostatniakolumna
mov ostatniakolumna, EAX

mov R11, RDX
xor RDX, RDX
mov RAX, R8
div stride ;F7 /6 	DIV r/m32 	M 	Valid 	Valid 	Unsigned divide EDX:EAX by r/m32, with result stored in EAX := Quotient, EDX := Remainder.
mov wiersz, EAX
mov kolumna, EDX
mov RDX, R11

cmp RDX, 0 
jle koniec

dodawanie:
movzx RBX, BYTE PTR[RCX]
movzx RAX, BYTE PTR[R9]

mov R11, RAX
mov EAX, kolumna
cmp EAX, ostatniakolumna ;if (kolumna != ostatnia_kolumna)
je kolumnatoostatniakolumna
mov RAX, R11

;musimy sprawdzic przepelnienie
mov R11, 255

add RBX, RAX
cmp RBX, 255
cmovg RBX, R11

xor R11, R11
cmp RBX, 0
cmovl RBX, R11

mov [RCX], BL ;rozmiar!!

inc RCX
inc R9

dec RDX
cmp RDX, 0 
jg dodawanie ;while(liczbaelementow > 0)

koniec:
ret

kolumnatoostatniakolumna:
inc wiersz
mov kolumna, 0
jmp koniecpetli

koniecpetli:
inc RCX
inc R9

dec RDX
cmp RDX, 0 
jg dodawanie ;while(wskaznik < dlugosc_tablicy + index + wartosci_rgb)


GenerujEcho endp
end