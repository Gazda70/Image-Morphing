

.data
resX QWORD 0
resY QWORD 0
max QWORD 0
outputCharPtsPointer QWORD 0
relDistPointer QWORD 0
help QWORD 0.0
cumulatedDenom REAL8 0.0
zero REAL8 0.0
one REAL8 1.0
only32bit QWORD 00000000FFFFFFFFH
eight QWORD 8
four QWORD 4
two QWORD 2
indeks QWORD 0


.code

; firstPoint, RelDistFirst, outputCharPoints, i, j, maxCharPts, RelDistFirst.Length
; tak powinno siê odczytywaæ dane z tablic i zapisywaæ do nich
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
; po³o¿enie aktualnego pixela
MOV relDistPointer, RDX
MOV outputCharPtsPointer, R8
MOV resX, R9
MOV RAX, QWORD PTR[rsp + 8 * 5]
MOV resY, RAX
; rozmiar tablicy z aktualnie branymi pod uwagê punktami charakterystycznymi
MOV RAX, QWORD PTR[rsp + 8 * 6]
MOV max, RAX
; rozmiar tablicy dytansów relatywnych - bierzemy pod uwagê tylko taki
; fragment tablicy dystansów relatywnych który ma tak¹ sam¹ d³ugoœæ jak
;aktualnie analizowany fragment tablicy punktów charakterystycznych
; RDX = > adres tablicy z dystansami relatywnymi
; R8 = > adres tablicy z punktami charakterystycznymi

; inicjalizacja zbiorczego mianownika, rejestrów do przechowywania wspó³rzêdnych
; w trakcie pracy pêtli oraz tablicy na wynik
MOVSD XMM3, zero
MOVSD XMM6, zero
MOVSD XMM7, zero

; licznik pêtli
MOV R10, 0
MOV RAX, 0
; pêtla przechodz¹ca przez tablicê punktów charakterystycznych
charPointsLoop :

MOV RAX, 8
MUL R10
MOV indeks, RAX

; wyznaczenie ró¿nicy wspó³rzêdnych aktualnego punktu charakterystycznego
; oraz wspó³rzêdnych aktualnego piksela
MOV R14, outputCharPtsPointer
ADD R14, indeks
MOV R12, QWORD PTR[R14]
AND R12, only32bit
SUB R12, resX
MOV R11, QWORD PTR[R14 + 4]
AND R11, only32bit
SUB R11, resY

; wyznaczenie sumy kwadratów wczeœniej obliczonych ró¿nic
MOV RAX, R12
MUL RAX
MOV R12, RAX
MOV RAX, R11
MUL RAX
ADD RAX, R12

; sprawdzenie czy suma jest niezerowa
CMP RAX, 0
JE ifzero
MOV help, RAX
MOVSD XMM2, help


; konwersja na liczbê zmiennoprzecinkow¹ w celu umo¿liwienia dalszych obliczeñ
CVTDQ2PD XMM1, XMM2

; obliczenie odwrotnoœci aktalnego mianownika i dodanie jej zbiorczego mianownika
; !dzia³anie MOVSD : [RDI] < -[RSI]
MOVSD XMM0, one
DIVSD XMM0, XMM1

; aktualizacja wartoœci zbiorczego mianownika
ADDSD XMM3, XMM0

; inkrementacja indeksu
MOV RAX, 8
MUL R10

	; wyci¹gniêcie z tablicy i konwersja aktualnych relatywnych dystansów
MOV R14, relDistPointer
ADD R14, indeks
MOV R11, [R14]
AND R11, only32bit
MOV help, R11
MOVD XMM0, help
CVTDQ2PD XMM4, XMM0
; b³¹d dostêpu
MOV R11, [R14 + 4]
AND R11, only32bit
MOV help, R11
MOVD XMM0, help
CVTDQ2PD XMM5, XMM0

; podzielenie przez aktualny mianownik
DIVSD XMM4, XMM1
DIVSD XMM5, XMM1


; dodanie do zbiorczych wspó³rzêdnych
ADDSD XMM6, XMM4
ADDSD XMM7, XMM5


	ifzero :
; obs³uga licznika pêtli
INC R10
CMP R10, max
JNE charPointsLoop


koniec :
; podzielenie gotowych wartoœci wspó³rzêdnych przez zbiorczy mianownik
DIVSD XMM6, XMM3
DIVSD XMM7, XMM3

; OBLICZENIA DZIA£AJ¥


; konwersja z powrotem na liczby ca³kowite
CVTPD2DQ XMM1, XMM6
CVTPD2DQ XMM2, XMM7


; zapis do tablicy wynikowej
MOVD QWORD PTR[RCX], XMM1
MOVD QWORD PTR[RCX + 4], XMM2


RET

CalcNumerator ENDP

END
