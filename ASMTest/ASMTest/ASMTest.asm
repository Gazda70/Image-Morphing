

.data
resX QWORD 0
resY QWORD 0
max QWORD 0
relDistLen QWORD 0
help QWORD 0.0
cumulatedDenom REAL8 0.0
zero REAL8 0.0
one REAL8 1.0
retArray REAL8 0.0, 0.0


.code

CalcNumeratorFirst PROC

; RCX = > adres tablicy na wynik
; po³o¿enie aktualnego pixela
MOV resX, RDX
MOV resY, R8
; rozmiar tablicy z aktualnie branymi pod uwagê punktami charakterystycznymi
MOV max, R9
; rozmiar tablicy dytansów relatywnych
MOV EAX, DWORD PTR[rsp + 8 * 5]
MOV relDistLen, RAX
; [rsp + 8 * 6] = > adres tablicy z dystansami relatywnymi
; [rsp + 8 * 7] = > adres tablicy z punktami charakterystycznymi

; inicjalizacja zbiorczego mianownika, rejestrów do przechowywania wspó³rzêdnych
; w trakcie pracy pêtli oraz tablicy na wynik
MOVSD XMM3, zero
MOVSD XMM6, zero
MOVSD XMM7, zero
MOV R11, 0
MOV [RCX], R11
MOV [RCX + 4], R11

; licznik pêtli
MOV R10, 0
MOV RAX, 0
; pêtla przechodz¹ca przez tablicê punktów charakterystycznych
charPointsLoop:

; inkrementacja indeksu
MOV RAX, 8
MUL R10
; wyznaczenie ró¿nicy wspó³rzêdnych aktualnego punktu charakterystycznego
; oraz wspó³rzêdnych aktualnego piksela
MOV RBX, QWORD PTR[RSP + 8 * 7]
ADD RBX, RAX
MOV R12, [RBX]
MOV R11, [RBX + 4]
SUB R12, resX
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
;!dzia³anie MOVSD: [RDI]<-[RSI]
MOVSD XMM0, one
DIVSD XMM0, XMM1

; aktualizacja wartoœci zbiorczego mianownika
ADDSD XMM3, XMM0

; inkrementacja indeksu
MOV RAX, 8
MUL R10

; wyci¹gniêcie z tablicy i konwersja aktualnych relatywnych dystansów
MOV RBX, QWORD PTR[RSP + 8 * 6]
ADD RBX, RAX
MOV R11, [RBX]
MOV help, R11
MOVD XMM0, help
CVTDQ2PD XMM4, XMM0
MOV R11, [RBX + 4]
MOV help, R11
MOVD XMM0, help
CVTDQ2PD XMM5, XMM0

; podzielenie przez aktualny mianownik
DIVSD XMM4, XMM1
DIVSD XMM5, XMM1


; dodanie do zbiorczych wspó³rzêdnych
ADDSD XMM6, XMM4
ADDSD XMM7, XMM5


ifzero:
; obs³uga licznika pêtli
INC R10
CMP R10, max
JNE charPointsLoop


koniec:
; podzielenie gotowych wartoœci wspó³rzêdnych przez zbiorczy mianownik
DIVSD XMM6, XMM3
DIVSD XMM7, XMM3

; OBLICZENIA DZIA£AJ¥


; konwersja z powrotem na liczby ca³kowite
; CVTPD2DQ XMM1, XMM6
; CVTPD2DQ XMM2, XMM7


; zapis do tablicy wynikowej
MOVSD XMM0, XMM6


RET

CalcNumeratorFirst ENDP


CalcNumeratorSecond PROC

; RCX = > adres tablicy na wynik
; po³o¿enie aktualnego pixela
MOV resX, RDX
MOV resY, R8
; rozmiar tablicy z aktualnie branymi pod uwagê punktami charakterystycznymi
MOV max, R9
; rozmiar tablicy dytansów relatywnych
MOV EAX, DWORD PTR[rsp + 8 * 5]
MOV relDistLen, RAX
; [rsp + 8 * 6] = > adres tablicy z dystansami relatywnymi
; [rsp + 8 * 7] = > adres tablicy z punktami charakterystycznymi

; inicjalizacja zbiorczego mianownika, rejestrów do przechowywania wspó³rzêdnych
; w trakcie pracy pêtli oraz tablicy na wynik
MOVSD XMM3, zero
MOVSD XMM6, zero
MOVSD XMM7, zero
MOV R11, 0
MOV[RCX], R11
MOV[RCX + 4], R11

; licznik pêtli
MOV R10, 0
MOV RAX, 0
; pêtla przechodz¹ca przez tablicê punktów charakterystycznych
charPointsLoop :

; wyznaczenie ró¿nicy wspó³rzêdnych aktualnego punktu charakterystycznego
; oraz wspó³rzêdnych aktualnego piksela
MOV RBX, QWORD PTR[RSP + 8 * 7]
MOV RAX, 8
MUL R10
ADD RBX, RAX
MOV R12, [RBX]
MOV R11, [RBX + 4]
SUB R12, resX
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

; obliczenie odwrotnoœci acutalDenom i dodanie jej do cumulatedDenom
MOVSD XMM0, one
DIVSD XMM0, XMM1

; aktualizacja wartoœci zbiorczego mianownika
ADDSD XMM3, XMM0

; inkrementacja indeksu
MOV RAX, 8
MUL R10

; wyci¹gniêcie z tablicy i konwersja aktualnych relatywnych dystansów
MOV RBX, QWORD PTR[RSP + 8 * 6]

ADD RBX, RAX

MOV R11, [RBX]
MOV help, R11
MOVD XMM0, help
CVTDQ2PD XMM4, XMM0

MOV R11, [RBX + 4]
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
; CVTPD2DQ XMM1, XMM6
; CVTPD2DQ XMM2, XMM7


; zapis do tablicy wynikowej
MOVSD XMM0, XMM7


RET

CalcNumeratorSecond ENDP

END