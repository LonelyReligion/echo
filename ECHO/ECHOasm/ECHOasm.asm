;rcx adres pierwszego elementu
;rdx liczba elementow
;r8 index
;r9 adres kopii

.data
przesuniecie	word		24
przesunieciex4	word		96

;WORD is an unsigned 16-bit value (0 to +65535 range)
stride			word		0
ostatniakolumna word		0	;width * 3
len				word		0

.code
GenerujEcho proc
cmp RDX, 0 
add RCX, R8 ;dodajemy index
add R9, R8

pop RAX
pop RAX ;index?
pop RAX
pop RAX
pop RAX
mov R10, 3
mul R10

;mov ostatniakolumna, R10
jle koniec

dodawanie:
movzx RBX, BYTE PTR[RCX]
movzx R9, BYTE PTR[RCX]
add RBX, 5
;mov RBX, R9
mov [RCX], BL ;rozmiar!!
inc RCX
dec RDX
cmp RDX, 0 
jg dodawanie ;jump if greater

koniec:
ret

GenerujEcho endp
end