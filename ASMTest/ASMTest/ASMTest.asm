
.data
counter QWORD 5
zero QWORD 0

.code

Addition PROC

RET
Addition ENDP

; ADD    ECX, DWORD PTR[RSP + 28H]; add overflow parameter to first parameter
; ADD    ECX, R9D; add other three register parameters
; ADD    ECX, R8D;
; ADD    ECX, EDX;
; MOVD   XMM0, ECX; move doubleword ECX into XMM0
; CVTDQ2PD  XMM0, XMM0; convert doubleword to floating point
; MOVSD  XMM1, realVal; load 1.5
; ADDSD  XMM1, MMWORD PTR[RSP + 30H]; add parameter
; DIVSD  XMM0, XMM1; do division, answer in xmm0

CalcNumerator PROC

MOV R11, zero
MOV R14, zero
MOV R12, R8
MOV RSI, R12
MOV R13, [RCX]
looper:
ADD R11, [R12]
MOV R12, [RSI + R14 * 8]
INC R14
CMP R14, R13
JE finish
JMP looper
finish:
MOV [R8], R11
RET

CalcNumerator ENDP

END