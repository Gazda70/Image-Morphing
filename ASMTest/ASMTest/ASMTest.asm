.386
.model flat, stdcall

.data


.code

 Addition PROC stdcall EXPORT a : DWORD, b : DWORD
 mov eax, a
 add eax, b
 RET
 Addition ENDP

END