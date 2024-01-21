;////////////////////////////////////////////////////////////////////////////////////////
;/// Temat projektu: Echo w obrazie													  ///
;/// Opis: Program generuj¹cy efekt echa - nak³ada dwie kopie obrazu o wiêkszej       ///
;/// przezroczystoœci i pewnym przesuniêciu, na 24-bitow¹ bitmapê. Wartoœci			  ///
;/// przesuniêæ to 24 i 96.															  ///
;///																				  ///
;/// Autor: Agnieszka Ta¿birek														  ///
;/// Informatyka SSI Semestr 5. Grupa 2.											  ///
;/// Data ukoñczenia: 15.01.2024													  ///
;/// Rok akademicki: 2023/2024														  ///
;/// 1.0.0 11.10.23 Utworzenie projektu, GUI, ³adowanie obrazu do okna				  ///
;/// 1.1.0 18.10.23 Pod³¹czenie pustych bibliotek									  ///
;/// 1.2.0 20.10.23 Wywo³ywanie bibliotek wielow¹tkowo								  ///
;/// 1.3.0 25.10.23 Modyfikowanie zawartoœci tablicy w bibliotece .asm				  ///
;/// 1.4.0 05.11.23 Równy podzia³ zadañ na w¹tki									  ///
;/// 1.4.1 06.11.23 Implementacja algorytmu w C++									  ///
;/// 1.5.0 09.11.23 Pomiar czasu													  ///
;/// 1.6.0 13.11.23 Implementacja w .asm jednow¹tkowo								  ///
;/// 1.6.1 20.11.23 Przeniesienie niewspó³dzielonych zmiennych z pamiêci do rejestrów ///
;/// 1.7.0 25.11.23 Implementacja w .asm z u¿yciem rozkazów wektorowych               ///
;/// 1.7.1 29.11.23 Odk³adanie zawartoœci rejstrów na stos                            ///
;/// 1.8.0 11.01.24 Zapis do pliku                                                    ///
;/// 1.8.1 15.01.24 Refaktoryzacja, uproszczenie warunków                             ///
;////////////////////////////////////////////////////////////////////////////////////////

;Argumenty przekazywane do procedury:
;rcx adres pierwszego elementu
;rdx -> r12 liczba elementow
;r8 index
;r9 to adres kopii

.data
stride				qword		0
ostatniakolumna		qword		0	;indeks ostatniej kolumny

wskaznikrgb			qword		0	;adres pierwszego elementu oryginalnej tablicy
wskaznikrgb_cpy		qword		0	;adres pierwszego elementu niezmiennej kopii oryginalnej tablicy

.code
GenerujEcho proc ;procedura proc realizuj¹ca algorytm generowania echa
mov R15, R8 ;kopiujemy wartoœæ indexu pocz¹tku obszaru zmienianego w ramach w¹tku

mov wskaznikrgb, RCX ;zapisujemy adres do pamiêci 
mov wskaznikrgb_cpy, R9 ;zapisujemy adres do pamiêci

mov RAX, [rsp + 48] ;zdejmujemy stride ze stosu 
mov stride, RAX ;zapisujemy stride do pamiêci

mov RAX, [rsp + 40] ;zdejmujemy index ostatniej kolumny ze stosu
mov ostatniakolumna, RAX ;zapisujemy index ostatniej kolumny do pamiêci

;dajemy zawartoœæ rejestrów na stos
push rsi
push rdi

push r15
push r14
push r13
push r12
push r11
push r10

mov R12, RDX ;zapisujemy liczbê elementów do zmiany w R12

xor RDX, RDX ;0 w RDX
mov RAX, R8
div stride ;F7 /6 	DIV r/m32 	M 	Valid 	Valid 	Unsigned divide EDX:EAX by r/m32, with result stored in EAX := Quotient, EDX := Remainder.
mov R13, RAX ;zapisujemy aktualny numer wiersza w R13 
mov R14, RDX ;zapisujemy aktualny numer kolumny w R14

cmp R12, 0 ;sprawdzamy czy mamy co modyfikowaæ
jle koniec

dodawanie: ;g³ówna pêtla programu
;sprawdzamy czy mamy co modyfikowaæ
mov RAX, R8
sub RAX, R15
sub RAX, R12
cmp RAX, 0 
jge koniec 

;sprawdzamy czy kolumna to ostatnia kolumna (przejscie do kolejnego wiersza)
mov RAX, R14
cmp RAX, ostatniakolumna ;if (R14 != ostatnia_kolumna)
je kolumnatoostatniakolumna

;(wskaznik - przesunicie) > (wartosci_rgb + R13 * stride)
;sprawdzamy czy znajdujemy siê w odpowiedniej odleg³oœci od lewej krawêdzi
mov RCX, R8
sub RCX, 24
xor RAX, RAX
mov RAX, R13
mul stride 
sub RCX, RAX
cmp RCX, 0
jg nielewagranica
inc R14 ;przejœcie do kolejnej kolumny

;index_wzgledny = R13 * stride + R14
;liczymy index
mov RAX, R13 ;R13 to wiersz
mul stride
add RAX, R14 ;R14 to kolumna
mov R8, RAX 

