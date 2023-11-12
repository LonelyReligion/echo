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

cmp RDX, 0 
jle koniec

dodawanie:
movzx RBX, BYTE PTR[RCX]
movzx RAX, BYTE PTR[R9]

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
jg dodawanie ;jump if greater

koniec:
ret

GenerujEcho endp
end