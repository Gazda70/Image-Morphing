

.data
resX QWORD 0
resY QWORD 0
max QWORD 0
relDistLen QWORD 0
help QWORD 0.0
cumulatedDenom REAL8 0.0
zero REAL8 0.0
one REAL8 1.0

.code

CalcNumerator PROC

; RCX = > adres tablicy na wynik
; po�o�enie aktualnego pixela
MOV resX, RDX
MOV resY, R8
; rozmiar tablicy z aktualnie branymi pod uwag� punktami charakterystycznymi
MOV max, R9
; rozmiar tablicy dytans�w relatywnych
MOV EAX, DWORD PTR[rsp + 8 * 5]
MOV relDistLen, RAX
; [rsp + 8 * 6] = > adres tablicy z dystansami relatywnymi
; [rsp + 8 * 7] = > adres tablicy z punktami charakterystycznymi

; inicjalizacja zbiorczego mianownika, rejestr�w do przechowywania wsp�rz�dnych
; w trakcie pracy p�tli oraz tablicy na wynik
MOVSD XMM3, zero
MOVSD XMM6, zero
MOVSD XMM7, zero
MOV R11, 0
MOV [RCX], R11
MOV [RCX + 4], R11

; licznik p�tli
MOV R10, 0
MOV RAX, 0
; p�tla przechodz�ca przez tablic� punkt�w charakterystycznych
charPointsLoop:


; wyznaczenie r�nicy wsp�rz�dnych aktualnego punktu charakterystycznego
; oraz wsp�rz�dnych aktualnego piksela
MOV RBX, QWORD PTR[RSP + 8 * 7]
MOV R12, [RBX]
MOV R11, [RBX + 4]
SUB R12, resX
SUB R11, resY

; wyznaczenie sumy kwadrat�w wcze�niej obliczonych r�nic
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

; konwersja na liczb� zmiennoprzecinkow� w celu umo�liwienia dalszych oblicze�
CVTDQ2PD XMM1, help

; obliczenie odwrotno�ci acutalDenom i dodanie jej do cumulatedDenom
MOVSD XMM0, one
DIVSD XMM0, XMM1
; teoretycznie mo�na zast�pi� tym ale nie dzia�a = > VRCP14PD XMM1, XMM0

; aktualizacja warto�ci zbiorczego mianownika
ADDSD XMM3, XMM0


; wyci�gni�cie z tablicy i konwersja aktualnych relatywnych dystans�w
MOV RBX, QWORD PTR[RSP + 8 * 6]
MOV R11, [RBX]
MOV help, R11
MOVD XMM0, help
CVTDQ2PD XMM4, XMM0
MOV RBX, QWORD PTR[RSP + 8 * 6]
MOV R11, [RBX + 4]
MOV help, R11
MOVD XMM0, help
CVTDQ2PD XMM5, XMM0





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

koniec:
; podzielenie gotowych warto�ci wsp�rz�dnych przez zbiorczy mianownik
DIVSD XMM6, XMM3
DIVSD XMM7, XMM3

; konwersja z powrotem na liczby ca�kowite
CVTPD2DQ XMM1, XMM6
CVTPD2DQ XMM2, XMM7

; zapis do tablicy wynikowej
MOV RAX, 1
MOV [RCX], RAX
MOV RAX, 2
MOV [RCX + 4], RAX

RET

CalcNumerator ENDP

END