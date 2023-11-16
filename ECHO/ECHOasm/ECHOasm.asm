;rcx adres pierwszego elementu
;rdx -> r12 liczba elementow
;r8 index
;r9 to adres kopii

.data
stride				qword		0
ostatniakolumna		qword		0	;width * 3
len					qword		0
kolumna				qword		0
wiersz				qword		0
wskaznikrgb			qword		0
wskaznikrgb_cpy		qword		0

.code
GenerujEcho proc
mov wskaznikrgb, RCX
mov wskaznikrgb_cpy, R9

mov RAX, [rsp + 56] ;stride
mov stride, RAX

mov RAX, [rsp + 48] ;len
mov len, RAX

mov RAX, [rsp + 40] ;width
mov ostatniakolumna, RAX
add RAX, ostatniakolumna
add RAX, ostatniakolumna
mov ostatniakolumna, RAX

mov R12, RDX

xor RDX, RDX
xor RAX, RAX
mov RAX, R8
div stride ;F7 /6 	DIV r/m32 	M 	Valid 	Valid 	Unsigned divide EDX:EAX by r/m32, with result stored in EAX := Quotient, EDX := Remainder.
mov wiersz, RAX
mov kolumna, RDX

cmp R12, 0 
jle koniec

dodawanie:
mov RAX, kolumna
cmp RAX, ostatniakolumna ;if (kolumna != ostatnia_kolumna)
je kolumnatoostatniakolumna

mov R9, wskaznikrgb_cpy
add R9, R8

;(wskaznik - przesunicie) > (wartosci_rgb + wiersz * stride)
mov RCX, R8
sub RCX, 24
xor RAX, RAX
mov RAX, wiersz
mul stride 
sub RCX, RAX
cmp RCX, 0
jg nielewagranica
inc kolumna

;index_wzgledny = wiersz * stride + kolumna
xor R8, R8

mov RAX, wiersz
mul stride
add RAX, kolumna
mov R8, RAX 

dec R12
cmp R12, 0 
jg dodawanie ;while(liczbaelementow > 0)

koniec:
ret

kolumnatoostatniakolumna:
inc wiersz
mov kolumna, 0
jmp koniecpetli

koniecpetliikolumna:
inc kolumna

koniecpetli:
;index_wzgledny = wiersz * stride + kolumna
xor R8, R8
xor RAX, RAX
mov RAX, wiersz
mul stride
add RAX, kolumna
mov R8, RAX 

dec R12 ;dlugosc tablicy - 1
cmp R12, 0 ; dlugosc tablicy > 0?
jg dodawanie ;while(wskaznik < dlugosc_tablicy + index + wartosci_rgb)
jmp koniec

nielewagranica:
;(wskaznik + przesunicie) < (wartosci_rgb + wiersz * stride + ostatnia_kolumna)
mov RCX, R8
add RCX, 24

xor RAX, RAX
mov RAX, wiersz

mul stride 

sub RCX, RAX
sub RCX, ostatniakolumna
cmp RCX, 0

jl nieprawagranica
jmp koniecpetliikolumna

nieprawagranica:
;*wskaznik = *(wskaznik_cpy - przesunicie) * 0.2;
mov R9, wskaznikrgb_cpy
sub R9, 24
add R9, R8

xor R11, R11
mov R11, len
add R11, wskaznikrgb_cpy
cmp R11, R9 

jle koniecpetliikolumna

movzx RAX, BYTE PTR[R9]


mov R11, 2
mul R11
mov R11, 10
div R11

mov RCX, wskaznikrgb
add RCX, R8

mov RBX, RAX

;musimy sprawdzic przepelnienie
mov R11, 255
cmp RBX, 255
cmovg RBX, R11

xor R11, R11
cmp RBX, 0
cmovl RBX, R11

mov [RCX], BL ;rozmiar!!

;(wskaznik_cpy - przesunicie * 4) > (wartosci_rgb_cpy + wiersz * stride) przeklejone
mov RCX, R8
sub RCX, 96 
xor RAX, RAX
mov RAX, wiersz
mul stride 
sub RCX, RAX
cmp RCX, 0
jg nielewagranicaxcztery
jmp niexcztery

niexcztery:
;*wskaznik += *(wskaznik_cpy + przesunicie) * 0.8
;mov R9, wskaznikrgb_cpy
;add R9, R8
;add R9, 24

;xor R11, R11
;mov R11, len
;add R11, wskaznikrgb_cpy
;cmp R11, R9 
;jle koniecpetliikolumna

;movzx RAX, BYTE PTR[R9]

;xor RDX, RDX
;mov R11, 8
;mul R11
;mov R11, 10
;div R11


;mov RCX, wskaznikrgb
;add RCX, R8
;movzx RBX, BYTE PTR[RCX]

;add RBX, RAX

;musimy sprawdzic przepelnienie
;mov R11, 255
;cmp RBX, 255
;cmovg RBX, R11

;xor R11, R11
;cmp RBX, 0
;cmovl RBX, R11

;mov [RCX], BL ;rozmiar!!

jmp koniecpetliikolumna

nielewagranicaxcztery:
; (wskaznik_cpy + przesunicie * 4) < (wartosci_rgb_cpy + wiersz * stride + ostatnia_kolumna)
;mov RCX, wskaznikrgb_cpy
;add RCX, R8
;add RCX, 96
;sub RCX, wskaznikrgb_cpy
;xor RAX, RAX
;mov EAX, wiersz
;mul stride 
;sub RCX, RAX
;sub RCX, ostatniakolumna
;cmp RCX, 0
;jl nieprawagranicaxcztery
jmp niexcztery

nieprawagranicaxcztery:
;*wskaznik += *(wskaznik_cpy - przesunicie * 4) * 0.1;
;mov RCX, wskaznikrgb
;add RCX, R8

;mov R9, wskaznikrgb_cpy
;add R9, R8
;sub R9, 96

;xor R11, R11
;mov R11, len
;add R11, wskaznikrgb_cpy
;cmp R11, R9 
;jle koniecpetli

;movzx RBX, BYTE PTR[RCX]
;movzx RAX, BYTE PTR[R9]

;xor RDX, RDX
;mov R11, 10
;div R11

;add RBX, RAX

;musimy sprawdzic przepelnienie
;mov R11, 255
;cmp RBX, 255
;cmovg RBX, R11

;xor R11, R11
;cmp RBX, 0
;cmovl RBX, R11

;mov [RCX], BL ;rozmiar!!

;*wskaznik += *(wskaznik_cpy + przesunicie) * 0.7;
;mov R9, wskaznikrgb_cpy
;add R9, R8
;add R9, 24

;xor R11, R11
;mov R11, len
;add R11, wskaznikrgb_cpy
;cmp R11, R9 
;jle koniecpetli

;movzx RAX, BYTE PTR[R9] ;<-wyjatkogenne

;xor RDX, RDX
;mov R11, 10
;div R11
;mov R11, 7
;mul R11

;mov RCX, wskaznikrgb
;add RCX, R8
;movzx RBX, BYTE PTR[RCX]

;add RBX, RAX

;musimy sprawdzic przepelnienie
;mov R11, 255
;cmp RBX, 255
;cmovg RBX, R11

;xor R11, R11
;cmp RBX, 0
;cmovl RBX, R11

;mov [RCX], BL ;rozmiar!!

jmp koniecpetliikolumna

GenerujEcho endp
end