jmp dodawanie

koniec:
;zdejmujemy zawartoœæ rejestrów z przed uruchomienia programu ze strosu
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
inc R13 ;+1 wiersz
mov R14, 0 ;pierwsza (zerowa) kolumna
jmp koniecpetli

koniecpetliikolumna:
inc R14 ;+1 kolumna

koniecpetli:
;index_wzgledny = R13 * stride + R14
;liczymy index
mov RAX, R13 ;R13 to wiersz
mul stride
add RAX, R14 ;R14 to kolumna
mov R8, RAX 

jmp dodawanie

nielewagranica:
;(wskaznik_cpy + przesunicie) < (wartosci_rgb_cpy + R13 * stride + ostatnia_kolumna)
;sprawdzamy czy znajdujemy siê w odpowiedniej odleg³oœci od prawej krawêdzi
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
;przypisanie
mov R9, wskaznikrgb_cpy
sub R9, 24
add R9, R8

mov RCX, wskaznikrgb
add RCX, R8

;sprawdzamy czy jest wystarczaj¹co du¿o elementów do koñca wiersza aby wykonaæ operacjê wektorow¹
mov R11, ostatniakolumna
sub R11, R14 ;ostatnia kolumna - kolumna
cmp R11, 48 ;3*16
jge movxmm 

movzx RAX, BYTE PTR[R9] ;przeniesienie bajtów z pod adresu znajduj¹cego w R9 do RAX

mov R11, 3
mul R11
shr RAX, 4 ;przesuniêcie bitowe zamiast dzielenia
mov RBX, RAX ;przypisanie

;musimy sprawdzic przepelnienie
mov R11, 255
cmp RBX, 255
cmovg RBX, R11

xor R11, R11
cmp RBX, 0
cmovl RBX, R11

mov [RCX], BL ;przeniesienie do lokalizacji z pod adresu znajduj¹cego siê w RCX

warunekponieprawagranica:
;(wskaznik_cpy - przesunicie * 4) > (wartosci_rgb_cpy + wiersz * stride)
;sprawdzamy czy czy próba odczytania z pamiêci pixela nie spowoduje wyjœcia poza nasz¹ pamiêæ
;sprawdzamy czy mo¿emy wykonaæ 1 czy 2 odbicia
mov RCX, wskaznikrgb_cpy
add RCX, R8 ;index
sub RCX, 96 ;24*4

sub RCX, wskaznikrgb_cpy

mov RAX, R8
sub RAX, R14
sub RCX, RAX

cmp RCX, 0
jg nieprawagranicaxcztery
jmp niexcztery

movxmm: ;przeniesienie w wersji z rozkazami wektorowymi
;*wskaznik = *(wskaznik_cpy - przesunicie) * 3 / 16;
vmovups xmm0, xmmword ptr[R9] ;zapisujemy 16 sk³adowych do xmm
vpmovzxbw ymm2, xmm0 ;przeniesienie do ymm, konwersja bajtów na s³owa

;mnozenie razy 3 realizowane jako dodawanie
vpaddw ymm0, ymm2, ymm2
vpaddw ymm2, ymm0, ymm2

;dzielenie przez 16 realizowane jako przesuniecie bitowe
vpsrlw ymm2, ymm2, 4

;wracamy do byte
vpackuswb ymm4, ymm2, ymm2 ;konwersja s³ów na bajty z saturacj¹
vpermq ymm0, ymm4, 11011000b ;powrót do odpowiedniej kolejnoœci

vmovups [RCX], xmm0 ;zapis
jmp warunekponieprawagranica

niexcztery:
;*wskaznik += *(wskaznik_cpy + przesunicie) * 13 / 16
mov RCX, wskaznikrgb
add RCX, R8

mov R9, wskaznikrgb_cpy
add R9, R8
add R9, 24 ;24

;sprawdzamy czy jesteœmy odpowiednio daleko od krawêdzi aby wykonaæ wersjê z rozkazami wektorowymi
mov R11, ostatniakolumna
sub R11, R14 ;ostatnia kolumna - kolumna
cmp R11, 120 ;(24+16)*3
jge pierwszedodawaniexmm 

movzx RBX, BYTE PTR[RCX]
movzx RAX, BYTE PTR[R9]

;przesuniêcia bitowe zamiast mno¿enia
mov R11, RAX
shl R11, 2
add RAX, R11
shl R11, 1
add RAX, R11
shr RAX, 4 ;dzielenie przez 16 realizowane jako przesuniêcie bitowe

add RBX, RAX
 
;musimy sprawdzic przepelnienie
mov R11, 255
cmp RBX, 255
cmovg RBX, R11

xor R11, R11
cmp RBX, 0
cmovl RBX, R11

mov [RCX], BL ;zapis do tablicy
jmp koniecpetliikolumna

pierwszedodawaniexmm: ;pierwsze dodawanie, realizacja z rozkazami wektorowymi
;*wskaznik += *(wskaznik_cpy + przesunicie) * 13 / 16
vmovups xmm0, xmmword ptr[R9] ;przeniesienie porcji danych
vpmovzxbw ymm2, xmm0 ;bajty na s³owa w ymm

