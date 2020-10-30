.386
.model flat, stdcall

.data
totalFirst  DWORD 0
totalSecond  QWORD 0

.code

 Addition PROC stdcall EXPORT a : DWORD, b : DWORD
 mov eax, a
 add eax, b
 RET
 Addition ENDP

CalcNumerator PROC stdcall EXPORT  resX : DWORD, resY : DWORD, max : DWORD, relDistLen : DWORD, oCPLen : DWORD, relDist : DWORD, outputCharPoints : DWORD

MOV eax, oCPLen

outer:
ADD totalFirst, 1
DEC eax
JZ finish
JMP outer

finish:
MOV eax, totalFirst
RET
CalcNumerator ENDP

END