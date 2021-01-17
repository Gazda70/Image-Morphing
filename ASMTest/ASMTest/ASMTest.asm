

.data
resX QWORD 0
resY QWORD 0
max QWORD 0
outputCharPtsPointer QWORD 0
relDistPointer QWORD 0
help SQWORD 0.0
cumulatedDenom REAL8 0.0
zero REAL8 0.0
one REAL8 1.0
only32bit QWORD 00000000FFFFFFFFH
eight QWORD 8
four QWORD 4
two QWORD 2
indeks QWORD 0


.code

; firstPoint, RelDistFirst, outputCharPoints, i, j, maxCharPts
; tak powinno si� odczytywa� dane z tablic i zapisywa� do nich
; MOV RBX, QWORD PTR[R8]
; ADD RBX, RAX
; MOV R11, [R8 + 4]
; MOV R12, [RDX]
; MOV R13, [RDX + 4]
; MOV R12, [RDX + 8]
; MOV R13, [RDX + 12]
; MOV QWORD PTR[RCX], 0
; MOV QWORD PTR[RCX + 4], 1

CalcNumerator PROC

; RCX = > adres tablicy na wynik
; po�o�enie aktualnego pixela
MOV relDistPointer, RDX
MOV outputCharPtsPointer, R8
MOV resX, R9
MOV RAX, QWORD PTR[rsp + 8 * 5]
MOV resY, RAX
; rozmiar tablicy z aktualnie branymi pod uwag� punktami charakterystycznymi
MOV RAX, QWORD PTR[rsp + 8 * 6]
MOV max, RAX
; rozmiar tablicy dytans�w relatywnych - bierzemy pod uwag� tylko taki
; fragment tablicy dystans�w relatywnych kt�ry ma tak� sam� d�ugo�� jak
;aktualnie analizowany fragment tablicy punkt�w charakterystycznych
; RDX = > adres tablicy z dystansami relatywnymi
; R8 = > adres tablicy z punktami charakterystycznymi

; inicjalizacja zbiorczego mianownika, rejestr�w do przechowywania wsp�rz�dnych
; w trakcie pracy p�tli oraz tablicy na wynik
MOVSD XMM3, zero
MOVSD XMM6, zero
MOVSD XMM7, zero

; licznik p�tli
MOV R10, 0
MOV RAX, 0
; p�tla przechodz�ca przez tablic� punkt�w charakterystycznych
charPointsLoop :

MOV RAX, 8
MUL R10
MOV indeks, RAX

; wyznaczenie r�nicy wsp�rz�dnych aktualnego punktu charakterystycznego
; oraz wsp�rz�dnych aktualnego piksela
MOV R14, outputCharPtsPointer
ADD R14, indeks
MOV R12, QWORD PTR[R14]
AND R12, only32bit
MOV help, R12
MOVSD XMM0, help
SUBSD XMM0, resX
MOV R11, QWORD PTR[R14 + 4]
AND R11, only32bit
MOV help, R11
MOVSD XMM1, help
SUBSD XMM1, resY

; wyznaczenie sumy kwadrat�w wcze�niej obliczonych r�nic
MOVSD help, XMM0
MOV RAX, help
AND RAX, only32bit
MUL RAX
MOV R12, RAX
MOVSD help, XMM1
MOV RAX, help
AND RAX, only32bit
MUL RAX
ADD RAX, R12

MOV help, RAX
MOVSD XMM2, help
CVTDQ2PD XMM1, XMM2

; sprawdzenie czy suma jest niezerowa
; CMP RAX, 0
; JE ifzero
; MOV help, RAX
; MOVSD XMM2, help


; konwersja na liczb� zmiennoprzecinkow� w celu umo�liwienia dalszych oblicze�
; CVTDQ2PD XMM1, XMM2

;z�e por�wnanie
MOVSD XMM0, zero
COMISD XMM1, XMM0
JE ifzero

; nie wiem czy tu sie dobrze liczy
; obliczenie odwrotno�ci aktualnego mianownika i dodanie jej do zbiorczego mianownika
MOVSD XMM0, one
DIVSD XMM0, XMM1

; aktualizacja warto�ci zbiorczego mianownika
ADDSD XMM3, XMM0
nop;

; inkrementacja indeksu
; MOV RAX, 8
; MUL R10

; wyci�gni�cie z tablicy i konwersja aktualnych relatywnych dystans�w
MOV R14, relDistPointer
ADD R14, indeks
MOV R11, [R14]
AND R11, only32bit
MOV help, R11
MOVD XMM0, help
CVTDQ2PD XMM4, XMM0
; b��d dost�pu
MOV R11, [R14 + 4]
AND R11, only32bit
MOV help, R11
MOVD XMM0, help
CVTDQ2PD XMM5, XMM0

; mo�e tu da� only32bit
; je�eli nie ma tej cz�ci to obraz jest ca�y w jednym kolorze, najpewniej kolorze piksela w lewym g�rnym rogu
; je�li wyst�puje to nie ma zmian ze wzgl�du na punkty charakt i s� paski
MOVSD XMM0, zero
COMISD XMM1, XMM0
JE ifzero
; podzielenie przez aktualny mianownik
DIVSD XMM4, XMM1
DIVSD XMM5, XMM1


; dodanie do zbiorczych wsp�rz�dnych
ADDSD XMM6, XMM4
ADDSD XMM7, XMM5


	ifzero :
; obs�uga licznika p�tli
INC R10
CMP R10, max
JNE charPointsLoop


koniec :
; podzielenie gotowych warto�ci wsp�rz�dnych przez zbiorczy mianownik
; sprawdzenie czy zbiorczy mianownik jest niezerowy
; ZAKOMENTOWANE WA�NE SPRAWDZANIE
MOVSD XMM0, zero
COMISD XMM3, XMM0
JE write_table
DIVSD XMM6, XMM3
DIVSD XMM7, XMM3

; OBLICZENIA DZIA�AJ�


; konwersja z powrotem na liczby ca�kowite
; final_conversion:
CVTPD2DQ XMM1, XMM6
CVTPD2DQ XMM2, XMM7


; zapis do tablicy wynikowej
write_table:
MOVD QWORD PTR[RCX], XMM1
MOVD QWORD PTR[RCX + 4], XMM2


RET

CalcNumerator ENDP

END
