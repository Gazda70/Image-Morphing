

.data
resX QWORD 0
resY QWORD 0
max QWORD 0
outputCharPtsPointer QWORD 0
relDistPointer QWORD 0
zero REAL8 0.0
one REAL8 1.0
indeks QWORD 0


.code

CalcNumerator PROC

; RDX = > adres tablicy dystansów relatywnych
MOV relDistPointer, RDX

; R8 = > adres tablicy punktów charakterystycznych
MOV outputCharPtsPointer, R8

; R9 = > wartoœæ wspó³rzêdnej poziomej aktualnie analizowanego piksela
MOV resX, R9

; rsp + 8 * 5 = > wartoœæ wspó³rzêdnej pionowej aktualnie analizowanego piksela
MOV RAX, QWORD PTR[rsp + 8 * 5]
MOV resY, RAX

; rsp + 8 * 6 = > rozmiar tablicy z aktualnie branymi pod uwagê punktami charakterystycznymi
MOV RAX, QWORD PTR[rsp + 8 * 6]
MOV max, RAX
; rozmiar tablicy dytansów relatywnych - bierzemy pod uwagê tylko taki
; fragment tablicy dystansów relatywnych który ma tak¹ sam¹ d³ugoœæ jak
;aktualnie analizowany fragment tablicy punktów charakterystycznych

; inicjalizacja zbiorczego mianownika (XMM3), rejestrów do przechowywania wspó³rzêdnych (XMM6, XMM7)
MOVSD XMM3, zero
MOVSD XMM6, zero
MOVSD XMM7, zero

; inicjalizacja licznika pêtli
MOV R10, 0

; pêtla przechodz¹ca przez tablicê punktów charakterystycznych
charPointsLoop :

; aktualizacja wartoœci indeksu do obs³ugi dostêpu do tablic
MOV RAX, 8
MUL R10
MOV indeks, RAX

; wyznaczenie ró¿nicy wspó³rzêdnych aktualnego punktu charakterystycznego
; oraz wspó³rzêdnych aktualnego piksela
MOV R14, outputCharPtsPointer
ADD R14, indeks
MOV EAX, [R14]
MOVD XMM0, EAX
SUBSD XMM0, resX
MOV EAX, [R14 + 4]
MOVD XMM1, EAX
SUBSD XMM1, resY

; wyznaczenie sumy kwadratów wczeœniej obliczonych ró¿nic
MOVQ RAX, XMM0
MUL RAX
MOV R12, RAX
MOVQ RAX, XMM1
MUL RAX
ADD RAX, R12

; konwersja obliczonej sumy na liczbê zmiennoprzecinkow¹, przeniesienie jej do rejestru XMM
; oraz sprawdzenie czy jest niezerowa
MOVQ XMM2, RAX
CVTDQ2PD XMM1, XMM2
MOVSD XMM0, zero
COMISD XMM1, XMM0
JE ifzero

; obliczenie odwrotnoœci aktualnego mianownika i dodanie jej do zbiorczego mianownika
MOVSD XMM0, one
DIVSD XMM0, XMM1

; aktualizacja wartoœci zbiorczego mianownika
ADDSD XMM3, XMM0

; uzyskanie z tablicy, konwersja i przeniesienie do rejestrów XMM aktualnego relatywnego dystansu
MOV R14, relDistPointer
ADD R14, indeks
MOV EAX, [R14]
MOVD XMM0, EAX
CVTDQ2PD XMM4, XMM0
MOV EAX, [R14 + 4]
MOVD XMM0, EAX
CVTDQ2PD XMM5, XMM0

; podzielenie relatywnego dystansu przez zbiorczy mianownik
DIVSD XMM4, XMM1
DIVSD XMM5, XMM1

; dodanie do zbiorczych wspó³rzêdnych
ADDSD XMM6, XMM4
ADDSD XMM7, XMM5

; obs³uga licznika pêtli
ifzero :
INC R10
CMP R10, max
JNE charPointsLoop

koniec :
; sprawdzenie czy zbiorczy mianownik jest niezerowy
MOVSD XMM0, zero
COMISD XMM3, XMM0

; podzielenie gotowych wartoœci wspó³rzêdnych przez zbiorczy mianownik
JE write_table
DIVSD XMM6, XMM3
DIVSD XMM7, XMM3

; konwersja wartoœci wspó³rzêdnych z powrotem na liczby ca³kowite
CVTPD2DQ XMM1, XMM6
CVTPD2DQ XMM2, XMM7

; zapis do tablicy wynikowej
write_table:
MOVD SDWORD PTR[RCX], XMM1
MOVD SDWORD PTR[RCX + 4], XMM2

RET

CalcNumerator ENDP

END
