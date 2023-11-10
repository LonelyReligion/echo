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
cmp RDX, 0 
add RCX, R8 ;dodajemy index
add R9, R8

mov RAX, [rsp + 56] ;stride
mov stride, EAX

mov RAX, [rsp + 48] ;len
mov len, EAX

;cos w tym jest zle
;mov RAX, [rsp + 40] ;width
;mov R10, 3
;mul R10 ;wynik jest w RAX
;mov ostatniakolumna, EAX

jle koniec

dodawanie:
movzx RBX, BYTE PTR[RCX]
add RBX, 5
mov [RCX], BL ;rozmiar!!
inc RCX
dec RDX
cmp RDX, 0 
jg dodawanie ;jump if greater

koniec:
ret

GenerujEcho endp
end