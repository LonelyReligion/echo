;rcx adres pierwszego elementu
;rdx->r12 liczba elementow
;r8 index
;r9 to adres kopii

.code
GenerujEcho proc
dec R8
mov R12, RDX 

inkrementacja_indexu:
inc R8
dec R12

dodawanie:
cmp R12, 0
jle koniec

; sprawdzamy czy jestesmy co najmniej 24 elementy od krawedzi
mov R10, R8
sub R10, 24
cmp R10, 0
jl inkrementacja_indexu
;

add RCX, R8

mov R10, R9
add R10, R8
add R10, 24

xor RAX, RAX
mov AL, BYTE PTR[R10]

mov R11, 2
mul R11
mov R11, 10
div R11

xor RBX, RBX
mov BL, BYTE PTR[RCX]

mov RBX, RAX

;musimy sprawdzic przepelnienie
mov R11, 255
cmp RBX, 255
cmovg RBX, R11

xor R11, R11
cmp RBX, 0
cmovl RBX, R11

mov [RCX], BL 

;naprawiamy wartosci
sub RCX, R8

inc R8 ;index
dec R12 ;liczba elementow do przerobienia

jnz dodawanie

koniec:
ret

GenerujEcho endp
end