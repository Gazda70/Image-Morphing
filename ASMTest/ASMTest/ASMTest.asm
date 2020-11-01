

.data
resX QWORD 0
resY QWORD 0
max QWORD 0
relDistLen QWORD 0
oCPLen QWORD 0
actualDenom REAL8 0.0
cumulatedDenom REAL8 0.0

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

; licznik p�tli
MOV R10, 0
MOV RAX, 0
; p�tla przechodz�ca przez tablic� punkt�w charakterystycznych
charPointsLoop:

; wyznaczenie r�nicy wsp�rz�dnych aktualnego punktu charatkerystycznego
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
MOV actualDenom, RAX
; konwersja na liczb� zmiennoprzecinkow� w celu umo�liwienia dalszych oblicze�
 CVTDQ2PD XMM0, actualDenom
; VRCP14PD XMM1, XMM0
; MOVSD XMM0, XMM1

ifzero:
; obs�uga licznika p�tli
; INC R10
; CMP R10, oCPLen
; JNE charPointsLoop


RET

CalcNumerator ENDP

END

