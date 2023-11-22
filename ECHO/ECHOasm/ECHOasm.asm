;rcx adres pierwszego elementu
;rdx -> r12 liczba elementow
;r8 index
;r9 to adres kopii

.data
stride				qword		0
ostatniakolumna		qword		0	

wskaznikrgb			qword		0
wskaznikrgb_cpy		qword		0
dzielnik			dd			10

.code
GenerujEcho proc
mov R15, R8

mov wskaznikrgb, RCX
mov wskaznikrgb_cpy, R9

mov RAX, [rsp + 48] ;stride
mov stride, RAX

mov RAX, [rsp + 40] 
mov ostatniakolumna, RAX

mov R12, RDX

xor RDX, RDX
xor RAX, RAX
mov RAX, R8
div stride ;F7 /6 	DIV r/m32 	M 	Valid 	Valid 	Unsigned divide EDX:EAX by r/m32, with result stored in EAX := Quotient, EDX := Remainder.
mov R13, RAX
mov R14, RDX

cmp R12, 0 
jle koniec

dodawanie:
;wskaznik < dlugosc_tablicy + index + wartosci_rgb
xor RAX, RAX
mov RAX, R8
sub RAX, R15
sub RAX, R12
cmp RAX, 0 
jge koniec 

mov RAX, R14
cmp RAX, ostatniakolumna ;if (R14 != ostatnia_kolumna)
je kolumnatoostatniakolumna

mov R9, wskaznikrgb_cpy
add R9, R8

;(wskaznik - przesunicie) > (wartosci_rgb + R13 * stride)
mov RCX, R8
sub RCX, 24
xor RAX, RAX
mov RAX, R13
mul stride 
sub RCX, RAX
cmp RCX, 0
jg nielewagranica
inc R14

;index_wzgledny = R13 * stride + R14
mov RAX, R13
mul stride
add RAX, R14
mov R8, RAX 

jmp dodawanie

koniec:
ret

kolumnatoostatniakolumna:
inc R13
mov R14, 0
jmp koniecpetli

koniecpetliikolumna:
inc R14

koniecpetli:
;index_wzgledny = R13 * stride + R14
mov RAX, R13
mul stride
add RAX, R14
mov R8, RAX 

jmp dodawanie

nielewagranica:
;(wskaznik + przesunicie) < (wartosci_rgb + R13 * stride + ostatnia_kolumna)
mov RCX, R8
add RCX, 24

xor RAX, RAX
mov RAX, R13

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

mov RCX, wskaznikrgb
add RCX, R8

mov R11, ostatniakolumna
sub R11, R14 ;ostatnia kolumna - kolumna
cmp R11, 16
jge movxmm ;>=16

movzx RAX, BYTE PTR[R9]

mov R11, 2
mul R11
mov R11, 10
div R11

mov RBX, RAX

;musimy sprawdzic przepelnienie
;mov R11, 255
;cmp RBX, 255
;cmovg RBX, R11

;xor R11, R11
;cmp RBX, 0
;cmovl RBX, R11

mov [RCX], BL ;rozmiar!!

warunekponieprawagranica:
;(wskaznik_cpy - przesunicie * 4) > (wartosci_rgb_cpy + R13 * stride) przeklejone
mov RCX, R8
sub RCX, 96 
xor RAX, RAX
mov RAX, R13
mul stride 
sub RCX, RAX
cmp RCX, 0
jg nielewagranicaxcztery
jmp niexcztery

movxmm:
movups xmm0, [R9]

addps xmm0, xmm0

movss xmm1, dzielnik
cvtdq2ps xmm0, xmm0
divps xmm0, xmm1 
cvttps2dq xmm0, xmm0

;porownanie

movups [RCX], xmm0
jmp warunekponieprawagranica

niexcztery:
;*wskaznik += *(wskaznik_cpy + przesunicie) * 0.8
mov R9, wskaznikrgb_cpy
add R9, R8
add R9, 24

movzx RAX, BYTE PTR[R9]

xor RDX, RDX
mov R11, 8
mul R11
mov R11, 10
div R11


mov RCX, wskaznikrgb
add RCX, R8
movzx RBX, BYTE PTR[RCX]

add RBX, RAX
 
;musimy sprawdzic przepelnienie
mov R11, 255
cmp RBX, 255
cmovg RBX, R11

xor R11, R11
cmp RBX, 0
cmovl RBX, R11

mov [RCX], BL ;rozmiar!!

jmp koniecpetliikolumna

nielewagranicaxcztery:
; (wskaznik_cpy + przesunicie * 4) < (wartosci_rgb_cpy + R13 * stride + ostatnia_kolumna)
mov RCX, wskaznikrgb_cpy
add RCX, R8
add RCX, 96
sub RCX, wskaznikrgb_cpy
xor RAX, RAX
mov RAX, R13
mul stride 
sub RCX, RAX
sub RCX, ostatniakolumna
cmp RCX, 0
jl nieprawagranicaxcztery
jmp niexcztery

nieprawagranicaxcztery:
;*wskaznik += *(wskaznik_cpy - przesunicie * 4) * 0.1;
mov RCX, wskaznikrgb
add RCX, R8

mov R9, wskaznikrgb_cpy
add R9, R8
sub R9, 96

movzx RBX, BYTE PTR[RCX]
movzx RAX, BYTE PTR[R9]

xor RDX, RDX
mov R11, 10
div R11

add RBX, RAX

;musimy sprawdzic przepelnienie
mov R11, 255
cmp RBX, 255
cmovg RBX, R11

xor R11, R11
cmp RBX, 0
cmovl RBX, R11

mov [RCX], BL ;rozmiar!!

;*wskaznik += *(wskaznik_cpy + przesunicie) * 0.7;
mov R9, wskaznikrgb_cpy
add R9, R8
add R9, 24

movzx RAX, BYTE PTR[R9] ;<-wyjatkogenne

xor RDX, RDX
mov R11, 10
div R11
mov R11, 7
mul R11

mov RCX, wskaznikrgb
add RCX, R8
movzx RBX, BYTE PTR[RCX]

add RBX, RAX

;musimy sprawdzic przepelnienie
mov R11, 255
cmp RBX, 255
cmovg RBX, R11

xor R11, R11
cmp RBX, 0
cmovl RBX, R11

mov [RCX], BL ;rozmiar!!

jmp koniecpetliikolumna

GenerujEcho endp
end