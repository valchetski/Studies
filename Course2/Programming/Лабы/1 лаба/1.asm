	.model	small
	.stack	100h
	.code
start: 
    mov	ax,@data
	mov	ds,ax  
	mov ax, a
	mov bx, ax
	imul bx
	imul bx  ;посчитали a^3
	mov bx, ax
	
	mov ax, b
	imul ax  ;посчитали b^2
		
	cmp ax, bx
	jl a_more_b; если a^3 > b^2 то переходим на эту метку
	
	mov cx, c
	mov ax, d
	imul cx
	mov bx, b
	add ax, bx
	mov	ax,4C00h
	int	21h  
	
a_more_b:
    mov ax, c
	mov bx, d
	imul bx
	mov cx, ax; посчитали c*d
	
	mov ax, a
	mov bx, b 
	cwd
	idiv bx ;посчитали a/b
	
	cmp cx, ax
	jz ravno ;если c*d=a/b то переходим на эту метку
	
	mov ax, a
	mov bx, b
	mov cx, c

	cmp cx, ax
	jl  ax_more_cx 
back:	
	cmp cx, bx
	jl bx_more_cx
back1:	
	mov dx, d
	cmp dx, ax
	jl ax_more_dx
back2:	
	cmp dx, bx
	jl bx_more_dx	
back3:	
	imul bx
	mov	ax,4C00h
	int	21h
ax_more_cx:
	mov dx, ax
	mov ax, cx
	mov cx, dx
	jmp back
	
bx_more_cx:
	mov dx, bx
	mov bx, cx
	mov cx, dx
	jmp back1
	
ax_more_dx:
	mov cx, ax	
	mov ax, dx
	mov dx, cx
	jmp back2
	
bx_more_dx:
	mov cx, bx
	mov bx, dx
	mov dx, cx
	jmp back3
    
ravno: 
    mov ax, a
    mov bx, b
    and ax, bx     
    mov	ax,4C00h
	int	21h
 
    .data
a		dw	1
b		dw	2
c		dw	3
d		dw	4   
end start