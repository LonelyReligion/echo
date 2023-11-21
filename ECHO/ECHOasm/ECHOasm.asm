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
jl koniec

; sprawdzamy czy jestesmy co najmniej 24 elementy od krawedzi
mov R10, R8
sub R10, 21
cmp R10, 0
jl inkrementacja_indexu
;

add RCX, R8

add R9, R8
sub R9, 21

movups xmm0, [R9]
movups [RCX], xmm0

sub RCX, R8
sub R9, R8
add R9, 21

add R8, 16 ;index
sub R12, 16;liczba elementow do przerobienia
jz koniec
cmp R12, 16
jge dodawanie
jmp dodawanie_liniowo

dodawanie_liniowo:
cmp R12, 0
jl koniec
add RCX, R8

add R9, R8
sub R9, 21

mov RCX, [R9]

sub RCX, R8
sub R9, R8
add R9, 21

dec R12
inc R8
jmp dodawanie_liniowo

koniec:
ret

GenerujEcho endp
end