;mnozenie razy 13 realizowane jako dodawanie i przesuniêcie
vpsllw ymm0, ymm2, 3 ;x8 w ymm0
vpsllw ymm3, ymm2, 2 ;x4 w ymm3
vpaddw ymm0, ymm0, ymm3 ;x12 w ymm0

vpaddw ymm2, ymm0, ymm2; x12 + x1 w ymm2

;dzielenie przez 16 realizowane jako przesuniêcie 
vpsrlw ymm2, ymm2, 4

vpackuswb ymm4, ymm2, ymm2 ;konwersja s³ów na bajty z saturacj¹
vpermq ymm0, ymm4, 11011000b ;powrót do odpowiedniej kolejnoœci

vmovups xmm1, xmmword ptr[RCX] ;pobieramy dane z tablicy, na której pracujemy
vpaddw xmm0, xmm0, xmm1 ;dodawanie
vmovups [RCX], xmm0 ;zapis
add R14, 15 ;dodanie do indeksu kolumny (pozosta³e 1 zostanie dodane w koniecpetliikolumna)
jmp koniecpetliikolumna

nieprawagranicaxcztery:
;*wskaznik += *(wskaznik_cpy - przesunicie * 4) / 16;
;drugie odbicie
mov RCX, wskaznikrgb
add RCX, R8

mov R9, wskaznikrgb_cpy
add R9, R8
sub R9, 96 ;24*4

;sprawdzamy czy jesteœmy odpowiednio daleko od krawêdzi aby wykonaæ wersjê z rozkazami wektorowymi
mov R11, ostatniakolumna
sub R11, R14 ;ostatnia kolumna - kolumna
cmp R11, 48 ;16*3
jge drugiedodawaniexmm 

movzx RBX, BYTE PTR[RCX]
movzx RAX, BYTE PTR[R9]

shr RAX, 4 ;przesuniêcie zamiast dzielenia
add RBX, RAX

;musimy sprawdzic przepelnienie
mov R11, 255
cmp RBX, 255
cmovg RBX, R11

xor R11, R11
cmp RBX, 0
cmovl RBX, R11

mov [RCX], BL ;zapis

powrotpodrugim:
;*wskaznik += *(wskaznik_cpy + przesunicie) * 6 / 8;
mov R9, wskaznikrgb_cpy
add R9, R8
add R9, 24

mov RCX, wskaznikrgb
add RCX, R8

;sprawdzamy czy mo¿emy skorzystaæ z wersji z rozkazami wektorowymi
mov R11, ostatniakolumna
sub R11, R14 ;ostatnia kolumna - kolumna
cmp R11, 72 ;24*3 z powodu przesuniêcia
jge trzeciedodawaniexmm

movzx RBX, BYTE PTR[RCX]
movzx RAX, BYTE PTR[R9] 

mov R11, 6
mul R11
shr RAX, 3 ;przesuniêcie zamiast dzielenia

add RBX, RAX

;musimy sprawdzic przepelnienie
mov R11, 255
cmp RBX, 255
cmovg RBX, R11

xor R11, R11
cmp RBX, 0
cmovl RBX, R11

mov [RCX], BL ;zapis

jmp koniecpetliikolumna

drugiedodawaniexmm:
;*wskaznik += *(wskaznik_cpy - przesunicie * 4) / 16
vmovups xmm0, xmmword ptr[R9]
vpmovzxbw ymm2, xmm0

vpsrlw ymm2, ymm2, 4 ;dzielenie przez 16 realizowane jako przesuniêcie logiczne

vpackuswb ymm4, ymm2, ymm2 ;konwersja s³ów na bajty z saturacj¹
vpermq ymm0, ymm4, 11011000b ;powrót do odpowiedniej kolejnoœci

vmovups xmm1, xmmword ptr[RCX] ;pobranie wartoœci aktualnie zmienianej tablicy
vpaddw xmm0, xmm0, xmm1 ;nak³adanie warstwy
vmovups [RCX], xmm0 ;zapis
jmp powrotpodrugim

trzeciedodawaniexmm:
;*wskaznik += *(wskaznik_cpy + przesunicie) * 6 / 8;
;mnozenie razy 6
vmovups xmm0, xmmword ptr[R9]

vpmovzxbw ymm2, xmm0

vpsllw ymm0, ymm2, 1 ;x2 w ymm0
vpsllw ymm3, ymm2, 2 ;x4 w ymm3
vpaddw ymm2, ymm0, ymm3 ;x6 w ymm2

;dzielenie przez 8
vpsrlw ymm2, ymm2, 3

;wracamy do byte
vpackuswb ymm4, ymm2, ymm2 ;konwersja s³ów na bajty z saturacj¹
vpermq ymm0, ymm4, 11011000b ;powrót do odpowiedniej kolejnoœci

vmovups xmm1, xmmword ptr[RCX]
vpaddw xmm0, xmm0, xmm1
vmovups [RCX], xmm0
add R14, 15 ;zwiêkszenie licznika kolumn - pozosta³e 1 zostanie dodane w koniecpetliikolumna
jmp koniecpetliikolumna

GenerujEcho endp
end