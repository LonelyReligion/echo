;rcx adres pierwszego elementu
;rdx liczba elementow
;r8 index
;r9 to adres kopii

.data
przesunieciex4		dword		96

stride				dword		0

ostatniakolumna		qword		0	;width * 3
len					dword		0

kolumna				dword		0
wiersz				dword		0

wskaznikrgb			qword		0
wskaznikrgb_cpy		qword		0

.code
GenerujEcho proc
mov wskaznikrgb, RCX
mov wskaznikrgb_cpy, R9

mov RAX, [rsp + 56] ;stride
mov stride, EAX

mov RAX, [rsp + 48] ;len
mov len, EAX

mov RAX, [rsp + 40] ;width
mov ostatniakolumna, RAX
add RAX, ostatniakolumna
add RAX, ostatniakolumna
mov ostatniakolumna, RAX

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
mov EAX, kolumna
cmp RAX, ostatniakolumna ;if (kolumna != ostatnia_kolumna)
je kolumnatoostatniakolumna

mov RCX, wskaznikrgb
add RCX, R8
mov R9, wskaznikrgb_cpy
add R9, R8

movzx RBX, BYTE PTR[RCX]
movzx RAX, BYTE PTR[R9]

sub RCX, 24 
sub RCX, wskaznikrgb
xor RAX, RAX
mov EAX, wiersz
mov R12, RDX
mul stride 
mov RDX, R12 
sub RCX, RAX
cmp RCX, 0
jg nielewagranica

inc kolumna

;index_wzgledny = wiersz * stride + kolumna
xor R8, R8
mov R12, RDX
mov EAX, wiersz
mul stride
add EAX, kolumna
mov R8, RAX 
mov RAX, R11
mov RDX, R12

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

;index_wzgledny = wiersz * stride + kolumna
xor R8, R8
mov R11, RAX
mov R12, RDX
mov EAX, wiersz
mul stride
add EAX, kolumna
mov R8, RAX 
mov RAX, R11
mov RDX, R12
;

dec RDX ;dlugosc tablicy - 1
cmp RDX, 0 ; dlugosc tablicy > 0?
jg dodawanie ;while(wskaznik < dlugosc_tablicy + index + wartosci_rgb)
jmp koniec

nielewagranica:
mov RCX, wskaznikrgb
add RCX, R8
add RCX, 24
sub RCX, wskaznikrgb_cpy
xor RAX, RAX
mov EAX, wiersz
mov R12, RDX
mul stride 
mov RDX, R12
sub RCX, RAX
sub RCX, ostatniakolumna
cmp RCX, 0
jl nieprawagranica
inc kolumna
jmp koniecpetli

nieprawagranica:
mov RAX, R11
mov R9, wskaznikrgb_cpy
sub R9, 24
add R9, R8

movzx RAX, BYTE PTR[R9]

mov R11, RDX

mov R12, 2
mul R12
mov R12, 10
div R12

mov RDX, R11

;musimy sprawdzic przepelnienie
mov RCX, wskaznikrgb
add RCX, R8

mov RBX, RAX

mov R11, 255
cmp RBX, 255
cmovg RBX, R11

xor R11, R11
cmp RBX, 0
cmovl RBX, R11

mov [RCX], BL ;rozmiar!!

;(wskaznik_cpy - przesunicie * 4) > (wartosci_rgb_cpy + wiersz * stride) przeklejone nie przetestowane
sub RCX, 96 
sub RCX, wskaznikrgb
xor RAX, RAX
mov EAX, wiersz
mov R12, RDX
mul stride 
mov RDX, R12 
sub RCX, RAX
cmp RCX, 0
jg nielewagranicaxcztery
jmp niexcztery

niexcztery:
;
mov R9, wskaznikrgb_cpy
add R9, R8
add R9, 24
movzx RAX, BYTE PTR[R9]

mov R11, RDX
xor RDX, RDX
mov R12, 10
div R12
mov R12, 8
mul R12
mov RDX, R11

;przeklejone
mov RCX, wskaznikrgb
add RCX, R8

add RBX, RAX

mov R11, 255
cmp RBX, 255
cmovg RBX, R11

xor R11, R11
cmp RBX, 0
cmovl RBX, R11

mov [RCX], BL ;rozmiar!!

inc kolumna
jmp koniecpetli

nielewagranicaxcztery:
mov RCX, wskaznikrgb
add RCX, R8
add RCX, 96
sub RCX, wskaznikrgb_cpy
xor RAX, RAX
mov EAX, wiersz
mov R12, RDX
mul stride 
mov RDX, R12
sub RCX, RAX
sub RCX, ostatniakolumna
cmp RCX, 0
jl nieprawagranicaxcztery
jmp niexcztery

nieprawagranicaxcztery:
mov RCX, wskaznikrgb
add RCX, R8

mov R9, wskaznikrgb_cpy
add R9, R8
sub R9,	96

movzx RBX, BYTE PTR[RCX]
movzx RAX, BYTE PTR[R9]


mov R11, RDX
xor RDX, RDX
mov R12, 10
div R12
mov RDX, R11

;przeklejone
mov RCX, wskaznikrgb
add RCX, R8

add RBX, RAX

mov R11, 255
cmp RBX, 255
cmovg RBX, R11

xor R11, R11
cmp RBX, 0
cmovl RBX, R11

mov [RCX], BL ;rozmiar!!

;
mov R9, wskaznikrgb_cpy
add R9, R8
add R9, 24
movzx RAX, BYTE PTR[R9]

mov R11, RDX
xor RDX, RDX
mov R12, 10
div R12
mov R12, 7
mul R12
mov RDX, R11

;przeklejone
mov RCX, wskaznikrgb
add RCX, R8

add RBX, RAX

mov R11, 255
cmp RBX, 255
cmovg RBX, R11

xor R11, R11
cmp RBX, 0
cmovl RBX, R11

mov [RCX], BL ;rozmiar!!

inc kolumna
jmp koniecpetli

GenerujEcho endp
end