	.model	small
	.stack	100h
	.data
a		dw	?
b		dw	?
c		dw	?
d		dw	?  
	.code
	
InputInt proc 
    mov ah,0ah
    xor di,di
    mov dx,offset buff
    int 21h 
    mov dl,0ah
    mov ah,02
    int 21h 
    mov si,offset buff+2 
    cmp byte ptr [si],"-" 
    jnz il
    mov di,1  
    inc si  
il:
    cmp byte ptr [si],"+" 
    jnz ii1
    inc si 	
ii1:
    xor ax,ax
    mov bx,10 
ii2:
    mov cl,[si] 
    cmp cl,0dh  
    jz endin
    cmp cl,'0' 
    jl er
    cmp cl,'9'  
    ja er
 
    sub cl,'0' 
    mul bx     
    add ax,cx  
    inc si    
    jmp ii2    
 
er:  
    mov dx, offset error
    mov ah,09
    int 21h
    int 20h
endin:
    cmp di,1 
    jnz ii3
    neg ax   ; делаем число отрицательным
ii3:
    ret
 
error db "incorrect number$"
buff    db 6,7 Dup(?)
InputInt endp

OutInt proc
test    ax, ax
jns     oi1
    mov  cx, ax
    mov     ah, 02h
    mov     dl, '-'
    int     21h
    mov  ax, cx
    neg     ax
oi1:  
    xor     cx, cx
    mov     bx, 10 
oi2:
    xor     dx,dx
    div     bx
    push    dx
    inc     cx
    test    ax, ax
    jnz     oi2
    mov     ah, 02h
oi3:
    pop     dx
    cmp     dl,9
    jbe     oi4
    add     dl,7
oi4:
    add     dl, '0'
    int     21h
    loop    oi3
    
    ret 
OutInt endp 

start: 
    mov	ax,@data
	mov	ds,ax  
;09)  |(a-b-c) /(d-b2)|+|d/(100-c2)|
	call Inputint
	mov a, ax
	call Inputint
	mov b, ax
	call Inputint
	mov c, ax
	call Inputint
	mov d, ax
	mov ax, a
	mov bx, b
	sub ax, bx
	mov cx, c
	sub ax, cx
	mov cx, ax ; в cx хранится результат (a-b-c)
	
	mov bx, b
	mov ax, bx
	imul bx ; в ax хранится b^2
	
	mov dx, d
	sub dx, ax ; в dx хранится результат (d-b^2)
	
	mov ax, cx
	mov cx, dx
	cwd
	idiv cx ; в ax результат (a-b-c) /(d-b2)
	
modul:
	neg ax
	js modul		;если число меньше 0 то делаем его положительным
	
	mov bx, ax
	
	mov cx, c
	mov ax, cx
	imul cx ; в ax хранится c^2
	mov cx, 100
	sub cx, ax ; в cx хранится 100 - с^2
	
	mov ax, d
	cwd
	idiv cx ; в ax хранится d/(100 - c^2)
	
modul1:
	neg ax
	js modul1		;если число меньше 0 то делаем его положительным
	
	add bx, ax
	mov ax, bx ; результат всего выражения в ax
	
	call OutInt
	
	mov	ax,4C00h
	int	21h
	end	start