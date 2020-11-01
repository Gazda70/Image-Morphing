
.data
col_nr QWORD 0
row_nr QWORD 0
zero QWORD 0

.code

CalcNumerator PROC

; liczba wierszy
MOV[row_nr], RCX
; liczba kolumn - zak³adamy ¿e równa 2
; wskaŸnik na pocz¹tek tablicy 2D
MOV R11, RDX
; rejestr do zsumowania wartoœci
MOV R12, 0

; licznik pêtli wierszy
MOV R10, 0

row_loop:

ADD R12, [R11 + R10 * 8]
ADD R12, [R11 + R10 * 8 + 4]

; obs³uga licznika pêtli wierszy
INC R10
CMP R10, [row_nr]
JNE row_loop

; finish:
MOV RAX, R12
RET

CalcNumerator ENDP

END