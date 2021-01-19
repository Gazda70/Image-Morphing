

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

; RDX = > adres tablicy dystans�w relatywnych
MOV relDistPointer, RDX

; R8 = > adres tablicy punkt�w charakterystycznych
MOV outputCharPtsPointer, R8

; R9 = > warto�� wsp�rz�dnej poziomej aktualnie analizowanego piksela
MOV resX, R9

; rsp + 8 * 5 = > warto�� wsp�rz�dnej pionowej aktualnie analizowanego piksela
MOV RAX, QWORD PTR[rsp + 8 * 5]
MOV resY, RAX

; rsp + 8 * 6 = > rozmiar tablicy z aktualnie branymi pod uwag� punktami charakterystycznymi
MOV RAX, QWORD PTR[rsp + 8 * 6]
MOV max, RAX
; rozmiar tablicy dytans�w relatywnych - bierzemy pod uwag� tylko taki
; fragment tablicy dystans�w relatywnych kt�ry ma tak� sam� d�ugo�� jak
;aktualnie analizowany fragment tablicy punkt�w charakterystycznych

; inicjalizacja zbiorczego mianownika (XMM3), rejestr�w do przechowywania wsp�rz�dnych (XMM6, XMM7)
MOVSD XMM3, zero
MOVSD XMM6, zero
MOVSD XMM7, zero

; inicjalizacja licznika p�tli
MOV R10, 0

; p�tla przechodz�ca przez tablic� punkt�w charakterystycznych
charPointsLoop :

; aktualizacja warto�ci indeksu do obs�ugi dost�pu do tablic
MOV RAX, 8
MUL R10
MOV indeks, RAX

; wyznaczenie r�nicy wsp�rz�dnych aktualnego punktu charakterystycznego
; oraz wsp�rz�dnych aktualnego piksela
MOV R14, outputCharPtsPointer
ADD R14, indeks
MOV EAX, [R14]
MOVD XMM0, EAX
SUBSD XMM0, resX
MOV EAX, [R14 + 4]
MOVD XMM1, EAX
SUBSD XMM1, resY

; wyznaczenie sumy kwadrat�w wcze�niej obliczonych r�nic
MOVQ RAX, XMM0
MUL RAX
MOV R12, RAX
MOVQ RAX, XMM1
MUL RAX
ADD RAX, R12

; konwersja obliczonej sumy na liczb� zmiennoprzecinkow�, przeniesienie jej do rejestru XMM
; oraz sprawdzenie czy jest niezerowa
MOVQ XMM2, RAX
CVTDQ2PD XMM1, XMM2
MOVSD XMM0, zero
COMISD XMM1, XMM0
JE ifzero

; obliczenie odwrotno�ci aktualnego mianownika i dodanie jej do zbiorczego mianownika
MOVSD XMM0, one
DIVSD XMM0, XMM1

; aktualizacja warto�ci zbiorczego mianownika
ADDSD XMM3, XMM0

; uzyskanie z tablicy, konwersja i przeniesienie do rejestr�w XMM aktualnego relatywnego dystansu
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

; dodanie do zbiorczych wsp�rz�dnych
ADDSD XMM6, XMM4
ADDSD XMM7, XMM5

; obs�uga licznika p�tli
ifzero :
INC R10
CMP R10, max
JNE charPointsLoop

koniec :
; sprawdzenie czy zbiorczy mianownik jest niezerowy
MOVSD XMM0, zero
COMISD XMM3, XMM0

; podzielenie gotowych warto�ci wsp�rz�dnych przez zbiorczy mianownik
JE write_table
DIVSD XMM6, XMM3
DIVSD XMM7, XMM3

; konwersja warto�ci wsp�rz�dnych z powrotem na liczby ca�kowite
CVTPD2DQ XMM1, XMM6
CVTPD2DQ XMM2, XMM7

; zapis do tablicy wynikowej
write_table:
MOVD SDWORD PTR[RCX], XMM1
MOVD SDWORD PTR[RCX + 4], XMM2

RET

CalcNumerator ENDP

END
