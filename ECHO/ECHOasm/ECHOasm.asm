;rcx adres pierwszego elementu
;rdx -> r12 liczba elementow
;r8 index
;r9 to adres kopii

.data
stride				qword		0
ostatniakolumna		qword		0	

wskaznikrgb			qword		0
wskaznikrgb_cpy		qword		0

.code
GenerujEcho proc
mov R15, R8

mov wskaznikrgb, RCX
mov wskaznikrgb_cpy, R9

mov RAX, [rsp + 48] ;stride
mov stride, RAX

mov RAX, [rsp + 40] 
mov ostatniakolumna, RAX

push rsi
push rdi

push r15
push r14
push r13
push r12
push r11
push r10

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
pop r10
pop r11
pop r12
pop r13
pop r14
pop r15

pop rdi
pop rsi
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
; (wskaznik_cpy + przesunicie) < (wartosci_rgb_cpy + R13 * stride + ostatnia_kolumna)
mov RCX, wskaznikrgb_cpy
add RCX, R8 ;index
add RCX, 24

sub RCX, wskaznikrgb_cpy
mov RAX, R13 ;r13 to wiersz
mul stride 
sub RCX, RAX
sub RCX, ostatniakolumna
cmp RCX, 0
jl nieprawagranica
jmp koniecpetliikolumna

nieprawagranica: 
;*wskaznik = *(wskaznik_cpy - przesunicie) * 3 / 16;
mov R9, wskaznikrgb_cpy
sub R9, 24
add R9, R8

mov RCX, wskaznikrgb
add RCX, R8

mov R11, ostatniakolumna
sub R11, R14 ;ostatnia kolumna - kolumna

cmp R11, 48
jge movxmm 

movzx RAX, BYTE PTR[R9]

mov R11, 3
mul R11
shr RAX, 4

mov RBX, RAX

;musimy sprawdzic przepelnienie
mov R11, 255
cmp RBX, 255
cmovg RBX, R11

xor R11, R11
cmp RBX, 0
cmovl RBX, R11

mov [RCX], BL ;rozmiar!!

warunekponieprawagranica:
;(wskaznik_cpy - przesunicie * 4) > (wartosci_rgb_cpy + wiersz * stride)
mov RCX, wskaznikrgb_cpy
add RCX, R8 ;index
sub RCX, 96

sub RCX, wskaznikrgb_cpy

mov RAX, R8
sub RAX, R14
sub RCX, RAX

cmp RCX, 0
jg nieprawagranicaxcztery
jmp niexcztery

movxmm:
vmovups xmm0, xmmword ptr[R9]

vpmovzxbw ymm2, xmm0

;mnozenie razy 3
vpaddw ymm0, ymm2, ymm2
vpaddw ymm2, ymm0, ymm2

;dzielenie przez 16
vpsrlw ymm2, ymm2, 4

;wracamy do byte
vpackuswb ymm4, ymm2, ymm2
vpermq ymm0, ymm4, 11011000b

vmovups [RCX], xmm0
jmp warunekponieprawagranica

niexcztery:
;*wskaznik += *(wskaznik_cpy + przesunicie) * 13 / 16
mov RCX, wskaznikrgb
add RCX, R8

mov R9, wskaznikrgb_cpy
add R9, R8
add R9, 24 ;24

mov R11, ostatniakolumna
sub R11, R14 ;ostatnia kolumna - kolumna
cmp R11, 120 ;(24+16)*3
jge pierwszedodawaniexmm 

movzx RBX, BYTE PTR[RCX]
movzx RAX, BYTE PTR[R9]

mov R11, 13
mul R11
shr RAX, 4

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

pierwszedodawaniexmm:
;mnozenie razy 13
vmovups xmm0, xmmword ptr[R9]
vpmovzxbw ymm2, xmm0

vpsllw ymm0, ymm2, 3 ;x8 w ymm0
vpsllw ymm3, ymm2, 2 ;x4 w ymm3
vpaddw ymm0, ymm0, ymm3 ;x12 w ymm0

vpaddw ymm2, ymm0, ymm2; x12 + x1 w ymm2

;dzielenie przez 16
vpsrlw ymm2, ymm2, 4

;wracamy do byte
vpackuswb ymm4, ymm2, ymm2
vpermq ymm0, ymm4, 11011000b

vmovups xmm1, xmmword ptr[RCX]
vpaddw xmm0, xmm0, xmm1
vmovups [RCX], xmm0
add R14, 15
jmp koniecpetliikolumna

nieprawagranicaxcztery:
;*wskaznik += *(wskaznik_cpy - przesunicie * 4) / 16;
mov RCX, wskaznikrgb
add RCX, R8

mov R9, wskaznikrgb_cpy
add R9, R8
sub R9, 96

mov R11, ostatniakolumna
sub R11, R14 ;ostatnia kolumna - kolumna
cmp R11, 72
jge drugiedodawaniexmm 

movzx RBX, BYTE PTR[RCX]
movzx RAX, BYTE PTR[R9]

xor RDX, RDX
shr RAX, 4

add RBX, RAX

;musimy sprawdzic przepelnienie
mov R11, 255
cmp RBX, 255
cmovg RBX, R11

xor R11, R11
cmp RBX, 0
cmovl RBX, R11

mov [RCX], BL ;rozmiar!!

powrotpodrugim:
;*wskaznik += *(wskaznik_cpy + przesunicie) * 6 / 8;
mov R9, wskaznikrgb_cpy
add R9, R8
add R9, 24

mov RCX, wskaznikrgb
add RCX, R8

mov R11, ostatniakolumna
sub R11, R14 ;ostatnia kolumna - kolumna
cmp R11, 72
jge trzeciedodawaniexmm

movzx RBX, BYTE PTR[RCX]
movzx RAX, BYTE PTR[R9] ;<-wyjatkogenne

xor RDX, RDX
mov R11, 6
mul R11
shr RAX, 3

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

drugiedodawaniexmm:
vmovups xmm0, xmmword ptr[R9]
vpmovzxbw ymm2, xmm0

;dzielenie przez 16
vpsrlw ymm2, ymm2, 4

;wracamy do byte
vpackuswb ymm4, ymm2, ymm2
vpermq ymm0, ymm4, 11011000b

vmovups xmm1, xmmword ptr[RCX]
vpaddw xmm0, xmm0, xmm1
vmovups [RCX], xmm0
jmp powrotpodrugim

trzeciedodawaniexmm:
;mnozenie razy 6
vmovups xmm0, xmmword ptr[R9]

vpmovzxbw ymm2, xmm0

vpsllw ymm0, ymm2, 1 ;x2 w ymm0
vpsllw ymm3, ymm2, 2 ;x4 w ymm3
vpaddw ymm2, ymm0, ymm3 ;x6 w ymm2

;dzielenie przez 8
vpsrlw ymm2, ymm2, 3

;wracamy do byte
vpackuswb ymm4, ymm2, ymm2
vpermq ymm0, ymm4, 11011000b

vmovups xmm1, xmmword ptr[RCX]
vpaddw xmm0, xmm0, xmm1
vmovups [RCX], xmm0
add R14, 15
jmp koniecpetliikolumna

GenerujEcho endp
end