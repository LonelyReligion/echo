;rcx adres pierwszego elementu
;rdx liczba elementow
;r9 index

.code
GenerujEcho proc
cmp RDX, 0 
add RCX, R9
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