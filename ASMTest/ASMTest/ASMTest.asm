
.data
col_nr QWORD 0
row_nr QWORD 0
zero QWORD 0

.code

CalcNumerator PROC

; liczba wierszy
MOV[row_nr], RCX
; liczba kolumn - zak�adamy �e r�wna 2
; wska�nik na pocz�tek tablicy 2D
MOV R11, RDX
; rejestr do zsumowania warto�ci
MOV R12, 0

; licznik p�tli wierszy
MOV R10, 0

row_loop:

ADD R12, [R11 + R10 * 8]
ADD R12, [R11 + R10 * 8 + 4]

; obs�uga licznika p�tli wierszy
INC R10
CMP R10, [row_nr]
JNE row_loop

; finish:
MOV RAX, R12
RET

CalcNumerator ENDP

END