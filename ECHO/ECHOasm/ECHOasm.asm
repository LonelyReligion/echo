;rcx adres pierwszego elementu
;rdx -> r12 liczba elementow
;r8 index
;r9 to adres kopii

.data
wartoscirgb			qword		0
wartoscirgb_cpy		qword		0
dlugosc_tablicy		qword		0
index				qword		0
ostatnia_kolumna	qword		0
stride				qword		0
wiersz				qword		0
kolumna				qword		0
wskaznik			qword		0
wskaznik_cpy		qword		0
index_wzgledny		qword		0

.code
GenerujEcho proc
mov wartoscirgb, RCX
mov wartoscirgb_cpy, R9
mov	dlugosc_tablicy, RDX
mov index, R8
mov index_wzgledny, R8

mov RAX, [rsp + 40]
mov ostatnia_kolumna, RAX

mov RAX, [rsp + 48]
mov stride, RAX 

xor RDX, RDX
mov RAX, index
div stride
mov wiersz, RAX
mov kolumna, RDX

mov RAX, wartoscirgb
add RAX, index
mov wskaznik, RAX

mov RAX, wartoscirgb_cpy
add RAX, index
mov wskaznik_cpy, RAX

dodawanie:
;while(wskaznik < dlugosc_tablicy + index + wartosci_rgb)
mov RAX, wskaznik
sub RAX, dlugosc_tablicy
sub RAX, index
sub RAX, wartoscirgb
cmp RAX, 0
jge	koniec

mov RCX, wskaznik
mov RBX, 0
mov [RCX], BL

mov RAX, kolumna
cmp RAX, ostatnia_kolumna
je toostatniakolumna

inc kolumna
jmp liczonsko

koniec:
ret

toostatniakolumna:
inc wiersz
mov kolumna, 0
jmp liczonsko

liczonsko:
; index_wzgledny = wiersz * stride + kolumna
xor RDX, RDX
mov RAX, wiersz
mul stride
add RAX, kolumna
mov index_wzgledny, rax

; wskaznik = index_wzgledny + wartosci_rgb
mov RAX, wartoscirgb
add RAX, index_wzgledny
mov wskaznik, RAX

; wskaznik_cpy = index_wzgledny + wartosci_rgb_cpy
mov RAX, wartoscirgb_cpy
add RAX, index_wzgledny
mov wskaznik_cpy, RAX

jmp dodawanie

GenerujEcho endp
end